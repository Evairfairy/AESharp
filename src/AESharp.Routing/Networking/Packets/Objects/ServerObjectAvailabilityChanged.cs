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
                if ( !this._availableAssigned )
                {
                    throw new InvalidOperationException( "Available must be assigned to before being used" );
                }

                return this._available;
            }
            set
            {
                this._availableAssigned = true;
                this._available = value;
            }
        }

        public ServerObjectAvailabilityChanged() : base( AEPacketId.ServerNewObjectAvailable )
        {
        }

        public ServerObjectAvailabilityChanged( RoutingMetaPacket internalMetaPacket ) : base( internalMetaPacket )
        {
            this.InternalMetaPacket.PacketId = AEPacketId.ServerNewObjectAvailable;

            this.RoutingObject = this.InternalPacket.ReadRoutingComponent();
            this.Available = this.InternalPacket.ReadBoolean();
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            this.InternalPacket.WriteRoutingComponent( this.RoutingObject );
            this.InternalPacket.WriteBoolean( this.Available );

            return base.FinalizePacket();
        }
    }
}