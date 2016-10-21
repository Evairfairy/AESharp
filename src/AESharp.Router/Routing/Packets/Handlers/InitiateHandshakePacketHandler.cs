using AESharp.Networking.Packets;

namespace AESharp.Router.Routing.Packets.Handlers
{
    internal sealed class InitiateHandshakePacketHandler : RoutingPacketHandler<InitiateHandshakePacket>
    {
        public override PacketHandlerResult HandlePacket( InitiateHandshakePacket packet )
        {
            if ( packet.ProtocolVersion != MasterRouter.ProtocolVersion )
            {
                DisconnectPacket disconnectPacket = new DisconnectPacket
                {
                    Reason =
                        $"Required protocol version is {MasterRouter.ProtocolVersion}, received {packet.ProtocolVersion}"
                };

                return new PacketHandlerResult( true, disconnectPacket );
            }

            AcceptHandshakePacket acceptPacket = new AcceptHandshakePacket();
            return new PacketHandlerResult( false, acceptPacket );
        }
    }
}