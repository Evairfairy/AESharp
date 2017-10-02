namespace AESharp.Interop.Protocol
{
    public sealed class DisconnectPacket : RoutingPacket
    {
        public string Reason { get; }

        public DisconnectPacket(string reason) : base(RoutingPacketId.Disconnect)
        {
            Reason = reason ?? "<no reason given>";
            WriteShortString(Reason);
        }

        public DisconnectPacket(byte[] data) : base(data)
        {
            Reason = ReadShortString();
        }
    }
}