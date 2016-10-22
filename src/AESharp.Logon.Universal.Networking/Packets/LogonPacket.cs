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