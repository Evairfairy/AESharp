using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Extensions;
using AESharp.Core.Interfaces;
using AESharp.Core.Interfaces.Networking;
using AESharp.Networking.Events;
using AESharp.Networking.Interfaces;

namespace AESharp.Networking
{
    public sealed class TcpServer : IEventedNetworkServer, IReceivesData
    {
        public const ushort BufferSize = 4 * 1024; // 4kb

        private readonly TcpListener _listener;
        private readonly INetworkEngine _networkEngine;
        private readonly IPacketSerializer _serializer;

        public TcpServer( IPAddress address, ushort port, INetworkEngine engine, IPacketSerializer serializer )
            : this( new IPEndPoint( address, port ), engine, serializer )
        {
        }

        public TcpServer( IPEndPoint endPoint, INetworkEngine engine, IPacketSerializer serializer )
        {
            this.LocalEndPoint = endPoint;
            this._listener = new TcpListener( endPoint );
            this._networkEngine = engine;
            this._serializer = serializer;
        }

        public bool IsListening { get; private set; }
        public IPEndPoint LocalEndPoint { get; }

        public event EventHandler<NetworkEventArgs> ClientConnecting;
        public event EventHandler<NetworkEventArgs> ClientDisconnected;
        public event EventHandler<NetworkEventArgs> ReceiveData;

        public void Start()
        {
            this._listener.Start();
            this.IsListening = true;
            this.ListenForConnections().RunAsync();
        }

        public void Stop()
        {
            this._listener.Stop();
            this.IsListening = false;
        }

        private async Task ListenForConnections()
        {
            while ( this.IsListening )
            {
                TcpClient rawClient = await this._listener.AcceptTcpClientAsync();
                NetworkClient aeClient = new NetworkClient( rawClient, this._networkEngine, this._serializer );
                
                this.ClientLoop( aeClient ).RunAsync();
            }
        }

        private async Task ClientLoop( NetworkClient client )
        {
            try
            {
                NetworkEventArgs clientConnectArgs = new NetworkEventArgs( client, null );
                this.ClientConnecting?.Invoke( this, clientConnectArgs );

                if ( clientConnectArgs.DisconnectClient )
                {
                    return;
                }

                NetworkStream ns = client.BaseClient.GetStream();

                while ( true )
                {
                    byte[] buffer = new byte[BufferSize];
                    int bytesRead = await ns.ReadAsync( buffer, 0, buffer.Length );
                    Array.Resize( ref buffer, bytesRead );

                    MemoryStream memoryStream = new MemoryStream( buffer );

                    this._networkEngine?.ProcessDataForReceive( memoryStream );
                    NetworkEventArgs args = new NetworkEventArgs( client, memoryStream );
                    this.ReceiveData?.Invoke( this, args );

                    if ( args.DisconnectClient )
                    {
                        break;
                    }
                }
            }
            finally
            {
                NetworkEventArgs args = new NetworkEventArgs( client, Stream.Null );
                this.ClientDisconnected?.Invoke( this, args );
                client?.BaseClient.Client.Shutdown( SocketShutdown.Both );
                client?.BaseClient.Dispose();
            }
        }

        public static async Task<IPAddress> ResolveIPAddress( string value )
        {
            IPAddress address;
            if ( IPAddress.TryParse( value, out address ) )
            {
                return address;
            }

            IPAddress[] addresses = await Dns.GetHostAddressesAsync( value );
            return addresses[0];
        }
    }
}