using AESharp.Networking.Exceptions;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Protocol
{
    public sealed class InitiateHandshakePacket : AEPacket
    {
        // This packet is always the same size
        private const int ExpectedSize = sizeof( byte ) + sizeof( ushort );

        public ushort ProtocolVersion { get; }

        // TODO: normally protocol shouldn't be specified manually. This is only for debug purposes.
        public InitiateHandshakePacket( ushort protocolVersion ) : base( AEPacketId.ClientHandshakeBegin )
        {
            this.ProtocolVersion = protocolVersion;

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

            this.ProtocolVersion = this.ReadUInt16();
        }
    }
}