using AESharp.Routing.Networking;

namespace AESharp.Routing.Protocol
{
    public sealed class DisconnectPacket : AEPacket
    {
        public string Reason { get; }

        public DisconnectPacket( string reason ) : base( AEPacketId.Disconnect )
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