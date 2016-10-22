using System;
using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;

namespace AESharp.Logon.Universal.Networking.Packets
{
    public sealed class LogonPacket : Packet
    {
        private const int HeaderSize = sizeof( byte ) + sizeof( byte ) + sizeof( ushort );

        public LogonPacket( byte[] data ) : base( data )
        {
            if ( this.InternalBuffer.Length < HeaderSize )
            {
                throw new InvalidPacketException(
                    $"Received packet with incomplete header (only {this.InternalBuffer.Length} bytes received)" );
            }
            this.Opcode = this.ReadByte();
            this.Error = this.ReadByte();
            ushort length = this.ReadUShort();

            // Sanity checks
            if ( length < this.Payload.Count )
            {
                throw new InvalidPacketException(
                    $"Length was read as {length} bytes but payload was {this.Payload.Count} bytes" );
            }

            if ( length > this.Payload.Count )
            {
                throw new InvalidPacketException(
                    $"Fragmented packets are not supported at this time (length was {length} bytes but payload was {this.Payload.Count} bytes" );
            }
        }

        public byte Opcode { get; set; }

        public byte Error { get; set; }

        /// <summary>
        ///     Automatically calculated when sending
        /// </summary>
        public ushort Length => (ushort) this.Payload.Array.Length;

        public ArraySegment<byte> Payload
            => new ArraySegment<byte>( this.InternalBuffer, HeaderSize, this.InternalBuffer.Length - HeaderSize );
    }
}