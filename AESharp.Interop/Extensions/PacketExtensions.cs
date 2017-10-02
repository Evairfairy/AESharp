using AESharp.Networking.Data.Packets;

namespace AESharp.Interop.Extensions
{
    internal static class PacketExtensions
    {
        public static RoutingPacketId ReadPacketId(this Packet packet)
        {
            return (RoutingPacketId) packet.ReadByte();
        }

        public static void WritePacketId(this Packet packet, RoutingPacketId packetId)
        {
            packet.WriteByte((byte) packetId);
        }
    }
}