using System;
using System.IO;
using AESharp.Core.Interfaces.Networking;

namespace AESharp.Networking.Events
{
    public class NetworkEventArgs : EventArgs, INetworkEventArgs
    {
        public NetworkEventArgs( INetworkClient client, MemoryStream dataStream )
        {
            this.Client = client;
            this.DataStream = dataStream;
            this.DisconnectClient = false;
        }

        public INetworkClient Client { get; }
        public MemoryStream DataStream { get; }
        public bool DisconnectClient { get; set; }
    }
}