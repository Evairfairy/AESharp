using System;

namespace AESharp.Interop.Protocol
{
    public sealed class KeepAlivePacket : RoutingPacket
    {
        public DateTime TimeSent { get; }
        public Guid Guid { get; }

        public KeepAlivePacket(byte[] data) : base(data)
        {
            TimeSent = ReadDateTime();
            Guid = ReadGuid();
        }

        public KeepAlivePacket(DateTime timeSent, Guid guid) : base(RoutingPacketId.KeepAlive)
        {
            TimeSent = timeSent;
            Guid = guid;

            WriteDateTime(timeSent);
            WriteGuid(guid);
        }

        public KeepAlivePacket WithDateTime(DateTime newDateTime)
        {
            return new KeepAlivePacket(newDateTime, Guid);
        }
    }
}