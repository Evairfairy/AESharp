using System;
using System.IO;

namespace AESharp.Networking.Events
{
    public class NetworkEventArgs : EventArgs
    {
        public NetworkEventArgs( NetworkClient client, Stream dataStream )
        {
            this.Client = client;
            this.DataStream = dataStream;
            this.DisconnectClient = false;
        }

        public NetworkClient Client { get; }
        public Stream DataStream { get; }
        public bool DisconnectClient { get; set; }
    }
}