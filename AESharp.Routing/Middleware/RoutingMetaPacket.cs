using System;
using AESharp.Networking.Middleware;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Middleware
{
    public class RoutingMetaPacket : MetaPacket
    {
        public AEPacketId PacketId;
        public Guid Sender;
        public ushort Size;
        public Guid Target;

        public RoutingMetaPacket(byte[] payload) : base(payload)
        {
        }

        public RoutingMetaPacket()
        {
        }
    }
}