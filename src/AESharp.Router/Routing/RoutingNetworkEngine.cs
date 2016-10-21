using System.IO;
using AESharp.Core.Interfaces.Networking;

namespace AESharp.Router.Routing
{
    internal sealed class RoutingNetworkEngine : INetworkEngine
    {
        public Stream ProcessDataForReceive( Stream data ) => data;

        public Stream ProcessDataForSend( Stream data ) => data;
    }
}