using System;
using AESharp.Networking.Packets;

namespace AESharp.Core.Interfaces.Networking
{
    public interface IPacketHandler
    {
        Type Type { get; }
        PacketHandlerResult HandlePacket( object packet );
    }

    public interface IPacketHandler<in T> : IPacketHandler
        where T : IPacket
    {
        PacketHandlerResult HandlePacket( T packet );
    }
}