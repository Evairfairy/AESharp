using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AESharp.Networking.Packets;

namespace AESharp.Router.Routing.Packets.Handlers
{
    internal sealed class InitiateHandshakePacketHandler : RoutingPacketHandler<InitiateHandshakePacket>
    {
        public override PacketHandlerResult HandlePacket( InitiateHandshakePacket packet )
        {
            if( packet.ProtocolVersion != MasterRouter.ProtocolVersion )
            {
                var disconnectPacket = new DisconnectPacket
                {
                    Reason =
                            $"Required protocol version is {MasterRouter.ProtocolVersion}, received {packet.ProtocolVersion}"
                };

                return new PacketHandlerResult( true, disconnectPacket );
            }

            var acceptPacket = new AcceptHandshakePacket();
            return new PacketHandlerResult( false, acceptPacket );
        }
    }
}
