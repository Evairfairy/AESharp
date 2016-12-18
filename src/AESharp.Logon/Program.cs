using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Extensions;
using AESharp.Logon.Middleware;
using AESharp.Networking;
using AESharp.Routing.Core;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Handlers;
using AESharp.Routing.Networking.Packets.Handshaking;
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

            // Setup middleware

            // Register incoming middleware
            LogonServices.IncomingLogonMiddleware.RegisterMiddleware( new TestMiddleware() );

            // Register outgoing middleware
            LogonServices.OutgoingLogonMiddleware.RegisterMiddleware( new TestMiddleware() );

            // This must be second (after decryption)
            LogonServices.IncomingRoutingMiddlewareHandler.RegisterMiddleware( new AEPacketReaderMiddleware() );

            // This must be second-to-last (before encryption)
            LogonServices.OutgoingRoutingMiddlewareHandler.RegisterMiddleware( new AEPacketBuilderMiddleware() );

            LogonServices.InteropPacketHandler.ServerHandshakeResultHandler =
                HandshakeHandlers.ServerHandshakeResultHandler;

            LogonServices.InteropPacketHandler.ServerNewObjectAvailableHandler =
                ObjectHandlers.HandleServerNewObjectAvailable;
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

            ConnectToMasterRouterAsync( IPAddress.Loopback, 12000 ).RunAsync();

            TcpServer server = new TcpServer( new IPEndPoint( IPAddress.Loopback, 3724 ) );
            server.Start( AcceptClientActionAsync );

            Console.WriteLine( "Listening..." );
            Console.ReadLine();
        }

        private static async Task ConnectToMasterRouterAsync( IPAddress address, int port )
        {
            TcpClient routerClient = null;

            LogonServices.InteropConnectionManager.Connect( tcpClient => routerClient = tcpClient );

            AERoutingClient routingClient = new AERoutingClient( routerClient, LogonServices.InteropPacketHandler,
                LogonServices.IncomingRoutingMiddlewareHandler,
                LogonServices.OutgoingRoutingMiddlewareHandler,
                LogonServices.ObjectRepository );

            ClientHandshakeBeginPacket chbp = new ClientHandshakeBeginPacket
            {
                Protocol = Constants.LatestAEProtocolVersion,
                Password = "aesharp",
                Component = new RoutingComponent
                {
                    Type = ComponentType.UniversalAuthServer
                }
            };

            await routingClient.SendDataAsync( chbp.FinalizePacket() );

            await routingClient.ListenForDataTask();

            LogonServices.ObjectRepository.RemoveObject( routingClient.ClientGuid );
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