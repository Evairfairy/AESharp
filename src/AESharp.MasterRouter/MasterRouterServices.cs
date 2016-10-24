using AESharp.MasterRouter.Networking;
using AESharp.Routing.Networking.Packets;

namespace AESharp.MasterRouter
{
    public static class MasterRouterServices
    {
        public static AEPacketHandler<AERemoteClient> PacketHandler = new AEPacketHandler<AERemoteClient>( true );
    }
}