namespace AESharp.Networking.Interfaces
{
    public interface INetworkDataSender
    {
        void SendPacket( IPacket packet );
    }
}