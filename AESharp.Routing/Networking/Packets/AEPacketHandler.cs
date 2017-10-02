using System;
using System.Threading.Tasks;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Exceptions;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking.Packets.Handshaking;
using AESharp.Routing.Networking.Packets.Objects;

namespace AESharp.Routing.Networking.Packets
{
    public class AEPacketHandler<TPacketContext>
        where TPacketContext : AERoutingClient
    {
        private static readonly Func<AEPacket, TPacketContext, Task> NullHandler =
            (packet, context) => { throw new UnhandledAEPacketException((int) packet.PacketId); };

        public Func<ClientHandshakeBeginPacket, TPacketContext, Task> ClientHandshakeBeginHandler = NullHandler;
        public Func<ServerHandshakeResultPacket, TPacketContext, Task> ServerHandshakeResultHandler = NullHandler;

        public Func<ServerObjectAvailabilityChanged, TPacketContext, Task> ServerNewObjectAvailableHandler = NullHandler
            ;

        public async Task HandlePacket(RoutingMetaPacket metaPacket, TPacketContext context)
        {
            AEPacket packet = new AEPacket(metaPacket);

            // If authentication doesn't matter, handle packet here and return

            if (!context.Authenticated)
            {
                // We must be unauthenticated
                switch (packet.PacketId)
                {
                    case AEPacketId.ClientHandshakeBegin:
                        await ClientHandshakeBeginHandler(new ClientHandshakeBeginPacket(metaPacket), context);
                        break;
                    case AEPacketId.ServerHandshakeResult:
                        await
                            ServerHandshakeResultHandler(new ServerHandshakeResultPacket(metaPacket),
                                context);
                        break;
                    default:
                        throw new InvalidPacketException(
                            $"Received ({packet.PacketId}) requiring context to be unauthenticated but we are authenticated");
                }
            }
            else
            {
                // We must be authenticated
                switch (packet.PacketId)
                {
                    case AEPacketId.ServerNewObjectAvailable:
                        await
                            ServerNewObjectAvailableHandler(new ServerObjectAvailabilityChanged(metaPacket),
                                context);
                        break;
                    default:
                        throw new InvalidPacketException(
                            $"Received ({packet.PacketId}) requiring context to be authenticated but we are unauthenticated");
                }
            }
        }
    }
}