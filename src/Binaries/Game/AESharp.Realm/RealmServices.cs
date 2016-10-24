using AESharp.Networking.Data;
using AESharp.Realm.Networking;

namespace AESharp.Realm
{
    public static class RealmServices
    {
        public static RemoteClientRepository<RealmRemoteClient> RemoteClients =
            new RemoteClientRepository<RealmRemoteClient>();
    }
}