using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using AESharp.Core.Extensions;

namespace AESharp.Networking.Packets.Serialization
{
    internal sealed class ReflectedMember
    {
        public delegate void ValueSetterDelegate( object value, object instance );
        public delegate object ValueGetterDelegate( object instance );
        public delegate object ValueTransformerDelegate( object value );

        private static readonly Type[] TransformSignature;

        static ReflectedMember()
        {
            TransformSignature = new[] { typeof( object ) };
        }

        public BinaryConverter Converter { get; }
        public int? Length { get; }
        public Type Type { get; }
        public string Name { get; }

        public ValueSetterDelegate SetValue { get; }
        public ValueGetterDelegate GetValue { get; }
        public ReadOnlyCollection<TransformerAttribute> Transformers { get; }

        public ReflectedMember( MemberInfo member )
        {
            this.Length = member.GetCustomAttribute<FixedLengthAttribute>()?.Length;

            var converterAttr = member.GetCustomAttribute<BinaryConverterAttribute>()
                             ?? new BinaryConverterAttribute( typeof( DefaultBinaryConverter ) );
            this.Converter = (BinaryConverter)Activator.CreateInstance( converterAttr.ConverterType ); ;
   

            var transformerType = typeof( TransformerAttribute );
            this.Transformers = member.GetCustomAttributes()
                                      .Select( a => new { Attribute = a, Type = a.GetType() } )
                                      .Where( a => a.Type.Inherits( transformerType ) )
                                      .Select( a => a.Attribute )
                                      .Cast<TransformerAttribute>()
                                      .ToList()
                                      .AsReadOnly();

            if( member is FieldInfo )
            {
                var field = member as FieldInfo;

                this.SetValue = field.SetValue;
                this.GetValue = field.GetValue;
                this.Type = field.FieldType;
                this.Name = field.Name;
            }
            else if( member is PropertyInfo )
            {
                var property = member as PropertyInfo;

                var getter = property.GetGetMethod( true );
                var setter = property.GetSetMethod( true );

                this.SetValue = ( instance, value ) => setter.Invoke( instance, new[] { value } );
                this.GetValue = ( instance ) => getter.Invoke( instance, null );
                this.Type = property.PropertyType;
                this.Name = property.Name;
            }
        }
    }
}
