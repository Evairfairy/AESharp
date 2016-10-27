using System;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Extensions;
using AESharp.Routing.Middleware;

namespace AESharp.Routing.Networking
{
    public class AEPacket<TMetaPacket> where TMetaPacket : ManagedPacket<TMetaPacket>, RoutingMetaPacket
    {
        // ReSharper disable once RedundantDefaultMemberInitializer
        private bool _finalized = false;

        public AEPacketId PacketId { get; }

        public AEPacket( AEPacketId packetId )
        {
            this.PacketId = packetId;
        }

        public AEPacket( AEPacketId packetId, byte[] data ) : base(data)
        {
            this.PacketId = packetId;
        }

        public override TMetaPacket FinalizePacket()
        {
            if ( this._finalized )
            {
                throw new InvalidOperationException( "A packet may only be finalized once." );
            }
            this._finalized = true;

            Packet myLittlePacket = new Packet();

            myLittlePacket.WriteInt32( (int) this.PacketId );
            myLittlePacket.WriteBytes( this.InternalPacket.FinalizePacket() );

            return myLittlePacket.FinalizePacket();
        }
    }
}