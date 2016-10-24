using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Routing.Networking;

namespace AESharp.MasterRouter.Networking
{
    public class AERemoteClient : RemoteClient
    {
        public AERemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource ) : base( rawClient, tokenSource )
        {
        }

        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            // Read packet
            AEPacket packet = new AEPacket(data);

            if ( token.IsCancellationRequested )
            {
                return;
            }

            // Switch opcode
        }
    }
}