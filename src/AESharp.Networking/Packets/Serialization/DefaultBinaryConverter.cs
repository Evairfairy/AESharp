using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;

namespace AESharp.Networking.Packets.Serialization
{
    public sealed class DefaultBinaryConverter : BinaryConverter
    {
        private static readonly TypeInfo ReaderType;
        private static readonly TypeInfo WriterType;
        private static readonly Type StringType;
        private static readonly Dictionary<Type, ReaderDelegate> TypeReaders;
        private static readonly Dictionary<Type, WriterDelegate> TypeWriters;

        static DefaultBinaryConverter()
        {
            ReaderType = typeof( BinaryReader ).GetTypeInfo();
            WriterType = typeof( BinaryWriter ).GetTypeInfo();
            StringType = typeof( string );

            TypeReaders = new Dictionary<Type, ReaderDelegate>();
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

            RegisterReaderForType<IPAddress>( IPAddressReader );
            RegisterReaderForType<Version>( VersionReader );
            RegisterReaderForType<Guid>( GuidReader );

            TypeWriters = new Dictionary<Type, WriterDelegate>();
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

            RegisterWriterForType<IPAddress>( IPAddressWriter );
            RegisterWriterForType<Version>( VersionWriter );
            RegisterWriterForType<Guid>( GuidWriter );
        }

        private static object GuidReader( BinaryReader reader, object s, Type t, object value, int? l )
        {
            byte[] buffer = reader.ReadBytes( 16 );
            return new Guid( buffer );
        }

        private static void GuidWriter( BinaryWriter writer, object s, Type t, object value, int? l )
        {
            Guid guid = (Guid) value;
            writer.Write( guid.ToByteArray() );
        }

        private static void VersionWriter( BinaryWriter writer, object s, Type t, object value, int? l )
        {
            Version version = value as Version ?? new Version( 0, 0, 0, 0 );

            writer.Write( (byte) version.Major );
            writer.Write( (byte) version.Minor );
            writer.Write( (byte) version.Build );
            writer.Write( (short) version.Revision );
        }

        private static void IPAddressWriter( BinaryWriter writer, object s, Type t, object value, int? l )
        {
            IPAddress ip = value as IPAddress ?? IPAddress.Loopback;
            writer.Write( ip.GetAddressBytes() );
        }

        private static object IPAddressReader( BinaryReader reader, object s, Type t, object v, int? l )
        {
            byte[] bytes = reader.ReadBytes( 4 );
            return new IPAddress( bytes );
        }

        private static object VersionReader( BinaryReader reader, object s, Type t, object v, int? l )
        {
            byte[] bytes = reader.ReadBytes( 3 );
            short build = reader.ReadInt16();
            return new Version( bytes[0], bytes[1], bytes[2], build );
        }

        public override bool CanRead( Type type )
            => TypeReaders.ContainsKey( type ) || type.IsArray || ( type == StringType );

        public override bool CanWrite( Type type )
            => TypeWriters.ContainsKey( type ) || type.IsArray || ( type == StringType );

        public override object Read( BinaryReader reader, object structure, Type type, object currentValue, int? length )
        {
            if ( type == StringType )
            {
                if ( length == null )
                {
                    throw new NotSupportedException( "Strings without a custom converter must have a length attribute" );
                }

                char[] chars = reader.ReadChars( length.Value );
                return new string( chars );
            }

            ReaderDelegate read;
            if ( TypeReaders.TryGetValue( type, out read ) )
            {
                return read( reader, structure, type, currentValue, length );
            }

            if ( length == null )
            {
                throw new InvalidOperationException( "Arrays must have a length attribute." );
            }

            Type element = type.GetElementType();
            if ( !this.CanRead( element ) )
            {
                throw new NotSupportedException( $"Array element type {type.FullName} is not supported." );
            }

            Array array = Array.CreateInstance( element, length.Value );
            for ( int i = 0; i < length.Value; ++i )
            {
                object value = this.Read( reader, structure, element, null, null );
                array.SetValue( value, i );
            }

            return array;
        }

        public override void Write( BinaryWriter writer, object structure, Type type, object value, int? length )
        {
            if ( type == StringType )
            {
                if ( length == null )
                {
                    throw new NotSupportedException( "Strings without a custom converter must have a length attribute" );
                }

                string str = value as string;
                writer.Write( str.ToCharArray() );
            }

            WriterDelegate write;
            if ( TypeWriters.TryGetValue( type, out write ) )
            {
                write( writer, structure, type, value, length );
                return;
            }

            Type element = type.GetElementType();
            if ( !this.CanWrite( element ) )
            {
                throw new NotSupportedException( $"Array element type {type.FullName} is not supported." );
            }

            Array array = (Array) value;
            for ( int i = 0; i < array.Length; ++i )
            {
                object arrayValue = array.GetValue( i );
                this.Write( writer, structure, element, arrayValue, null );
            }
        }

        private static void RegisterReaderForPrimitiveType< T >()
        {
            Type type = typeof( T );
            MethodInfo method = ReaderType.GetMethod( $"Read{type.Name}", BindingFlags.Public | BindingFlags.Instance );

            TypeReaders[type] = ( r, s, t, c, l ) => method.Invoke( r, null );
        }

        private static void RegisterWriterForPrimitiveType< T >()
        {
            Type type = typeof( T );
            MethodInfo method = WriterType.GetMethod( "Write", new[] {type} );

            TypeWriters[type] = ( w, s, t, v, l ) => method.Invoke( w, new[] {v} );
        }

        private static void RegisterReaderForType< T >( ReaderDelegate reader )
            => TypeReaders[typeof( T )] = reader;

        private static void RegisterWriterForType< T >( WriterDelegate writer )
            => TypeWriters[typeof( T )] = writer;

        internal delegate object ReaderDelegate(
            BinaryReader reader, object structure, Type type, object currentValue, int? length );

        internal delegate void WriterDelegate(
            BinaryWriter writer, object structure, Type type, object value, int? length );
    }
}