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

        public void ProcessDataForReceive( INetworkEventArgs args )
        {
            // Do crypto stuff here
        }

        public void ProcessDataForSend( INetworkEventArgs args )
        {
            // Do crypto stuff here
        }
    }
}