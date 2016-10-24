using System;
using AESharp.Networking.Data;
using AESharp.Routing.Exceptions;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Extensions
{
    internal static class PacketExtensions
    {
        public static AEPacketId ReadPacketId( this Packet packet )
        {
            int id = packet.ReadInt32();
            if ( !Enum.IsDefined( typeof( AEPacketId ), id ) )
            {
                throw new UnhandledAEPacketException(id);
            }

            return (AEPacketId) id;
        }

        public static void WritePacketId( this Packet packet, AEPacketId packetId )
            => packet.WriteInt32( (int) packetId );
    }
}