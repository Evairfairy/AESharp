using System;
using System.Threading.Tasks;
using AESharp.Routing.Exceptions;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking.Packets.Handshaking;

namespace AESharp.Routing.Networking.Packets
{
    public class AEPacketHandler<TPacketContext>
        where TPacketContext : AERoutingClient
    {
        private static readonly Func<AEPacket, TPacketContext, Task> NullHandler =
            ( packet, context ) => { throw new UnhandledAEPacketException( (int) packet.PacketId ); };

        public Func<ClientHandshakeBeginPacket, TPacketContext, Task> ClientHandshakeBeginHandler = NullHandler;
        public Func<ServerHandshakeResultPacket, TPacketContext, Task> ServerHandshakeResultHandler = NullHandler;

        public async Task HandlePacket( RoutingMetaPacket metaPacket, TPacketContext context )
        {
            AEPacket packet = new AEPacket( metaPacket );

            switch ( packet.PacketId )
            {
                case AEPacketId.ClientHandshakeBegin:
                    await this.ClientHandshakeBeginHandler( new ClientHandshakeBeginPacket( metaPacket ), context );
                    break;
                case AEPacketId.ServerHandshakeResult:
                    await this.ServerHandshakeResultHandler( new ServerHandshakeResultPacket( metaPacket ), context );
                    break;
            }
        }
    }
}