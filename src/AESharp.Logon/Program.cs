using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Networking;
using AESharp.Routing.Networking;
using SimpleInjector;

namespace AESharp.Logon
{
    // ReSharper disable once UnusedMember.Global
    public static class Program
    {
        private static Container _container;

        private static void Setup()
        {
            _container = new Container();

            _container.Verify();
        }

        // ReSharper disable once UnusedMember.Global
        public static void Main( string[] args )
        {
            try
            {
                Setup();
            }
            catch ( Exception ex )
            {
                Console.WriteLine( ex );
                Console.ReadLine();
                return;
            }

            //ConnectToMasterRouterAsync( IPAddress.Loopback, 12000 ).Wait();

            TcpServer server = new TcpServer( new IPEndPoint( IPAddress.Loopback, 3724 ) );
            server.Start( AcceptClientActionAsync );

            Console.WriteLine( "Listening..." );
            Console.ReadLine();
        }

        private static async Task ConnectToMasterRouterAsync( IPAddress address, int port )
        {
            TcpClient client = new TcpClient();
            await client.ConnectAsync( address, port );

            AERoutingClient routingClient = new AERoutingClient( client, LogonServices.InteropPacketHandler );
        }

        private static async void AcceptClientActionAsync( TcpClient rawClient )
        {
            Console.WriteLine( "Accepting client" );
            LogonRemoteClient client = new LogonRemoteClient( rawClient );

            Guid clientGuid = Guid.Empty;
            try
            {
                clientGuid = LogonServices.LogonClients.AddClient( client );
                await client.ListenForDataTask();
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Unhandled exception in {nameof( AcceptClientActionAsync )}: {ex}" );
            }
            finally
            {
                if ( clientGuid != Guid.Empty )
                {
                    LogonServices.LogonClients.RemoveClient( clientGuid );
                }
            }
        }
    }
}