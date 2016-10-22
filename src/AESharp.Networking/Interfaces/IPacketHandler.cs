using System;
using AESharp.Networking.Packets;

namespace AESharp.Networking.Interfaces
{
    [Obsolete( "Reflection packet handling will be removed soon" )]
    public interface IPacketHandler
    {
        Type Type { get; }
        PacketHandlerResult HandlePacket( object packet );
    }

    [Obsolete( "Reflection packet handling will be removed soon" )]
    public interface IPacketHandler< in T > : IPacketHandler
        where T : IPacket
    {
        PacketHandlerResult HandlePacket( T packet );
    }
}