using System.Net.Sockets;
using AESharp.Core.Interfaces.Networking;

namespace AESharp.Networking
{
    public class AENetworkClient : INetworkClient
    {
        public AENetworkClient( TcpClient baseClient )
        {
            this.BaseClient = baseClient;
        }

        public TcpClient BaseClient { get; private set; }
    }
}