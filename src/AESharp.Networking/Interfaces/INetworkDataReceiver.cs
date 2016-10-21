using System;
using AESharp.Networking.Events;

namespace AESharp.Networking.Interfaces
{
    public interface INetworkDataReceiver
    {
        event EventHandler<NetworkEventArgs> ReceiveData;
    }
}