using AESharp.Networking.Data;
using AESharp.Router.Extensions;

namespace AESharp.Router.Protocol
{
    public abstract class RoutingPacket : Packet
    {
        public RoutingPacketId PacketId { get; }

        public RoutingPacket( RoutingPacketId packetId )
        {
            this.PacketId = packetId;
            this.WritePacketId( packetId );
        }

        public RoutingPacket( byte[] data )
            : base( data )
        {
            this.PacketId = this.ReadPacketId();
        }
    }
}