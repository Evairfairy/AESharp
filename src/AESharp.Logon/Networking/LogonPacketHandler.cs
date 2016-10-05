using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AESharp.Core.Interfaces;
using AESharp.Core.Interfaces.Networking;

namespace AESharp.Logon.Networking
{
    public abstract class LogonPacketHandler<T> : IPacketHandler<T>
        where T : IPacket
    {
        public abstract PacketId PacketId { get; }

        public abstract bool HandlePacket( T packet );

        public bool HandlePacket( object packet )
            => this.HandlePacket( (T)packet );
    }
}
