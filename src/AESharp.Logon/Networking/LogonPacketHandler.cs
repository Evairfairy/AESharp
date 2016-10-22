using System;
using AESharp.Networking.Interfaces;
using AESharp.Networking.Packets;

namespace AESharp.Logon.Networking
{
    [Obsolete("Reflection based networking will be removed soon")]
    public abstract class LogonPacketHandler< T > : IPacketHandler<T>
        where T : IPacket
    {
        public abstract PacketId PacketId { get; }
        public Type Type { get; } = typeof( T );

        public abstract PacketHandlerResult HandlePacket( T packet );

        public PacketHandlerResult HandlePacket( object packet )
            => this.HandlePacket( (T) packet );
    }
}