using System.IO;

namespace AESharp.Core.Interfaces.Networking
{
    public interface INetworkEngine
    {
        Stream ProcessDataForReceive( Stream dataStream );
        Stream ProcessDataForSend( Stream dataStream );
    }
}