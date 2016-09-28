using System.Net.Sockets;

namespace AESharp.Networking
{
    public class AENetworkClient
    {
        public TcpClient BaseClient { get; private set; }

        public AENetworkClient(TcpClient baseClient)
        {
            BaseClient = baseClient;
        }
    }
}