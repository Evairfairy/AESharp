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

        public AEPacketId PacketId => this.InternalMetaPacket.PacketId;

        public AEPacket( AEPacketId packetId )
        {
            this.InternalMetaPacket = new RoutingMetaPacket
            {
                PacketId = packetId
            };
        }

        public AEPacket( RoutingMetaPacket internalMetaPacket ) : base( internalMetaPacket.Payload )
        {
            this.InternalMetaPacket = internalMetaPacket;
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            if ( this._finalized )
            {
                throw new InvalidOperationException( "A packet may only be finalized once." );
            }

            this._finalized = true;

            this.InternalMetaPacket.Payload = this.InternalPacket.FinalizePacket();

            return this.InternalMetaPacket;
        }
    }
}