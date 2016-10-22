using System;
using AESharp.Networking.Interfaces;

namespace AESharp.Networking.Data
{
    public class Packet : IRealPacket
    {
        private byte[] _internalBuffer;

        public Packet()
        {
            this._internalBuffer = new byte[0];
            this.BufferPosition = 0;
        }

        public Packet( byte[] data )
        {
            this._internalBuffer = data;
            this.BufferPosition = 0;
        }

        public Packet( IRealPacket packet )
        {
            this._internalBuffer = packet.InternalBuffer;
            this.BufferPosition = packet.BufferPosition;
        }

        public byte[] InternalBuffer => this._internalBuffer;

        public int BufferPosition { get; set; }

        public byte[] ReadBytes( int count )
        {
            byte[] buffer = new byte[count];

            Array.Copy( this.InternalBuffer, this.BufferPosition, buffer, 0, count );
            this.BufferPosition += count;

            return buffer;
        }

        public void WriteBytes( byte[] val )
        {
            int requiredLength = this.BufferPosition + val.Length;
            int currentLength = this.InternalBuffer.Length;
            int lengthDifference = requiredLength - currentLength;

            if ( lengthDifference > 0 )
            {
                Array.Resize( ref this._internalBuffer, this.InternalBuffer.Length + lengthDifference );
            }

            Array.Copy( val, 0, this.InternalBuffer, this.BufferPosition, val.Length );
            this.BufferPosition += val.Length;
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

        public byte[] BuildPacket()
        {
            return this.InternalBuffer;
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