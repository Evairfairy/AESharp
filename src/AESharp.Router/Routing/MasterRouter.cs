using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Networking;
using AESharp.Networking.Data;
using AESharp.Router.Protocol;
using AESharp.Router.Routing.Components;

namespace AESharp.Router.Routing
{
    public sealed class MasterRouter
    {
        private static readonly RemoteClientRepository<RemoteClient> ClientRepository;
        private static readonly RemoteClientRepository<DatabaseComponent> DatabaseRepository;

        private readonly TcpServer _server;

        static MasterRouter()
        {
            ClientRepository = new RemoteClientRepository<RemoteClient>();
            DatabaseRepository = new RemoteClientRepository<DatabaseComponent>();
        }

        internal MasterRouter()
        {
            // Client-mode constructor
        }

        // Server-mode constructor
        internal MasterRouter( IPAddress address )
        {
            this._server = new TcpServer( new IPEndPoint( IPAddress.Loopback, RoutingRemoteClient.RoutingPort ) );
        }

        internal void Start()
                => this._server.Start( AcceptClientActionAsync );

        internal async Task Stop()
        {
            DisconnectPacket packet = new DisconnectPacket( "Master router shutting down" );
            foreach ( RemoteClient client in ClientRepository.GetAllClients() )
            {
                await client.SendPacketAsync( packet );
                await client.Disconnect( TimeSpan.FromMilliseconds( 100 ) );
            }

            ClientRepository.RemoveAllClients();
        }

        private static async void AcceptClientActionAsync( TcpClient rawClient )
        {
            RoutingRemoteClient client = new RoutingRemoteClient( rawClient, new CancellationTokenSource() );
            Guid clientGuid = Guid.Empty;

            try
            {
                clientGuid = ClientRepository.AddClient( client );
                await client.ListenForDataTask( client.CancellationToken );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Unhandled exception in {nameof( AcceptClientActionAsync )}: {ex}" );
            }
            finally
            {
                if ( clientGuid != Guid.Empty )
                {
                    ClientRepository.RemoveClient( clientGuid );
                }
            }
        }
    }
}