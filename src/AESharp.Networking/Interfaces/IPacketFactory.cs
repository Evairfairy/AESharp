namespace AESharp.Core.Interfaces
{
    public interface IPacketFactory
    {
        IPacket CreatePacket( byte[] data );
    }
}