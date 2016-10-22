using System;
using System.IO;

namespace AESharp.Networking.Interfaces
{
    [Obsolete( "Reflection based networking will be removed soon" )]
    public interface INetworkEngine
    {
        Stream ProcessDataForReceive( Stream dataStream );
        Stream ProcessDataForSend( Stream dataStream );
    }
}