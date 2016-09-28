using System;

namespace AESharp.Networking.Events
{
    public class NetworkEventArgs : EventArgs
    {
        public AENetworkClient Client { get; private set; }
        public byte[] Data { get; private set; }
        public bool Cancel { get; set; }

        public NetworkEventArgs(AENetworkClient client, byte[] data, bool cancel)
        {
            Client = client;
            Data = data;
            Cancel = cancel;
        }
    }
}