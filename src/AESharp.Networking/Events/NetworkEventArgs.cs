using System;
using System.IO;

namespace AESharp.Networking.Events
{
    public class NetworkEventArgs : EventArgs
    {
        public AENetworkClient Client { get; private set; }
        public Stream Stream { get; private set; }
        public bool Cancel { get; set; }

        public NetworkEventArgs(AENetworkClient client, Stream stream, bool cancel)
        {
            Client = client;
            Stream = stream;
            Cancel = cancel;
        }
    }
}