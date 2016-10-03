using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Interfaces.Networking;
using AESharp.Networking.Events;
using AESharp.Networking.Interfaces;

namespace AESharp.Networking
{
    public class AETcpServer : IEventedNetworkServer
    {
        private readonly INetworkEngine _networkEngine;
        private TcpListener _listener;

        public AETcpServer( INetworkEngine networkEngine )
        {
            this._networkEngine = networkEngine;
        }

        public IPAddress BindAddress { get; set; }
        public int Port { get; private set; }

        public bool Running { get; set; }

        public event EventHandler<NetworkEventArgs> ClientConnecting;
        public event EventHandler<NetworkEventArgs> ClientConnected;
        public event EventHandler<NetworkEventArgs> ReceiveData;
        public event EventHandler<NetworkEventArgs> ClientDisconnected;

        public void StartListening( IPAddress bindAddress, int port )
        {
            this.BindAddress = bindAddress;
            this.Port = port;

            this._listener = new TcpListener( bindAddress, port );
            this._listener.Start();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            this.ListenLoopTask();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        public void StopListening()
        {
            this._listener.Stop();
        }

        public async Task ListenLoopTask()
        {
            this.Running = true;

            while ( this.Running )
            {
                TcpClient client = await this._listener.AcceptTcpClientAsync();

#pragma warning disable 4014
                this.AcceptClientTask( client );
#pragma warning restore 4014
            }
        }

        public async Task AcceptClientTask( TcpClient rawClient )
        {
            AENetworkClient aeClient = new AENetworkClient( rawClient );

            try
            {
                NetworkEventArgs networkEventArgs = new NetworkEventArgs( aeClient, null );

                this.ClientConnecting?.Invoke( this, networkEventArgs );

                if ( networkEventArgs.DisconnectClient )
                {
                    return;
                }

                this.ClientConnected?.Invoke( this, networkEventArgs );

                if ( networkEventArgs.DisconnectClient )
                {
                    return;
                }

                // If we're here, we've accepted the client without issue

                NetworkStream ns = aeClient.BaseClient.GetStream();
                byte[] buffer = new byte[2048];

                while ( aeClient.BaseClient.Connected )
                {
                    int bytesRead = await ns.ReadAsync( buffer, 0, 2048 );
                    byte[] splicedBuffer = new byte[bytesRead];

                    Array.Copy( buffer, 0, splicedBuffer, 0, bytesRead );

                    NetworkEventArgs receiveDataArgs = new NetworkEventArgs( aeClient, new MemoryStream( splicedBuffer ) );

                    if ( this.ReceiveData != null )
                    {
                        this._networkEngine.ProcessDataForReceive( receiveDataArgs );
                        this.ReceiveData.Invoke( this, receiveDataArgs );
                    }

                    if ( bytesRead == 0 )
                    {
                        Console.WriteLine( $"Client has closed the remote connection" );
                        break;
                    }

                    if ( receiveDataArgs.DisconnectClient )
                    {
                        Console.WriteLine( $"Kicking client" );
                        break;
                    }
                }
            }
            finally
            {
                Console.WriteLine( "Disconnecting" );
                this.ClientDisconnected?.Invoke( this, new NetworkEventArgs( aeClient, null ) );
                aeClient.BaseClient.Dispose();
            }
        }
    }
}