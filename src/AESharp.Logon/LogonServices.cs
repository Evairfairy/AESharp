using AESharp.Logon.Repositories;
using AESharp.Networking.Data;
using AESharp.Networking.Middleware;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Packets;

namespace AESharp.Logon
{
    public static class LogonServices
    {
        public static AccountRepository Accounts = new AccountRepository();
        public static RealmRepository Realms = new RealmRepository();

        public static RemoteClientRepository<LogonRemoteClient> LogonClients =
            new RemoteClientRepository<LogonRemoteClient>();

        public static AEPacketHandler<AERoutingClient> InteropPacketHandler = new AEPacketHandler<AERoutingClient>();

        public static MiddlewareHandler<LogonRemoteClient> IncomingLogonMiddleware =
            new MiddlewareHandler<LogonRemoteClient>();

        public static MiddlewareHandler<LogonRemoteClient> OutgoingLogonMiddleware =
            new MiddlewareHandler<LogonRemoteClient>();
    }
}