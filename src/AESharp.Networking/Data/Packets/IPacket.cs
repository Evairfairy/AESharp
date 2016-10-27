using AESharp.Networking.Middleware;

namespace AESharp.Networking.Data.Packets
{
    public interface IPacket<TMetaPacket> where TMetaPacket : MetaPacket
    {
        TMetaPacket FinalizePacket();
    }
}