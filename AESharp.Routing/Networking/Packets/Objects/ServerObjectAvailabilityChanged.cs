using System;
using AESharp.Routing.Core;
using AESharp.Routing.Extensions;
using AESharp.Routing.Middleware;

namespace AESharp.Routing.Networking.Packets.Objects
{
    public class ServerObjectAvailabilityChanged : AEPacket
    {
        private bool _available;

        private bool _availableAssigned;
        public RoutingComponent RoutingObject = new RoutingComponent();

        public bool Available
        {
            get
            {
                if (!_availableAssigned)
                    throw new InvalidOperationException("Available must be assigned to before being used");

                return _available;
            }
            set
            {
                _availableAssigned = true;
                _available = value;
            }
        }

        public ServerObjectAvailabilityChanged() : base(AEPacketId.ServerNewObjectAvailable)
        {
        }

        public ServerObjectAvailabilityChanged(RoutingMetaPacket internalMetaPacket) : base(internalMetaPacket)
        {
            InternalMetaPacket.PacketId = AEPacketId.ServerNewObjectAvailable;

            RoutingObject = InternalPacket.ReadRoutingComponent();
            Available = InternalPacket.ReadBoolean();
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            InternalPacket.WriteRoutingComponent(RoutingObject);
            InternalPacket.WriteBoolean(Available);

            return base.FinalizePacket();
        }
    }
}