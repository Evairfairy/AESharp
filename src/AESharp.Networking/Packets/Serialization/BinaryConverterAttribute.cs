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
        private static readonly Type ConverterBaseType;

        static BinaryConverterAttribute()
        {
            ConverterBaseType = typeof( BinaryConverter );
        }

        public Type ConverterType { get; }

        public BinaryConverterAttribute( Type type )
        {
            if( !type.Inherits( ConverterBaseType ) )
                throw new ArgumentException( "Converter type must inherit from BinaryConverter", nameof( type ) );

            this.ConverterType = type;
        }
    }
}
