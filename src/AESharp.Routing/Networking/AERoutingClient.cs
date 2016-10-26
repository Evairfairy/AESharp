using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Routing.Exceptions;
using AESharp.Routing.Networking.Packets;

namespace AESharp.Routing.Networking
{
    public class AERoutingClient : RemoteClient
    {
        private readonly AEPacketHandler<AERoutingClient> _handler;

        public AERoutingClient( TcpClient rawClient, AEPacketHandler<AERoutingClient> handler,
            CancellationTokenSource tokenSource ) : base( rawClient, tokenSource )
        {
            this._handler = handler;
        }

        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            try
            {
                // Read packet
                AEPacket packet = new AEPacket( data );

                await this._handler.HandlePacket( packet, this );
            }
            // Server sent an unknown packet id
            // This should never happen so rethrow
            catch ( UnhandledAEPacketException ex )
            {
                Console.WriteLine( ex );
                await this.Disconnect( TimeSpan.Zero );
                throw;
            }
            // Server sent a known packet id but we're not handling it
            catch ( UnregisteredAEHandlerException ex )
            {
                Console.WriteLine( ex );
            }
        }
    }
}