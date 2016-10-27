using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AESharp.Networking.Data.Packets
{
    public class Packet
    {
        private readonly MemoryStream _memoryStream;
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;
        private bool _finalized = false;

        public bool Disposed { get; private set; }
        public long Length => this._memoryStream.Length;

        protected byte[] InternalBuffer
        {
            get
            {
                this._writer.Flush();
                this._memoryStream.Flush();
                return this._memoryStream.ToArray();
            }
        }

        public int BufferPosition
        {
            get { return (int) this._memoryStream.Position; }
            set { this._memoryStream.Position = value; }
        }

        public int BufferLength => this.InternalBuffer.Length;

        public Packet( Encoding encoding = null )
            : this( new MemoryStream(), encoding )
        {
        }

        public Packet( byte[] data, Encoding encoding = null )
            : this( new MemoryStream( data ), encoding )
        {
        }

        private Packet( MemoryStream dataStream, Encoding encoding = null )
        {
            encoding = encoding ?? Encoding.UTF8;
            this._memoryStream = dataStream;
            this._reader = new BinaryReader( dataStream, encoding, false );
            this._writer = new BinaryWriter( dataStream, encoding, false );
        }

        /// <summary>
        ///     Returns the byte[] representation of the current packet
        /// </summary>
        /// <returns>The byte[] representation of the current packet</returns>
        public virtual byte[] FinalizePacket()
        {
            return this.InternalBuffer;
        }

        /// <summary>
        ///     Seeks to the beginning of the packet
        /// </summary>
        public void SeekToBegin()
        {
            this._memoryStream.Seek( 0, SeekOrigin.Begin );
        }

        /// <summary>
        ///     Seeks to the end of the packet
        /// </summary>
        public void SeekToEnd()
        {
            this._memoryStream.Seek( 0, SeekOrigin.End );
        }

        public void Dispose() => this.Dispose( true );

        ~Packet()
        {
            this.Dispose( false );
        }

        public int Read() => this._reader.Read();
        public bool ReadBoolean() => this._reader.ReadBoolean();
        public byte ReadByte() => this._reader.ReadByte();
        public sbyte ReadSByte() => this._reader.ReadSByte();
        public char ReadChar() => this._reader.ReadChar();
        public short ReadInt16() => this._reader.ReadInt16();
        public ushort ReadUInt16() => this._reader.ReadUInt16();
        public int ReadInt32() => this._reader.ReadInt32();
        public uint ReadUInt32() => this._reader.ReadUInt32();
        public long ReadInt64() => this._reader.ReadInt64();
        public ulong ReadUInt64() => this._reader.ReadUInt64();
        public float ReadSingle() => this._reader.ReadSingle();
        public double ReadDouble() => this._reader.ReadDouble();
        public decimal ReadDecimal() => this._reader.ReadDecimal();
        public string ReadString() => this._reader.ReadString();
        public int Read( char[] buffer, int index, int count ) => this._reader.Read( buffer, index, count );
        public char[] ReadChars( int count ) => this._reader.ReadChars( count );
        public int Read( byte[] buffer, int index, int count ) => this._reader.Read( buffer, index, count );
        public byte[] ReadBytes( int count ) => this._reader.ReadBytes( count );

        public byte[] ReadRemainingBytes()
        {
            int remainingBytes = (int) ( this._memoryStream.Length - this._memoryStream.Position );

            if ( remainingBytes < 0 )
            {
                throw new InvalidOperationException(
                    $"Internal error in Packet->{nameof( this.ReadRemainingBytes )}: {nameof( remainingBytes )} was {remainingBytes}" );
            }

            if ( remainingBytes == 0 )
            {
                return new byte[0];
            }

            return this.ReadBytes( remainingBytes );
        }

        public string ReadFixedString( int len )
        {
            char[] chars = this.ReadChars( len );
            return new string( chars ).TrimEnd( '\0' );
        }

        public string ReadByteString() => this.ReadString( StringType.ByteString );
        public string ReadShortString() => this.ReadString( StringType.ShortString );
        public string ReadCString() => this.ReadString( StringType.NullTerminatedString );

        public List<T> ReadList<T>( Func<Packet, T> readObjectFunc )
        {
            List<T> returnList = new List<T>();

            ushort listSize = this.ReadUInt16();

            for ( ushort i = 0; i < listSize; ++i )
            {
                returnList.Add( readObjectFunc( this ) );
            }

            return returnList;
        }

        public void WriteList<T>( List<T> list, Action<Packet, T> writeObjectFunc )
        {
            if ( list.Count > ushort.MaxValue )
            {
                throw new InvalidOperationException(
                    $"You may only write lists containing a maximum of {ushort.MaxValue} elements" );
            }

            this.WriteUInt16( (ushort) list.Count );
            foreach ( T value in list )
            {
                writeObjectFunc( this, value );
            }
        }

        public Version ReadVersion()
        {
            return new Version(
                this.ReadByte(),
                this.ReadByte(),
                this.ReadByte(),
                this.ReadUInt16()
            );
        }

        // IPv4
        public IPAddress ReadIPAddress4() => new IPAddress( this.ReadBytes( 4 ) );

        public DateTime ReadDateTime()
        {
            long timestamp = this.ReadInt64();
            return DateTimeOffset.FromUnixTimeSeconds( timestamp ).DateTime;
        }

        public Guid ReadGuid()
        {
            byte[] buffer = this.ReadBytes( 16 );
            return new Guid( buffer );
        }

        private string ReadString( StringType stringType )
        {
            switch ( stringType )
            {
                case StringType.FixedString:
                    throw new NotSupportedException( "This method does not support reading fixed strings" );

                case StringType.ByteString:
                {
                    byte length = this.ReadByte();
                    char[] chars = this.ReadChars( length );
                    return new string( chars );
                }

                case StringType.ShortString:
                {
                    ushort length = this.ReadUInt16();
                    char[] chars = this.ReadChars( length );
                    return new string( chars );
                }

                case StringType.NullTerminatedString:
                {
                    StringBuilder builder = new StringBuilder();
                    char c;
                    while ( ( c = this.ReadChar() ) != '\0' )
                    {
                        builder.Append( c );
                    }

                    return builder.ToString();
                }

                default:
                    throw new NotSupportedException( Enum.GetName( typeof( StringType ), stringType ) );
            }
        }

        public void WriteBoolean( bool value ) => this._writer.Write( value );
        public void WriteByte( byte value ) => this._writer.Write( value );
        public void WriteSByte( sbyte value ) => this._writer.Write( value );
        public void WriteBytes( byte[] buffer ) => this._writer.Write( buffer );
        public void WriteBytes( byte[] buffer, int index, int count ) => this._writer.Write( buffer, index, count );
        public void WriteChar( char ch ) => this._writer.Write( ch );
        public void WriteChars( char[] chars ) => this._writer.Write( chars );
        public void WriteChars( char[] chars, int index, int count ) => this._writer.Write( chars, index, count );
        public void WriteDouble( double value ) => this._writer.Write( value );
        public void WriteDecimal( decimal value ) => this._writer.Write( value );
        public void WriteInt16( short value ) => this._writer.Write( value );
        public void WriteUInt16( ushort value ) => this._writer.Write( value );
        public void WriteInt32( int value ) => this._writer.Write( value );
        public void WriteUInt32( uint value ) => this._writer.Write( value );
        public void WriteInt64( long value ) => this._writer.Write( value );
        public void WriteUInt64( ulong value ) => this._writer.Write( value );
        public void WriteSingle( float value ) => this._writer.Write( value );

        public void WriteDateTime( DateTime value )
        {
            DateTimeOffset offset = value.Kind != DateTimeKind.Utc ? value.ToUniversalTime() : value;
            this.WriteInt64( offset.ToUnixTimeSeconds() );
        }

        public void WriteGuid( Guid guid )
        {
            byte[] bytes = guid.ToByteArray();
            this.WriteBytes( bytes );
        }

        public void WriteFixedString( string value )
            => this.WriteString( value, StringType.FixedString );

        public void WriteByteString( string value )
            => this.WriteString( value, StringType.ByteString );

        public void WriteShortString( string value )
            => this.WriteString( value, StringType.ShortString );

        public void WriteCString( string value ) => this.WriteString( value, StringType.NullTerminatedString );

        private void WriteString( string value, StringType type )
        {
            switch ( type )
            {
                case StringType.FixedString:
                {
                    this.WriteChars( value.ToCharArray() );
                    return;
                }
                case StringType.NullTerminatedString:
                {
                    this.WriteChars( value.ToCharArray() );
                    this.WriteByte( 0x0 );
                    return;
                }
                case StringType.ByteString:
                {
                    this.ValidateStringLengthOrThrow( value.Length, byte.MaxValue );
                    this.WriteByte( (byte) value.Length );
                    this.WriteChars( value.ToCharArray() );
                    return;
                }
                case StringType.ShortString:
                {
                    this.ValidateStringLengthOrThrow( value.Length, ushort.MaxValue );
                    this.WriteUInt16( (ushort) value.Length );
                    this.WriteChars( value.ToCharArray() );
                    return;
                }
            }
        }

        private void WriteString( string value, StringPrefix prefix, StringTerminator terminator )
        {
            int maxLength = 0;
            switch ( terminator )
            {
                case StringTerminator.None:
                    break;

                // We don't actually care about these when there's a prefix
                case StringTerminator.Null:
                case StringTerminator.Space:
                    maxLength -= 1;
                    break;

                default:
                    throw new NotSupportedException( Enum.GetName( typeof( StringTerminator ), terminator ) );
            }

            switch ( prefix )
            {
                case StringPrefix.None:
                    if ( terminator == StringTerminator.None )
                    {
                        throw new InvalidOperationException( "String terminator cannot be none when there is no prefix" );
                    }
                    break;

                case StringPrefix.Byte:
                    maxLength = byte.MaxValue;
                    this.ValidateStringLengthOrThrow( value.Length, maxLength );
                    this.WriteByte( (byte) value.Length );
                    break;

                case StringPrefix.Short:
                    maxLength = short.MinValue;
                    this.ValidateStringLengthOrThrow( value.Length, maxLength );
                    this.WriteInt16( (short) value.Length );
                    break;

                case StringPrefix.Int:
                    maxLength = int.MaxValue;
                    this.ValidateStringLengthOrThrow( value.Length, maxLength );
                    this.WriteInt32( value.Length );
                    break;

                default:
                    throw new NotSupportedException( Enum.GetName( typeof( StringPrefix ), prefix ) );
            }

            this.WriteChars( value.ToCharArray() );
        }

        private void ValidateStringLengthOrThrow( int actualLength, int maxAllowedLength )
        {
            if ( actualLength > maxAllowedLength )
            {
                throw new InvalidOperationException(
                    $"String length ({actualLength:#,#0}) exceeds maximum length of {maxAllowedLength:#,#0}" );
            }
        }

        protected virtual void Dispose( bool disposeManagedResources )
        {
            if ( this.Disposed )
            {
                return;
            }

            if ( disposeManagedResources )
            {
                this._memoryStream.Dispose();
                this._reader.Dispose();
                this._writer.Dispose();
            }

            this.Disposed = true;
        }
    }
}