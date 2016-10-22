using System;
using System.Collections.Generic;

namespace AESharp.Networking.Interfaces.ClientManagement
{
    public interface IRemoteClientRepository
    {
        Guid AddClient( IRemoteClient client );
        void RemoveClient( Guid clientGuid );
        IRemoteClient GetClient( Guid clientGuid );
        IEnumerable<IRemoteClient> GetAllClients();
    }
}