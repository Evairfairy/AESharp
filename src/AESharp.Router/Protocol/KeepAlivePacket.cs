using System;

namespace AESharp.Router.Protocol
{
    public sealed class KeepAlivePacket : RoutingPacket
    {
        public DateTime TimeSent { get; }
        public Guid Guid { get; }

        public KeepAlivePacket( byte[] data ) : base( data )
        {
            this.TimeSent = this.ReadDateTime();
            this.Guid = this.ReadGuid();
        }

        public KeepAlivePacket( DateTime timeSent, Guid guid ) : base( RoutingPacketId.KeepAlive )
        {
            this.TimeSent = timeSent;
            this.Guid = guid;

            this.WriteDateTime( timeSent );
            this.WriteGuid( guid );
        }

        public KeepAlivePacket WithDateTime( DateTime newDateTime )
            => new KeepAlivePacket( newDateTime, this.Guid );
    }
}