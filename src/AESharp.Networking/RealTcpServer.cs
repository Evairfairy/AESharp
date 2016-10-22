using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Extensions;

namespace AESharp.Networking
{
    public sealed class RealTcpServer
    {
        public const int BufferSize = 4096;
        private TcpListener _listener;

        public RealTcpServer( IPEndPoint localEndPoint )
        {
            this.LocalEndPoint = localEndPoint;
        }

        public bool IsListening { get; private set; }
        public IPEndPoint LocalEndPoint { get; }

        public void Start( Action<TcpClient> acceptClientAction )
        {
            this._listener = new TcpListener( this.LocalEndPoint );
            this._listener.Start();

            this.IsListening = true;
            this.ListenForConnections( acceptClientAction ).RunAsync();
        }

        public void Stop()
        {
            this._listener.Stop();
            this.IsListening = false;
        }

        private async Task ListenForConnections( Action<TcpClient> acceptClientAction )
        {
            while ( this.IsListening )
            {
                TcpClient client = await this._listener.AcceptTcpClientAsync();
                Task.Run( () => acceptClientAction( client ) ).RunAsync();
            }
        }
    }
}