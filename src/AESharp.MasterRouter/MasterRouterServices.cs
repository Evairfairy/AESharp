using AESharp.Networking.Data;
using AESharp.Networking.Middleware;
using AESharp.Routing.Core;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Packets;

namespace AESharp.MasterRouter
{
    public static class MasterRouterServices
    {
        public static AEPacketHandler<AERoutingClient> PacketHandler = new AEPacketHandler<AERoutingClient>();

        public static RemoteClientRepository<RoutingMetaPacket, AERoutingClient> RemoteClients =
            new RemoteClientRepository<RoutingMetaPacket, AERoutingClient>();

        public static MiddlewareHandler<RoutingMetaPacket, AERoutingClient> IncomingMiddlewareHandler =
            new MiddlewareHandler<RoutingMetaPacket, AERoutingClient>();

        public static MiddlewareHandler<RoutingMetaPacket, AERoutingClient> OutgoingMiddlewareHandler =
            new MiddlewareHandler<RoutingMetaPacket, AERoutingClient>();

        public static ComponentRepository ObjectRepository = new ComponentRepository();
    }
}