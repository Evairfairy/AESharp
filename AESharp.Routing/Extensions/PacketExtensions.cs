using System;
using System.Collections.Generic;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Core;
using AESharp.Routing.Exceptions;
using AESharp.Routing.Networking;

namespace AESharp.Routing.Extensions
{
    internal static class PacketExtensions
    {
        public static List<T> ReadList<T>(this Packet packet, Func<Packet, T> readObjectFunc)
        {
            var returnList = new List<T>();

            var listSize = packet.ReadUInt16();

            for (ushort i = 0; i < listSize; ++i)
            {
                returnList.Add(readObjectFunc(packet));
            }

            return returnList;
        }

        public static void WriteList<T>(this Packet packet, List<T> list, Action<Packet, T> writeObjectFunc)
        {
            if (list.Count > ushort.MaxValue)
                throw new InvalidOperationException(
                    $"You may only write lists containing a maximum of {ushort.MaxValue} elements");

            packet.WriteUInt16((ushort) list.Count);
            foreach (var value in list)
            {
                writeObjectFunc(packet, value);
            }
        }

        public static RoutingComponent ReadRoutingComponent(this Packet packet)
        {
            return new RoutingComponent
            {
                Guid = packet.ReadGuid(),
                Type = packet.ReadComponentType(),
                OwnedObjects = packet.ReadList(ReadRoutingComponent)
            };
        }

        public static void WriteRoutingComponent(this Packet packet, RoutingComponent component)
        {
            packet.WriteGuid(component.Guid);
            packet.WriteComponentType(component.Type);
            packet.WriteList(component.OwnedObjects, WriteRoutingComponent);
        }

        public static AEPacketId ReadPacketId(this Packet packet)
        {
            var id = packet.ReadInt32();
            if (!Enum.IsDefined(typeof(AEPacketId), id))
                throw new UnhandledAEPacketException(id);

            return (AEPacketId) id;
        }

        public static void WritePacketId(this Packet packet, AEPacketId packetId)
        {
            packet.WriteInt32((int) packetId);
        }

        public static ComponentType ReadComponentType(this Packet packet)
        {
            var type = packet.ReadUInt16();
            if (!Enum.IsDefined(typeof(ComponentType), type))
                throw new InvalidPacketException($"Tried to read unregistered component type {type} from packet");

            return (ComponentType) type;
        }

        public static void WriteComponentType(this Packet packet, ComponentType type)
        {
            packet.WriteUInt16((ushort) type);
        }
    }
}