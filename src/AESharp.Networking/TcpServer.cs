using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
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

        public bool IsListening { get; private set; }
        public IPEndPoint LocalEndPoint { get; }

        public TcpServer( IPAddress address, ushort port, INetworkEngine engine, IPacketSerializer serializer )
            : this( new IPEndPoint( address, port ), engine, serializer ) { }

        public TcpServer( IPEndPoint endPoint, INetworkEngine engine, IPacketSerializer serializer )
        {
            this.LocalEndPoint = endPoint;
            this._listener = new TcpListener( endPoint );
            this._networkEngine = engine;
            this._serializer = serializer;
        }

        public void Start()
        {
            this._listener.Start();
            this.IsListening = true;
            this.ListenForConnections();
        }

        public void Stop()
        {
            this._listener.Stop();
            this.IsListening = false;
        }

        private async void ListenForConnections()
        {
            while( this.IsListening )
            {
                NetworkEventArgs args = null;
                TcpClient client = null;

                try
                {
                    client = await this._listener.AcceptTcpClientAsync();
                    var aeClient = new NetworkClient( client, this._networkEngine, this._serializer );

                    args = new NetworkEventArgs( aeClient, null );
                    this.ClientConnecting?.Invoke( this, args );

                    var stream = client.GetStream();
                    var buffer = new byte[BufferSize];
                    var amountRead = await stream.ReadAsync( buffer, 0, BufferSize );

                    // Shrink the array is the amount read is smaller than the buffer
                    if( amountRead < BufferSize )
                        Array.Resize( ref buffer, amountRead );

                    Stream memory = new MemoryStream( buffer );

                    if( this._networkEngine != null )
                        memory = this._networkEngine.ProcessDataForReceive( memory );

                    args = new NetworkEventArgs( aeClient, memory );
                    this.ReceiveData?.Invoke( this, args );
                }
                catch { }
                finally
                {
                    if( args?.DisconnectClient == true )
                    {
                        client?.Client.Shutdown( SocketShutdown.Both );
                        client?.Dispose();
                        this.ClientDisconnected?.Invoke( this, args );
                    }
                }
            }
        }

        public static async Task<IPAddress> ResolveIPAddress( string value )
        {
            IPAddress address;
            if( IPAddress.TryParse( value, out address ) )
                return address;

            IPAddress[] addresses = await Dns.GetHostAddressesAsync( value );
            return addresses[0];
        }

        public event EventHandler<NetworkEventArgs> ClientConnecting;
        public event EventHandler<NetworkEventArgs> ReceiveData;
        public event EventHandler<NetworkEventArgs> ClientDisconnected;
    }
}
