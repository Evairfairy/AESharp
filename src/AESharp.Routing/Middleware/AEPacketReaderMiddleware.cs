using System.Threading.Tasks;
using AESharp.Networking.Middleware;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Middleware
{
    public class AEPacketReaderMiddleware : IMiddleware<RoutingMetaPacket, AERoutingClient>
    {
        public Task<RoutingMetaPacket> CallMiddlewareAsync( RoutingMetaPacket packet, AERoutingClient context )
        {
            AEPacketHeader header = new AEPacketHeader( packet.Payload );

            packet.Sender = header.Sender;
            packet.Target = header.Target;
            packet.PacketId = header.Id;
            packet.Payload = header.Payload;

            return Task.FromResult(packet);
        }
    }
}