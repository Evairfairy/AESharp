using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;

namespace AESharp.Router.Routing.Packets
{
    internal sealed class InitiateHandshakePacket : Packet
    {
        // This packet is always the same size
        private const int ExpectedSize = sizeof( byte ) + sizeof( ushort );

        public RoutingPacketId PacketId { get; } = RoutingPacketId.InitiateHandshake;
        public ushort ProtocolVersion { get; }

        // TODO: normally protocol shouldn't be specified manually. This is only for debug purposes.
        public InitiateHandshakePacket( ushort protocolVersion )
        {
            this.ProtocolVersion = protocolVersion;

            this.WriteByte( (byte) this.PacketId );
            this.WriteUInt16( this.ProtocolVersion );
        }

        public InitiateHandshakePacket( byte[] data )
            : base( data )
        {
            if ( this.Length < ExpectedSize )
            {
                throw new InvalidPacketException(
                    $"Received packet with incorrect size. Expecting {ExpectedSize} bytes, " +
                    $"but received {this.Length} bytes instead" );
            }

            this.PacketId = (RoutingPacketId) this.ReadByte();
            this.ProtocolVersion = this.ReadUInt16();
        }
    }
}