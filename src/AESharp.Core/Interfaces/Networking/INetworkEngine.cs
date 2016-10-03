namespace AESharp.Core.Interfaces.Networking
{
    public interface INetworkEngine
    {
        void ProcessDataForReceive( INetworkEventArgs args );
        void ProcessDataForSend( INetworkEventArgs args );
    }
}