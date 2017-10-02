using AESharp.Networking.Middleware;
using AESharp.Routing.Core;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Packets;

namespace AESharp.Database
{
    internal static class DatabaseServices
    {
        public static readonly AEPacketHandler<AERoutingClient> InteropPacketHandler =
            new AEPacketHandler<AERoutingClient>();

        public static readonly MiddlewareHandler<RoutingMetaPacket, AERoutingClient> IncomingRoutingMiddlewareHandler =
            new MiddlewareHandler<RoutingMetaPacket, AERoutingClient>();

        public static readonly MiddlewareHandler<RoutingMetaPacket, AERoutingClient> OutgoingRoutingMiddlewareHandler =
            new MiddlewareHandler<RoutingMetaPacket, AERoutingClient>();

        public static readonly ComponentRepository ObjectRepository = new ComponentRepository();
    }
}