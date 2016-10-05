namespace AESharp.Core.Interfaces.Networking
{
    public interface IPacketHandler
    {
        bool HandlePacket( object packet );
    }

    public interface IPacketHandler<in T> : IPacketHandler
        where T : IPacket
    {
        bool HandlePacket( T packet );
    }
}