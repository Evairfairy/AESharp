using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using AESharp.Networking.Events;
using AESharp.Networking.Interfaces;

namespace AESharp.Networking
{
    [Obsolete( "Reflection packet handling will be removed soon" )]
    public class NetworkClient : INetworkClient
    {
        private readonly INetworkEngine _networkEngine;
        private readonly IPacketSerializer _serializer;

        public NetworkClient( TcpClient baseClient, INetworkEngine engine, IPacketSerializer serializer )
        {
            this.BaseClient = baseClient;
            this._networkEngine = engine;
            this._serializer = serializer;
        }

        public TcpClient BaseClient { get; }

        public void SendPacket( IPacket packet )
        {
            Stream memory = new MemoryStream();
            this._serializer.SerializePacket( packet, memory, Encoding.UTF8 );

            if ( this._networkEngine != null )
            {
                memory = this._networkEngine.ProcessDataForSend( memory );
            }

            NetworkStream stream = this.BaseClient.GetStream();
            memory.CopyTo( stream );
            stream.Flush();
        }

        public event EventHandler<NetworkEventArgs> ReceiveData;

        public void Disconnect()
        {
            this.BaseClient.Client.Shutdown( SocketShutdown.Both );
            this.BaseClient.Dispose();
        }

        public async void HandleIncomingPackets()
        {
            NetworkStream stream = this.BaseClient.GetStream();
            while ( this.BaseClient.Connected )
            {
                byte[] buffer = new byte[TcpServer.BufferSize];
                int amountRead = await stream.ReadAsync( buffer, 0, TcpServer.BufferSize );

                // Shrink the array is the amount read is smaller than the buffer
                if ( amountRead < TcpServer.BufferSize )
                {
                    Array.Resize( ref buffer, amountRead );
                }

                Stream memory = new MemoryStream( buffer );

                if ( this._networkEngine != null )
                {
                    memory = this._networkEngine.ProcessDataForReceive( memory );
                }

                NetworkEventArgs args = new NetworkEventArgs( this, memory );
                this.ReceiveData?.Invoke( this, args );
            }
        }
    }
}