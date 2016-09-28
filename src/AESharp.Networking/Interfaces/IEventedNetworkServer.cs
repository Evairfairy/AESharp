using System;
using AESharp.Networking.Events;

namespace AESharp.Networking.Interfaces
{
    public interface IEventedNetworkServer
    {
        event EventHandler<NetworkEventArgs> ClientConnecting;
        event EventHandler<NetworkEventArgs> ClientConnected;
        event EventHandler<NetworkEventArgs> ReceiveData;
        event EventHandler<NetworkEventArgs> ClientDisconnected;
    }
}