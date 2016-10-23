using AESharp.Networking.Data;

namespace AESharp.Interop.Protocol
{
    public sealed class AcceptHandshakePacket : RoutingPacket
    {
        public AcceptHandshakePacket() : base( RoutingPacketId.AcceptHandshake ) { }

        public AcceptHandshakePacket( byte[] data ) : base( data )
        {
            
        }
    }
}