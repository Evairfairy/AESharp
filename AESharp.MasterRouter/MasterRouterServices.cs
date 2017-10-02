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
        public static readonly AEPacketHandler<AERoutingClient> PacketHandler = new AEPacketHandler<AERoutingClient>();

        public static readonly RemoteClientRepository<RoutingMetaPacket, AERoutingClient> RemoteClients =
            new RemoteClientRepository<RoutingMetaPacket, AERoutingClient>();

        public static readonly MiddlewareHandler<RoutingMetaPacket, AERoutingClient> IncomingMiddlewareHandler =
            new MiddlewareHandler<RoutingMetaPacket, AERoutingClient>();

        public static readonly MiddlewareHandler<RoutingMetaPacket, AERoutingClient> OutgoingMiddlewareHandler =
            new MiddlewareHandler<RoutingMetaPacket, AERoutingClient>();

        public static readonly ComponentRepository ObjectRepository = new ComponentRepository();
    }
}