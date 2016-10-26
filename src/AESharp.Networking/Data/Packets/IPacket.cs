namespace AESharp.Networking.Data.Packets
{
    public interface IPacket
    {
        byte[] FinalizePacket();
    }
}