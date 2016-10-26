using AESharp.Networking.Data;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Packets;

namespace AESharp.MasterRouter
{
    public static class MasterRouterServices
    {
        public static AEPacketHandler<AERoutingClient> PacketHandler = new AEPacketHandler<AERoutingClient>();

        public static RemoteClientRepository<AERoutingClient> RemoteClients =
            new RemoteClientRepository<AERoutingClient>();
    }
}