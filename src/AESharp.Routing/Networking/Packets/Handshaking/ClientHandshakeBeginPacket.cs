using AESharp.Routing.Core;
using AESharp.Routing.Extensions;
using AESharp.Routing.Middleware;

namespace AESharp.Routing.Networking.Packets.Handshaking
{
    public class ClientHandshakeBeginPacket : AEPacket
    {
        public ComponentType ComponentType;
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
            this.ComponentType = this.InternalPacket.ReadComponentType();
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            this.InternalPacket.WriteUInt32( this.Protocol );
            this.InternalPacket.WriteShortString( this.Password );
            this.InternalPacket.WriteComponentType( this.ComponentType );

            return base.FinalizePacket();
        }
    }
}