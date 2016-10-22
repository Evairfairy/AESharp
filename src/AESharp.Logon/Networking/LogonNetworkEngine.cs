using System;
using System.IO;
using AESharp.Networking.Interfaces;
using SimpleInjector;

namespace AESharp.Logon.Networking
{
    [Obsolete("Reflection based networking will be removed soon")]
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