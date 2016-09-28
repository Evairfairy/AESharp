using System;
using AESharp.Networking.Events;

namespace AESharp.Networking.Interfaces
{
    public interface IEventedNetworkServer
    {
        event EventHandler<NetworkEventArgs> OnClientConnecting;
        event EventHandler<NetworkEventArgs> OnClientConnected;
        event EventHandler<NetworkEventArgs> OnReceiveData;
        event EventHandler<NetworkEventArgs> OnClientDisconnected;
    }
}