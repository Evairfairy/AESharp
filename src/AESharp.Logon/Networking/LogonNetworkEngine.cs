using System;
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
            throw new NotImplementedException();
        }

        public void ProcessDataForReceive( INetworkEventArgs args )
        {
            // Do crypto stuff here
        }

        public Stream ProcessDataForSend( Stream dataStream )
        {
            throw new NotImplementedException();
        }

        public void ProcessDataForSend( INetworkEventArgs args )
        {
            // Do crypto stuff here
        }
    }
}