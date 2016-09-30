using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AESharp.Networking.Events;
using AESharp.Networking.Interfaces;

namespace AESharp.Networking
{
    public class AETcpServer : IEventedNetworkServer
    {
        public IPAddress BindAddress { get; set; }
        public int Port { get; private set; }

        private TcpListener _listener;

        public AETcpServer(IPAddress bindAddress, int port)
        {
            BindAddress = bindAddress;
            Port = port;

            _listener = new TcpListener(bindAddress, port);
        }

        public void StartListening()
        {
            _listener.Start();

#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            ListenLoopTask();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
        }

        public void StopListening()
        {
            _listener.Stop();
        }

        public async Task ListenLoopTask()
        {
            Running = true;

            while (Running)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();

#pragma warning disable 4014
                AcceptClientTask(client);
#pragma warning restore 4014
            }
        }

        public void AcceptClientTask(TcpClient rawClient)
        {
            AENetworkClient aeClient = new AENetworkClient(rawClient);

            try
            {
                NetworkEventArgs networkEventArgs = new NetworkEventArgs(aeClient, null, false);

                ClientConnecting?.Invoke(this, networkEventArgs);

                if (networkEventArgs.Cancel)
                {
                    return;
                }

                ClientConnected?.Invoke(this, networkEventArgs);

                if (networkEventArgs.Cancel)
                {
                    return;
                }

                // If we're here, we've accepted the client without issue

                NetworkStream ns = aeClient.BaseClient.GetStream();
                //byte[] buffer = new byte[2048];

                while (aeClient.BaseClient.Connected)
                {
                    //int bytesRead = await ns.ReadAsync(buffer, 0, 2048);
                    //byte[] splicedBuffer = new byte[bytesRead];

                    //Array.Copy(buffer, 0, splicedBuffer, 0, bytesRead);

                    //Console.WriteLine($"Read {bytesRead} bytes from client");

                    NetworkEventArgs receiveDataArgs = new NetworkEventArgs(aeClient, ns, false);

                    ReceiveData?.Invoke(this, receiveDataArgs);

                    //if (bytesRead == 0)
                    //{
                    //    Console.WriteLine($"Client has closed the remote connection");
                    //    break;
                    //}

                    if (receiveDataArgs.Cancel)
                    {
                        Console.WriteLine($"Kicking client");
                        break;
                    }
                }

            }
            finally
            {
                Console.WriteLine("Disconnecting");
                ClientDisconnected?.Invoke(this, new NetworkEventArgs(aeClient, null, false));
                aeClient.BaseClient.Dispose();
            }
        }

        public bool Running { get; set; }

        public event EventHandler<NetworkEventArgs> ClientConnecting;
        public event EventHandler<NetworkEventArgs> ClientConnected;
        public event EventHandler<NetworkEventArgs> ReceiveData;
        public event EventHandler<NetworkEventArgs> ClientDisconnected;
    }
}