using AESharp.Logon.Repositories;
using AESharp.Logon.Universal.Networking.Middleware;
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

        public static RemoteClientRepository<LogonMetaPacket, LogonRemoteClient> LogonClients =
            new RemoteClientRepository<LogonMetaPacket, LogonRemoteClient>();

        public static AEPacketHandler<AERoutingClient> InteropPacketHandler = new AEPacketHandler<AERoutingClient>();

        public static MiddlewareHandler<LogonMetaPacket, LogonRemoteClient> IncomingLogonMiddleware =
            new MiddlewareHandler<LogonMetaPacket, LogonRemoteClient>();

        public static MiddlewareHandler<LogonMetaPacket, LogonRemoteClient> OutgoingLogonMiddleware =
            new MiddlewareHandler<LogonMetaPacket, LogonRemoteClient>();
    }
}