using System;
using AESharp.Core.Interfaces;
using AESharp.Networking.Interfaces;
using AESharp.Networking.Packets;

namespace AESharp.Router.Routing
{
    public abstract class RoutingPacketHandler< T > : IPacketHandler<T>
        where T : IPacket
    {
        public Type Type { get; } = typeof( T );

        public abstract PacketHandlerResult HandlePacket( T packet );

        public PacketHandlerResult HandlePacket( object packet ) => this.HandlePacket( (T) packet );
    }
}