using AESharp.Routing.Core;
using AESharp.Routing.Extensions;
using AESharp.Routing.Middleware;

namespace AESharp.Routing.Networking.Packets.Handshaking
{
    public class ClientHandshakeBeginPacket : AEPacket
    {
        public RoutingComponent Component;
        public string Password;
        public uint Protocol;

        public ClientHandshakeBeginPacket() : base( AEPacketId.ClientHandshakeBegin )
        {
        }

        public ClientHandshakeBeginPacket( RoutingMetaPacket metaPacket ) : base( metaPacket )
        {
            this.InternalMetaPacket.PacketId = AEPacketId.ClientHandshakeBegin;

            this.Protocol = this.InternalPacket.ReadUInt32();
            this.Password = this.InternalPacket.ReadShortString();
            this.Component = this.InternalPacket.ReadRoutingComponent();
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            this.InternalPacket.WriteUInt32( this.Protocol );
            this.InternalPacket.WriteShortString( this.Password );
            this.InternalPacket.WriteRoutingComponent( this.Component );

            return base.FinalizePacket();
        }
    }
}