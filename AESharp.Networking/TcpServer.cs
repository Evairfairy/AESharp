using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Extensions;

namespace AESharp.Networking
{
    public sealed class TcpServer
    {
        private TcpListener _listener;

        public bool IsListening { get; private set; }
        public IPEndPoint LocalEndPoint { get; }

        public TcpServer(IPEndPoint localEndPoint)
        {
            LocalEndPoint = localEndPoint;
        }

        public void Start(Action<TcpClient> acceptClientAction)
        {
            _listener = new TcpListener(LocalEndPoint);
            _listener.Start();

            IsListening = true;
            ListenForConnections(acceptClientAction).RunAsync();
        }

        public void Stop()
        {
            _listener.Stop();
            IsListening = false;
        }

        private async Task ListenForConnections(Action<TcpClient> acceptClientAction)
        {
            while (IsListening)
            {
                var client = await _listener.AcceptTcpClientAsync();
                Task.Run(() => acceptClientAction(client)).RunAsync();
            }
        }
    }
}