using AESharp.Logon.Repositories;
using AESharp.Logon.Universal.Networking.Middleware;
using AESharp.Networking.Data;
using AESharp.Networking.Middleware;
using AESharp.Routing.Core;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Packets;

namespace AESharp.Logon
{
    public static class LogonServices
    {
        public static readonly AccountRepository Accounts = new AccountRepository();
        public static readonly RealmRepository Realms = new RealmRepository();

        public static readonly RemoteClientRepository<LogonMetaPacket, LogonRemoteClient> LogonClients =
                new RemoteClientRepository<LogonMetaPacket, LogonRemoteClient>();

        public static readonly AEPacketHandler<AERoutingClient> InteropPacketHandler =
                new AEPacketHandler<AERoutingClient>();

        public static readonly MiddlewareHandler<LogonMetaPacket, LogonRemoteClient> IncomingLogonMiddleware =
                new MiddlewareHandler<LogonMetaPacket, LogonRemoteClient>();

        public static readonly MiddlewareHandler<LogonMetaPacket, LogonRemoteClient> OutgoingLogonMiddleware =
                new MiddlewareHandler<LogonMetaPacket, LogonRemoteClient>();


        public static readonly MiddlewareHandler<RoutingMetaPacket, AERoutingClient> IncomingRoutingMiddlewareHandler =
                new MiddlewareHandler<RoutingMetaPacket, AERoutingClient>();

        public static readonly MiddlewareHandler<RoutingMetaPacket, AERoutingClient> OutgoingRoutingMiddlewareHandler =
                new MiddlewareHandler<RoutingMetaPacket, AERoutingClient>();

        public static readonly ComponentRepository ObjectRepository = new ComponentRepository();
    }
}