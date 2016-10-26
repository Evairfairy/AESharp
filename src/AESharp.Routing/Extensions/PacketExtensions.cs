using System;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Core;
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
                throw new UnhandledAEPacketException( id );
            }

            return (AEPacketId) id;
        }

        public static void WritePacketId( this Packet packet, AEPacketId packetId )
            => packet.WriteInt32( (int) packetId );

        public static ComponentType ReadComponentType( this Packet packet )
        {
            ushort type = packet.ReadUInt16();
            if ( !Enum.IsDefined( typeof( ComponentType ), type ) )
            {
                throw new InvalidPacketException( $"Tried to read unregistered component type {type} from packet" );
            }

            return (ComponentType) type;
        }

        public static void WriteComponentType( this Packet packet, ComponentType type )
        {
            packet.WriteUInt16( (ushort) type );
        }
    }
}