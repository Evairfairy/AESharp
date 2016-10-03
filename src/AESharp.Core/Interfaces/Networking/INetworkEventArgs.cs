using System.IO;

namespace AESharp.Core.Interfaces.Networking
{
    public interface INetworkEventArgs
    {
        INetworkClient Client { get; }
        MemoryStream Data { get; }
        bool DisconnectClient { get; set; }
    }
}