using System;
using System.Threading;
using System.Threading.Tasks;

namespace AESharp.Networking.Interfaces.ClientManagement
{
    public interface IRemoteClient
    {
        Guid ClientGuid { get; }

        bool Connected { get; }

        Task ListenForDataTask( CancellationToken token );
        Task SendDataTask( byte[] data, CancellationToken token );
        Task HandleDataTask( byte[] data, CancellationToken token );
        Task Disconnect( TimeSpan timeToAllowForCancellation );
    }
}