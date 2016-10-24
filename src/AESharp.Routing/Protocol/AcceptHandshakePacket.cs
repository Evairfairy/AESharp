using AESharp.Routing.Networking;

namespace AESharp.Routing.Protocol
{
    public sealed class AcceptHandshakePacket : AEPacket
    {
        public AcceptHandshakePacket() : base( AEPacketId.ServerHandshakeResult )
        {
        }

        public AcceptHandshakePacket( byte[] data ) : base( data )
        {
        }
    }
}