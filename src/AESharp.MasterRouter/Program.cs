using System;
using System.Net;
using System.Net.Sockets;
using AESharp.Networking;
using AESharp.Routing.Networking;

namespace AESharp.MasterRouter
{
    public class Program
    {
        public static void Main( string[] args )
        {
            TcpServer server = new TcpServer( new IPEndPoint( IPAddress.Loopback, 12000 ) );
            server.Start( AcceptAEClientAsync );

            Console.ReadLine();
        }

        private static async void AcceptAEClientAsync( TcpClient rawClient )
        {
            Console.WriteLine( "Accepting AEClient" );
            AERoutingClient client = new AERoutingClient( rawClient, MasterRouterServices.PacketHandler );

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