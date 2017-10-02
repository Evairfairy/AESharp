using System.Threading.Tasks;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Middleware;
using AESharp.Routing.Extensions;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Middleware
{
    public class AEPacketBuilderMiddleware : IMiddleware<RoutingMetaPacket, AERoutingClient>
    {
        public async Task<RoutingMetaPacket> CallMiddlewareAsync( RoutingMetaPacket metaPacket, AERoutingClient context )
        {
            Packet packet = new Packet();

            packet.WriteGuid( metaPacket.Sender );
            packet.WriteGuid( metaPacket.Target );
            packet.WriteUInt16( (ushort) metaPacket.Payload.Length );
            packet.WritePacketId( metaPacket.PacketId );

            packet.WriteBytes( metaPacket.Payload );

            metaPacket.Payload = packet.FinalizePacket();

            return metaPacket;
        }
    }
}