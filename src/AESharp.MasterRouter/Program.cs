using System;
using System.Net;
using System.Net.Sockets;
using AESharp.MasterRouter.PacketHandlers;
using AESharp.Networking;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking;

namespace AESharp.MasterRouter
{
    public class Program
    {
        static Program()
        {
            // This must be second (after decryption)
            MasterRouterServices.IncomingMiddlewareHandler.RegisterMiddleware( new AEPacketReaderMiddleware() );

            // This must be second-to-last (before encryption)
            MasterRouterServices.OutgoingMiddlewareHandler.RegisterMiddleware( new AEPacketBuilderMiddleware() );

            // Packet handlers
            MasterRouterServices.PacketHandler.ClientHandshakeBeginHandler =
                    ClientHandshakeBeginHandler.HandleClientHandshakeBegin;
        }

        public static void Main( string[] args )
        {
            TcpServer server = new TcpServer( new IPEndPoint( IPAddress.Loopback, 12000 ) );
            server.Start( AcceptAEClientAsync );

            Console.ReadLine();
        }

        private static async void AcceptAEClientAsync( TcpClient rawClient )
        {
            Console.WriteLine( "Accepting AEClient" );
            AERoutingClient client = new AERoutingClient( rawClient, MasterRouterServices.PacketHandler,
                                                          MasterRouterServices.IncomingMiddlewareHandler,
                                                          MasterRouterServices.OutgoingMiddlewareHandler,
                                                          MasterRouterServices.ObjectRepository );

            try
            {
                await client.ListenForDataTask();
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Unhandled exception in {nameof( AcceptAEClientAsync )}: {ex}" );
            }
            finally
            {
                if ( client.ClientGuid != Guid.Empty )
                {
                    MasterRouterServices.ObjectRepository.RemoveObject( client.ClientGuid );
                    MasterRouterServices.RemoteClients.RemoveClient( client.ClientGuid );
                }
            }

            client.Disconnect();
        }
    }
}