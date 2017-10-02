using System;
using AESharp.Logon.Universal.Networking.Middleware;
using AESharp.Networking.Data.Packets;

namespace AESharp.Logon.Universal.Networking.Packets
{
    public sealed class LogonPacket : Packet
    {
        public byte Opcode { get; set; }

        /// <summary>
        ///     Automatically calculated when sending
        /// </summary>
        public new ushort Length => (ushort) (base.Length - 1);

        public ArraySegment<byte> Payload
            => new ArraySegment<byte>(InternalBuffer, 1, Length);

        public LogonPacket(LogonMetaPacket metaPacket) : base(metaPacket.Payload)
        {
            Opcode = ReadByte();
        }
    }
}