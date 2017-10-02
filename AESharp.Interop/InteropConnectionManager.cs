using System;
using System.Net;
using System.Net.Sockets;

namespace AESharp.Interop
{
    public class InteropConnectionManager
    {
        private readonly IPEndPoint _masterRouterEndPoint;
        private TcpClient _client;

        public bool Connected => _client.Connected;

        public InteropConnectionManager(IPEndPoint masterRouterEndPoint)
        {
            _masterRouterEndPoint = masterRouterEndPoint;
            _client = new TcpClient();
        }

        public InteropConnectionManager(IPAddress address, int port) :
            this(new IPEndPoint(address, port))
        {
        }

        public InteropConnectionManager(string address, int port)
            : this(IPAddress.Parse(address), port)
        {
        }

        public bool Connect(Action<TcpClient> callback = null, int attempts = 0)
        {
            if (Connected)
                return Connected;

            for (var i = 0; i < attempts || attempts == 0; ++i)
            {
                _client = new TcpClient();

                try
                {
                    _client
                        .ConnectAsync(_masterRouterEndPoint.Address, _masterRouterEndPoint.Port)
                        .Wait();

                    if (Connected)
                    {
                        callback?.Invoke(_client);

                        return Connected;
                    }

                    throw new AggregateException();
                }
                catch (AggregateException)
                {
                    _client.Dispose();
                    Console.WriteLine($"Failed to connect to the Master Router ({i + 1} attempts)");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"{ex}");
                }
            }

            return Connected;
        }
    }
}