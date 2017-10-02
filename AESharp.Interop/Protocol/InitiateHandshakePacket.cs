using AESharp.Networking.Exceptions;

namespace AESharp.Interop.Protocol
{
    public sealed class InitiateHandshakePacket : RoutingPacket
    {
        // This packet is always the same size
        private const int ExpectedSize = sizeof(byte) + sizeof(ushort);

        public ushort ProtocolVersion { get; }

        // TODO: normally protocol shouldn't be specified manually. This is only for debug purposes.
        public InitiateHandshakePacket(ushort protocolVersion) : base(RoutingPacketId.InitiateHandshake)
        {
            ProtocolVersion = protocolVersion;

            WriteUInt16(ProtocolVersion);
        }

        public InitiateHandshakePacket(byte[] data)
            : base(data)
        {
            if (Length < ExpectedSize)
            {
                throw new InvalidPacketException(
                    $"Received packet with incorrect size. Expecting {ExpectedSize} bytes, " +
                    $"but received {Length} bytes instead");
            }

            ProtocolVersion = ReadUInt16();
        }
    }
}