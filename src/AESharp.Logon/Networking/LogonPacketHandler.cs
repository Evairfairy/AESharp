using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AESharp.Core.Interfaces;
using AESharp.Core.Interfaces.Networking;
using AESharp.Networking.Packets;

namespace AESharp.Logon.Networking
{
    public abstract class LogonPacketHandler<T> : IPacketHandler<T>
        where T : IPacket
    {
        public Type Type { get; } = typeof( T );

        public abstract PacketId PacketId { get; }

        public abstract PacketHandlerResult HandlePacket( T packet );

        public PacketHandlerResult HandlePacket( object packet )
            => this.HandlePacket( (T)packet );
    }
}
