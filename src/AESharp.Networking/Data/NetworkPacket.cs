using System;

namespace AESharp.Networking.Data
{
    public class NetworkPacket
    {
        private byte[] _data;

        public NetworkPacket()
        {
            this._data = new byte[0];
            this.BytesWritten = 0;
            this.BytesRead = 0;
        }

        public NetworkPacket( byte[] data )
        {
            this._data = data;
            this.BytesWritten = data.Length;
            this.BytesRead = 0;
        }

        public int BytesWritten { get; private set; }
        public int BytesRead { get; private set; }

        public byte[] GetDataWritten()
        {
            byte[] buffer = new byte[this.BytesWritten];
            Array.Copy( this._data, 0, buffer, 0, this.BytesWritten );
            return buffer;
        }

        public byte[] ReadBytes( int count )
        {
            byte[] buffer = new byte[count];

            Array.Copy( this._data, this.BytesRead, buffer, 0, count );
            this.BytesRead += count;

            return buffer;
        }

        public void WriteBytes( byte[] val )
        {
            int requiredLength = this.BytesWritten + val.Length;
            int currentLength = this._data.Length;
            int lengthDifference = requiredLength - currentLength;

            if ( lengthDifference > 0 )
            {
                Array.Resize( ref this._data, this._data.Length + lengthDifference );
            }

            Array.Copy( val, 0, this._data, this.BytesWritten, val.Length );

            this.BytesWritten += val.Length;
        }

        public byte ReadByte()
        {
            return this.ReadBytes( sizeof( byte ) )[0];
        }

        public void WriteByte( byte val )
        {
            this.WriteBytes( new[] {val} );
        }

        public char ReadChar()
        {
            return (char) this.ReadByte();
        }

        public void WriteChar( char val )
        {
            this.WriteByte( (byte) val );
        }

        public bool ReadBool()
        {
            return BitConverter.ToBoolean( this.ReadBytes( sizeof( bool ) ), 0 );
        }

        public void WriteBool( bool val )
        {
            this.WriteBytes( BitConverter.GetBytes( val ) );
        }

        public short ReadShort()
        {
            return BitConverter.ToInt16( this.ReadBytes( sizeof( short ) ), 0 );
        }

        public void WriteShort( short val )
        {
            this.WriteBytes( BitConverter.GetBytes( val ) );
        }

        public ushort ReadUShort()
        {
            return BitConverter.ToUInt16( this.ReadBytes( sizeof( ushort ) ), 0 );
        }

        public void WriteUShort( ushort val )
        {
            this.WriteBytes( BitConverter.GetBytes( val ) );
        }

        public int ReadInt()
        {
            return BitConverter.ToInt32( this.ReadBytes( sizeof( int ) ), 0 );
        }

        public void WriteInt( int val )
        {
            this.WriteBytes( BitConverter.GetBytes( val ) );
        }

        public uint ReadUInt()
        {
            return BitConverter.ToUInt32( this.ReadBytes( sizeof( uint ) ), 0 );
        }

        public void WriteUInt( uint val )
        {
            this.WriteBytes( BitConverter.GetBytes( val ) );
        }

        public long ReadLong()
        {
            return BitConverter.ToInt64( this.ReadBytes( sizeof( long ) ), 0 );
        }

        public void WriteLong( long val )
        {
            this.WriteBytes( BitConverter.GetBytes( val ) );
        }

        public ulong ReadULong()
        {
            return BitConverter.ToUInt64( this.ReadBytes( sizeof( ulong ) ), 0 );
        }

        public void WriteULong( ulong val )
        {
            this.WriteBytes( BitConverter.GetBytes( val ) );
        }

        public string ReadFixedString( int len )
        {
            string s = string.Empty;

            for ( int i = 0; i < len; ++i )
            {
                char c = this.ReadChar();
                if ( c == '\0' )
                {
                    continue;
                }
                s += c;
            }

            return s;
        }

        public string ReadCString()
        {
            string s = string.Empty;

            while ( true )
            {
                char c = this.ReadChar();
                if ( c == '\0' )
                {
                    break;
                }

                s += c;
            }

            return s;
        }
    }
}