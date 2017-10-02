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

        public ClientHandshakeBeginPacket() : base(AEPacketId.ClientHandshakeBegin)
        {
        }

        public ClientHandshakeBeginPacket(RoutingMetaPacket metaPacket) : base(metaPacket)
        {
            InternalMetaPacket.PacketId = AEPacketId.ClientHandshakeBegin;

            Protocol = InternalPacket.ReadUInt32();
            Password = InternalPacket.ReadShortString();
            Component = InternalPacket.ReadRoutingComponent();
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            InternalPacket.WriteUInt32(Protocol);
            InternalPacket.WriteShortString(Password);
            InternalPacket.WriteRoutingComponent(Component);

            return base.FinalizePacket();
        }
    }
}