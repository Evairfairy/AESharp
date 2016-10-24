using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Extensions;

namespace AESharp.Routing.Networking
{
    public class AEPacket : Packet
    {
        public AEPacketId PacketId { get; }
        public ushort Size { get; }

        public ushort HeaderSize => sizeof( int ) + sizeof( ushort );

        public AEPacket( AEPacketId packetId )
        {
            this.PacketId = packetId;

            this.WritePacketId( packetId );
            this.WriteUInt16( 0 );
        }

        public AEPacket( byte[] data )
            : base( data )
        {
            if ( data.Length < this.HeaderSize )
            {
                throw new InvalidPacketException($"Malformed packet header: expected at least {this.HeaderSize} bytes");
            }

            this.PacketId = this.ReadPacketId();
            this.Size = this.ReadUInt16();
        }

        public AEPacket()
        {
            this.WriteInt32( 0 );
            this.WriteInt16( 0 );
        }

        public override byte[] BuildPacket()
        {
            byte[] buffer = new byte[this.HeaderSize + this.InternalBuffer.Length];

            return buffer;
        }
    }
}