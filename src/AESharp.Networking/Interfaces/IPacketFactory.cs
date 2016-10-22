namespace AESharp.Networking.Interfaces
{
    public interface IPacketFactory
    {
        IPacket CreatePacket( byte[] data );
    }
}