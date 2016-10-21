using System.IO;
using AESharp.Core.Interfaces.Networking;
using SimpleInjector;

namespace AESharp.Logon.Networking
{
    public class LogonNetworkEngine : INetworkEngine
    {
        private readonly Container _container;

        public LogonNetworkEngine( Container container )
        {
            this._container = container;
        }

        public Stream ProcessDataForReceive( Stream dataStream )
        {
            return dataStream;
        }

        public Stream ProcessDataForSend( Stream dataStream )
        {
            return dataStream;
        }
    }
}