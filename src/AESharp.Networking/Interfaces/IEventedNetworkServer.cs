using System;
using AESharp.Networking.Events;

namespace AESharp.Networking.Interfaces
{
    public interface IEventedNetworkServer
    {
        event EventHandler<NetworkEventArgs> ClientConnecting;
        event EventHandler<NetworkEventArgs> ClientDisconnected;
    }
}