using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Routing.Exceptions;
using AESharp.Routing.Networking;

namespace AESharp.MasterRouter.Networking
{
    public class AERemoteClient : RemoteClient
    {
        public AERemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
            : base( rawClient, tokenSource )
        {
        }

        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            try
            {
                // Read packet
                AEPacket packet = new AEPacket( data );

                if ( token.IsCancellationRequested )
                {
                    return;
                }

                await MasterRouterServices.PacketHandler.HandlePacket( packet, this );
            }
            // Client sent an unknown packet id
            catch ( UnhandledAEPacketException ex )
            {
                Console.WriteLine( ex );
                await this.Disconnect( TimeSpan.Zero );
            }
            // Client sent a known packet id but we're not handling it
            catch ( UnregisteredAEHandlerException ex )
            {
                Console.WriteLine( ex );
            }
        }
    }
}