using System;
using AESharp.Networking.Data.Packets;
using AESharp.Routing.Middleware;

namespace AESharp.Routing.Networking
{
    public class AEPacket : ManagedPacket<RoutingMetaPacket>
    {
        protected readonly RoutingMetaPacket InternalMetaPacket;

        // ReSharper disable once RedundantDefaultMemberInitializer
        private bool _finalized = false;

        public AEPacketId PacketId => InternalMetaPacket.PacketId;

        public AEPacket(AEPacketId packetId)
        {
            InternalMetaPacket = new RoutingMetaPacket
            {
                PacketId = packetId
            };
        }

        public AEPacket(RoutingMetaPacket internalMetaPacket) : base(internalMetaPacket.Payload)
        {
            InternalMetaPacket = internalMetaPacket;
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            if (_finalized)
            {
                throw new InvalidOperationException("A packet may only be finalized once.");
            }

            _finalized = true;

            InternalMetaPacket.Payload = InternalPacket.FinalizePacket();

            return InternalMetaPacket;
        }
    }
}