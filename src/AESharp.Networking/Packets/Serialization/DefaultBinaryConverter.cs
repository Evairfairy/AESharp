using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Reflection;

namespace AESharp.Networking.Packets.Serialization
{
    public sealed class DefaultBinaryConverter : BinaryConverter
    {
        private static readonly TypeInfo ReaderType;
        private static readonly TypeInfo WriterType;
        private static readonly Type StringType;
        private static readonly Dictionary<Type, BinaryConverterAttribute.ConversionReader> TypeReaders;
        private static readonly Dictionary<Type, BinaryConverterAttribute.ConversionWriter> TypeWriters;

        static DefaultBinaryConverter()
        {
            ReaderType = typeof( BinaryReader ).GetTypeInfo();
            WriterType = typeof( BinaryWriter ).GetTypeInfo();
            StringType = typeof( string );

            TypeReaders = new Dictionary<Type, BinaryConverterAttribute.ConversionReader>();
            RegisterReaderForPrimitiveType<sbyte>();
            RegisterReaderForPrimitiveType<byte>();
            RegisterReaderForPrimitiveType<short>();
            RegisterReaderForPrimitiveType<ushort>();
            RegisterReaderForPrimitiveType<int>();
            RegisterReaderForPrimitiveType<uint>();
            RegisterReaderForPrimitiveType<long>();
            RegisterReaderForPrimitiveType<ulong>();
            RegisterReaderForPrimitiveType<float>();
            RegisterReaderForPrimitiveType<double>();
            RegisterReaderForPrimitiveType<char>();
            RegisterReaderForPrimitiveType<bool>();

            RegisterReaderForType<IPAddress>( ( reader, s, t, v, l ) =>
            {
                var bytes = reader.ReadBytes( 4 );
                return new IPAddress( bytes );
            } );

            RegisterReaderForType<Version>( ( reader, s, t, v, l ) =>
            {
                var bytes = reader.ReadBytes( 3 );
                var build = reader.ReadInt16();
                return new Version( bytes[0], bytes[1], bytes[2], build );
            } );

            TypeWriters = new Dictionary<Type, BinaryConverterAttribute.ConversionWriter>();
            RegisterWriterForPrimitiveType<sbyte>();
            RegisterWriterForPrimitiveType<byte>();
            RegisterWriterForPrimitiveType<short>();
            RegisterWriterForPrimitiveType<ushort>();
            RegisterWriterForPrimitiveType<int>();
            RegisterWriterForPrimitiveType<uint>();
            RegisterWriterForPrimitiveType<long>();
            RegisterWriterForPrimitiveType<ulong>();
            RegisterWriterForPrimitiveType<float>();
            RegisterWriterForPrimitiveType<double>();
            RegisterWriterForPrimitiveType<char>();
            RegisterWriterForPrimitiveType<bool>();

            RegisterWriterForType<IPAddress>( ( writer, s, t, value, l ) =>
            {
                var ip = value as IPAddress;
                writer.Write( ip.GetAddressBytes() );
            } );

            RegisterWriterForType<Version>( ( writer, s, t, value, l ) =>
            {
                var version = value as Version;
                writer.Write( (byte)version.Major );
                writer.Write( (byte)version.Minor );
                writer.Write( (byte)version.Build );
                writer.Write( (short)version.Revision );
            } );
        }

        public override bool CanRead( Type type )
            => TypeReaders.ContainsKey( type ) || type.IsArray || type == StringType;

        public override bool CanWrite( Type type )
            => TypeWriters.ContainsKey( type ) || type.IsArray || type == StringType;

        public override object Read( BinaryReader reader, object structure, Type type, object currentValue, int? length )
        {
            if( type == StringType )
            {
                if( length == null )
                    throw new NotSupportedException( "Strings without a custom converter must have a length attribute" );

                var chars = reader.ReadChars( length.Value );
                return new String( chars );
            }

            BinaryConverterAttribute.ConversionReader read;
            if( TypeReaders.TryGetValue( type, out read ) )
                return read( reader, structure, type, currentValue, length );

            if( length == null )
                throw new InvalidOperationException( "Arrays must have a length attribute." );

            var element = type.GetElementType();
            if( !this.CanRead( element ) )
                throw new NotSupportedException( $"Array element type {type.FullName} is not supported." );

            var array = Array.CreateInstance( element, length.Value );
            for( var i = 0; i < length.Value; ++i )
            {
                var value = this.Read( reader, structure, element, null, null );
                array.SetValue( value, i );
            }

            return array;
        }

        public override void Write( BinaryWriter writer, object structure, Type type, object value, int? length )
        {
            if( type == StringType )
            {
                if( length == null )
                    throw new NotSupportedException( "Strings without a custom converter must have a length attribute" );

                var str = value as string;
                writer.Write( str.ToCharArray() );
            }

            BinaryConverterAttribute.ConversionWriter write;
            if( TypeWriters.TryGetValue( type, out write ) )
            {
                write( writer, structure, type, value, length );
                return;
            }

            var element = type.GetElementType();
            if( !this.CanWrite( element ) )
                throw new NotSupportedException( $"Array element type {type.FullName} is not supported." );

            var array = (Array)value;
            for( var i = 0; i < array.Length; ++i )
            {
                var arrayValue = array.GetValue( i );
                this.Write( writer, structure, element, arrayValue, null );
            }
        }

        private static void RegisterReaderForPrimitiveType<T>()
        {
            var type = typeof( T );
            var method = ReaderType.GetMethod( $"Read{type.Name}", BindingFlags.Public | BindingFlags.Instance );
            
            TypeReaders[type] = ( r, s, t, c, l ) => method.Invoke( r, null );
        }

        private static void RegisterWriterForPrimitiveType<T>()
        {
            var type = typeof( T );
            var method = WriterType.GetMethod( "Write", new[] { type } );

            TypeWriters[type] = ( w, s, t, v, l ) => method.Invoke( w, new object[] { v } );
        }

        private static void RegisterReaderForType<T>( BinaryConverterAttribute.ConversionReader reader )
            => TypeReaders[typeof( T )] = reader;

        private static void RegisterWriterForType<T>( BinaryConverterAttribute.ConversionWriter writer )
            => TypeWriters[typeof( T )] = writer;
    }
}
