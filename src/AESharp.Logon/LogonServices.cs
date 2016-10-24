using AESharp.Logon.Repositories;
using AESharp.Networking.Data;

namespace AESharp.Logon
{
    public static class LogonServices
    {
        public static AccountRepository Accounts = new AccountRepository();
        public static RealmRepository Realms = new RealmRepository();

        public static RemoteClientRepository<LogonRemoteClient> LogonClients =
            new RemoteClientRepository<LogonRemoteClient>();

        public static RemoteClientRepository<InteropRemoteClient> InteropClients =
            new RemoteClientRepository<InteropRemoteClient>();
    }
}