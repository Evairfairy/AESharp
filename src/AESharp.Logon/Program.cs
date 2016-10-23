using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using AESharp.Networking;
using AESharp.Networking.Data;
using SimpleInjector;

namespace AESharp.Logon
{
    public static class Program
    {
        private static Container _container;

        public static void Main( string[] args )
        {
            _container = new Container();

            _container.Verify();

            TcpServer server = new TcpServer( new IPEndPoint( IPAddress.Loopback, 3724 ) );
            server.Start( AcceptClientActionAsync );

            TcpServer tempInteropServer = new TcpServer( new IPEndPoint( IPAddress.Loopback, 3725 ) );
            tempInteropServer.Start( AcceptInteropClientASync );

            Console.WriteLine( "Listening..." );
            Console.ReadLine();
        }

        private static async void AcceptInteropClientASync( TcpClient rawClient )
        {
            Console.WriteLine( "Accepted interop client" );
            InteropRemoteClient client = new InteropRemoteClient( rawClient, new CancellationTokenSource() );

            Guid interopGuid = Guid.Empty;
            try
            {
                interopGuid = LogonServices.InteropClients.AddClient( client );
                await client.ListenForDataTask( client.CancellationToken );
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Unhandled exception in {nameof( AcceptInteropClientASync )}: {ex}" );
            }
            finally
            {
                if ( interopGuid != Guid.Empty )
                {
                    LogonServices.InteropClients.RemoveClient( interopGuid );
                }
            }
        }

        private static async void AcceptClientActionAsync( TcpClient rawClient )
        {
            Console.WriteLine( "Accepting client" );
            LogonRemoteClient client = new LogonRemoteClient( rawClient, new CancellationTokenSource() );

            Guid clientGuid = Guid.Empty;
            try
            {
                clientGuid = LogonServices.LogonClients.AddClient( client );
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
                    LogonServices.LogonClients.RemoveClient( clientGuid );
                }
            }
        }
    }
}