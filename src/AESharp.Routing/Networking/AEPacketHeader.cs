//using System;
//using AESharp.Networking.Data.Packets;
//using AESharp.Routing.Extensions;
//using AESharp.Routing.Middleware;

//namespace AESharp.Routing.Networking
//{
//    public class AEPacketHeader : IPacket<RoutingMetaPacket>
//    {
//        private RoutingMetaPacket _internalMetaPacket;
//        public Guid Sender;
//        public Guid Target;
//        public ushort Size;
//        public ushort PayloadSize => (ushort)this.Payload.Length;
//        public AEPacketId Id;

//        public byte[] Payload;

//        public AEPacketHeader( RoutingMetaPacket metaPacket, byte[] payload )
//        {
//            Packet packet = new Packet(metaPacket.Payload);

//            metaPacket.Sender = packet.ReadGuid();
//            metaPacket.Target = packet.ReadGuid();
//            metaPacket.Size = packet.ReadUInt16();
//            metaPacket.PacketId = packet.ReadPacketId();

//            metaPacket.Payload = packet.ReadRemainingBytes();
//        }

//        public AEPacketHeader( RoutingMetaPacket metaPacket )
//        {
//            this.Sender = sender;
//            this.Target = target;
//            this.Id = id;
//            this.Size = (ushort)payload.Length;

//            this.Payload = payload;
//        }

//        public RoutingMetaPacket FinalizePacket()
//        {
//            Packet packet = new Packet();

//            packet.WriteGuid(this.Sender);
//            packet.WriteGuid(this.Target);
//            packet.WriteUInt16((ushort)this.Payload.Length);
//            packet.WritePacketId(this.Id);

//            packet.WriteBytes(this.Payload);

//            return packet.FinalizePacket();
//        }
//    }
//}

