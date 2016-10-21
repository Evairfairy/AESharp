using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AESharp.Core.Interfaces;
using AESharp.Networking.Packets.Serialization;
using AESharp.Networking.Packets.Serialization.Converters;

namespace AESharp.Router.Routing.Packets
{
    internal sealed class DisconnectPacket : IPacket
    {
        public RoutingPacketId PacketId { get; private set; } = RoutingPacketId.Disconnect;

        [BinaryConverter( typeof( BStringConverter ) )]
        public string Reason { get; set; }
    }
}
