using System;
using AESharp.Networking.Data.Packets;

namespace AESharp.Logon.Universal.Networking.Packets
{
    public sealed class LogonPacket : Packet
    {
        public byte Opcode { get; set; }

        public byte Error { get; set; }

        /// <summary>
        ///     Automatically calculated when sending
        /// </summary>
        public new ushort Length => (ushort) ( base.Length - 1 );

        public ArraySegment<byte> Payload
            => new ArraySegment<byte>( this.InternalBuffer, 1, this.Length );

        public LogonPacket( byte[] data ) : base( data )
        {
            this.Opcode = this.ReadByte();
        }
    }
}