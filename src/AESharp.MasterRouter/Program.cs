using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using AESharp.MasterRouter.Networking;
using AESharp.Networking;
using AESharp.Routing.Exceptions;

namespace AESharp.MasterRouter
{
    public class Program
    {
        public static void Main( string[] args )
        {
            try
            {
                MasterRouterServices.PacketHandler.ThrowIfRequiredHandlerNotRegistered();
            }
            catch ( UnregisteredAEHandlerException ex )
            {
                Console.WriteLine( ex.Message );
            }

            TcpServer server = new TcpServer( new IPEndPoint( IPAddress.Loopback, 12000 ) );
            server.Start( AcceptAEClientAsync );

            Console.ReadLine();
        }

        private static async void AcceptAEClientAsync( TcpClient rawClient )
        {
            Console.WriteLine( "Accepting AEClient" );
            AERemoteClient client = new AERemoteClient( rawClient, new CancellationTokenSource() );

            Guid clientGuid = Guid.Empty;
            try
            {
                clientGuid = MasterRouterServices.RemoteClients.AddClient( client );
                await client.ListenForDataTask( client.CancellationToken );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Unhandled exception in {nameof( AcceptAEClientAsync )}: {ex}" );
            }
            finally
            {
                if ( clientGuid != Guid.Empty )
                {
                    MasterRouterServices.RemoteClients.RemoveClient( clientGuid );
                }
            }

            await client.Disconnect( TimeSpan.Zero );
        }
    }
}