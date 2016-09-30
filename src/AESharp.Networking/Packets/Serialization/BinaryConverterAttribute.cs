using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace AESharp.Networking.Packets.Serialization
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false )]
    public sealed class BinaryConverterAttribute : Attribute
    {
        internal delegate object ConversionReader( BinaryReader reader, object structure, Type type, object currentValue, int? length );
        internal delegate void ConversionWriter( BinaryWriter writer, object structure, Type type, object value, int? length );
        internal delegate bool CanConvertDelegate( Type type );

        private static readonly Type ConverterBaseType;
        private static readonly TypeInfo ConverterBaseTypeInfo;
        private static readonly Type ObjectType;
        private static readonly Type TypeType; // yo dawg
        private static readonly Type[] ReaderSignature;
        private static readonly Type[] WriterSignature;
        private static readonly Type[] CanConvertSignature;

        static BinaryConverterAttribute()
        {
            ConverterBaseType = typeof( BinaryConverter );
            ConverterBaseTypeInfo = ConverterBaseType.GetTypeInfo();
            ObjectType = typeof( object );
            TypeType = typeof( Type );
            ReaderSignature = new[] { typeof( BinaryReader ), ObjectType, TypeType, ObjectType, typeof( int? ) };
            WriterSignature = new[] { typeof( BinaryWriter ), ObjectType, TypeType, ObjectType, typeof( int? ) };
            CanConvertSignature = new[] { TypeType };
        }

        public Type ConverterType { get; }

        private readonly TypeInfo TypeInfo;
        private ConversionReader Reader;
        private ConversionWriter Writer;

        public BinaryConverterAttribute( Type type )
        {
            if( !type.Inherits( ConverterBaseType ) )
                throw new ArgumentException( "Converter type must inherit from BinaryConverter", nameof( type ) );

            this.ConverterType = type;
            this.TypeInfo = type.GetTypeInfo();
        }

        internal object Read( BinaryReader reader, object structure, Type type, object currentValue, int? length )
        {
            if( this.Reader == null )
            {
                var method = this.TypeInfo.GetMethod( "ReadImpl", BindingFlags.NonPublic | BindingFlags.Instance );
                var converter = Activator.CreateInstance( this.ConverterType );
                this.Reader = (ConversionReader)method.CreateDelegate( typeof( ConversionReader ), converter );
            }

            return this.Reader( reader, structure, type, currentValue, length );
        }

        internal void Write( BinaryWriter writer, object structure, Type type, object value, int? length )
        {
            if( this.Writer == null )
            {
                var method = this.TypeInfo.GetMethod( "WriteImpl", WriterSignature );
                this.Writer = (ConversionWriter)method.CreateDelegate( typeof( ConversionWriter ), structure );
            }

            this.Writer( writer, structure, type, value, length );
        }
    }
}
