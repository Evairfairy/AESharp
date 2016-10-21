using System;
using AESharp.Core.Interfaces;
using AESharp.Networking.Packets;

namespace AESharp.Networking.Interfaces
{
    public interface IPacketHandler
    {
        Type Type { get; }
        PacketHandlerResult HandlePacket( object packet, INetworkClient client );
    }

    public interface IPacketHandler<in T> : IPacketHandler
        where T : IPacket
    {
        PacketHandlerResult HandlePacket( T packet );
    }
}