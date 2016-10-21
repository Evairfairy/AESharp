using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AESharp.Core.Interfaces;
using AESharp.Core.Interfaces.Networking;
using AESharp.Networking.Events;
using AESharp.Networking.Interfaces;
using AESharp.Networking.Packets;

namespace AESharp.Networking
{
    public class NetworkClient : IReceivesData
    {
        private readonly INetworkEngine _networkEngine;
        private readonly IPacketSerializer _serializer;

        public TcpClient BaseClient { get; }

        public NetworkClient( TcpClient baseClient, INetworkEngine engine, IPacketSerializer serializer )
        {
            this.BaseClient = baseClient;
            this._networkEngine = engine;
            this._serializer = serializer;
        }

        public void SendPacket( IPacket packet )
        {
            Stream memory = new MemoryStream();
            this._serializer.SerializePacket( packet, memory, Encoding.UTF8 );

            if( this._networkEngine != null )
                memory = this._networkEngine.ProcessDataForSend( memory );

            var stream = this.BaseClient.GetStream();
            memory.CopyTo( stream );
            stream.Flush();
        }

        public void Disconnect()
        {
            this.BaseClient.Client.Shutdown( SocketShutdown.Both );
            this.BaseClient.Dispose();
        }

        public async void HandleIncomingPackets()
        {
            var stream = this.BaseClient.GetStream();
            while( this.BaseClient.Connected )
            {
                byte[] buffer = new byte[TcpServer.BufferSize];
                var amountRead = await stream.ReadAsync( buffer, 0, TcpServer.BufferSize );

                // Shrink the array is the amount read is smaller than the buffer
                if( amountRead < TcpServer.BufferSize )
                    Array.Resize( ref buffer, amountRead );

                Stream memory = new MemoryStream( buffer );

                if( this._networkEngine != null )
                    memory = this._networkEngine.ProcessDataForReceive( memory );

                var args = new NetworkEventArgs( this, memory );
                this.ReceiveData?.Invoke( this, args );
            }
        }

        public event EventHandler<NetworkEventArgs> ReceiveData;
    }
}