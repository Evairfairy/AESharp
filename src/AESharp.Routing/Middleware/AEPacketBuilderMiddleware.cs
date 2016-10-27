using System.Threading.Tasks;
using AESharp.Networking.Middleware;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Middleware
{
    public class AEPacketBuilderMiddleware : IMiddleware<RoutingMetaPacket, AERoutingClient>
    {
        public async Task<RoutingMetaPacket> CallMiddlewareAsync( RoutingMetaPacket packet, AERoutingClient context )
        {
            AEPacketHeader header = new AEPacketHeader( packet.Sender, packet.Target, packet.PacketId, packet.Data );

            packet.Data = header.FinalizePacket();

            return packet;
        }
    }
}