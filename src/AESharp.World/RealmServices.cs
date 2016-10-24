using AESharp.Networking.Data;
using AESharp.World.Networking;

namespace AESharp.World
{
    public static class RealmServices
    {
        public static RemoteClientRepository<RealmRemoteClient> RemoteClients =
            new RemoteClientRepository<RealmRemoteClient>();
    }
}