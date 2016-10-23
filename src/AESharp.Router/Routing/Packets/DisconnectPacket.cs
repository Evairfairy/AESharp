using AESharp.Networking.Data;

namespace AESharp.Router.Routing.Packets
{
    internal sealed class DisconnectPacket : Packet
    {
        public RoutingPacketId PacketId { get; } = RoutingPacketId.Disconnect;

        public string Reason { get; }

        public DisconnectPacket( string reason )
        {
            this.Reason = reason ?? "<no reason given>";
            this.WriteByte( (byte)this.PacketId );
            this.WriteShortString( this.Reason );
        }
    }
}
