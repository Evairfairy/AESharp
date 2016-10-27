using AESharp.Networking.Data;
using AESharp.World.Networking;
using AESharp.World.Networking.Middleware;

namespace AESharp.World
{
    public static class RealmServices
    {
        public static RemoteClientRepository<RealmMetaPacket, RealmRemoteClient> RemoteClients =
                new RemoteClientRepository<RealmMetaPacket, RealmRemoteClient>();
    }
}