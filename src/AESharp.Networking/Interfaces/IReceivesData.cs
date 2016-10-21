using System;
using AESharp.Networking.Events;

namespace AESharp.Networking.Interfaces
{
    public interface IReceivesData
    {
        event EventHandler<NetworkEventArgs> ReceiveData;
    }
}