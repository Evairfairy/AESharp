using System;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Extensions;

namespace AESharp.Routing.Networking
{
    public class AEPacketHeader : IPacket
    {
        public Guid Sender;
        public Guid Target;
        public ushort Size;
        public ushort PayloadSize => (ushort) this.Payload.Length;
        public AEPacketId Id;

        public byte[] Payload;

        public AEPacketHeader( byte[] data )
        {
            Packet packet = new Packet( data );

            this.Sender = packet.ReadGuid();
            this.Target = packet.ReadGuid();
            this.Size = packet.ReadUInt16();
            this.Id = packet.ReadPacketId();

            this.Payload = packet.ReadRemainingBytes();
        }

        public AEPacketHeader( Guid sender, Guid target, AEPacketId id, byte[] payload )
        {
            this.Sender = sender;
            this.Target = target;
            this.Id = id;
            this.Size = (ushort) payload.Length;

            this.Payload = payload;
        }

        public byte[] FinalizePacket()
        {
            Packet packet = new Packet();

            packet.WriteGuid( this.Sender );
            packet.WriteGuid( this.Target );
            packet.WriteUInt16( (ushort) this.Payload.Length );
            packet.WritePacketId( this.Id );

            packet.WriteBytes( this.Payload );

            return packet.FinalizePacket();
        }
    }
}