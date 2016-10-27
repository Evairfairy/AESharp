using System;
using System.Net;
using System.Net.Sockets;
using AESharp.Networking;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Handlers;

namespace AESharp.MasterRouter
{
    public class Program
    {
        private static void Setup()
        {
            // This must be second (after decryption)
            MasterRouterServices.IncomingMiddlewareHandler.RegisterMiddleware( new AEPacketReaderMiddleware() );

            // This must be second-to-last (before encryption)
            MasterRouterServices.OutgoingMiddlewareHandler.RegisterMiddleware( new AEPacketBuilderMiddleware() );

            // Packet handlers
            MasterRouterServices.PacketHandler.ClientHandshakeBeginHandler =
                HandshakeHandlers.ClientHandshakeBeginHandler;
        }

        public static void Main( string[] args )
        {
            Setup();

            TcpServer server = new TcpServer( new IPEndPoint( IPAddress.Loopback, 12000 ) );
            server.Start( AcceptAEClientAsync );

            Console.ReadLine();
        }

        private static async void AcceptAEClientAsync( TcpClient rawClient )
        {
            Console.WriteLine( "Accepting AEClient" );
            AERoutingClient client = new AERoutingClient( rawClient, MasterRouterServices.PacketHandler,
                MasterRouterServices.IncomingMiddlewareHandler, MasterRouterServices.OutgoingMiddlewareHandler );

            Guid clientGuid = Guid.Empty;
            try
            {
                clientGuid = MasterRouterServices.RemoteClients.AddClient( client );
                await client.ListenForDataTask();
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

            client.Disconnect();
        }
    }
}