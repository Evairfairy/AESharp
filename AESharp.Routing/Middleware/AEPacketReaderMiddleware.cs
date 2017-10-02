using System.Threading.Tasks;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Middleware;
using AESharp.Routing.Extensions;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Middleware
{
    public class AEPacketReaderMiddleware : IMiddleware<RoutingMetaPacket, AERoutingClient>
    {
        public Task<RoutingMetaPacket> CallMiddlewareAsync(RoutingMetaPacket metaPacket, AERoutingClient context)
        {
            Packet packet = new Packet(metaPacket.Payload);

            metaPacket.Sender = packet.ReadGuid();
            metaPacket.Target = packet.ReadGuid();
            metaPacket.Size = packet.ReadUInt16();
            metaPacket.PacketId = packet.ReadPacketId();

            metaPacket.Payload = packet.ReadRemainingBytes();

            return Task.FromResult(metaPacket);
        }
    }
}