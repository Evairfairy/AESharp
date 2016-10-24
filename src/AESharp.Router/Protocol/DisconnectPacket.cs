﻿namespace AESharp.Router.Protocol
{
    public sealed class DisconnectPacket : RoutingPacket
    {
        public string Reason { get; }

        public DisconnectPacket( string reason ) : base( RoutingPacketId.Disconnect )
        {
            this.Reason = reason ?? "<no reason given>";
            this.WriteShortString( this.Reason );
        }

        public DisconnectPacket( byte[] data ) : base( data )
        {
            this.Reason = this.ReadShortString();
        }
    }
}