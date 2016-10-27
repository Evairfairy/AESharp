using System;
using AESharp.Networking.Middleware;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Middleware
{
    public class RoutingMetaPacket : MetaPacket
    {
        public Guid Sender;
        public Guid Target;
        public AEPacketId PacketId;

        public RoutingMetaPacket( byte[] payload ) : base( payload )
        {
        }
    }
}