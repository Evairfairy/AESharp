using System;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Extensions;

namespace AESharp.Routing.Networking
{
    public class AEPacket : ManagedPacket
    {
        // ReSharper disable once RedundantDefaultMemberInitializer
        private bool _finalized = false;

        public AEPacketId PacketId { get; }

        public AEPacket( AEPacketId packetId )
        {
            this.PacketId = packetId;
        }

        public AEPacket( byte[] data )
            : base( data )
        {
            if ( data.Length < sizeof( AEPacketId ) )
            {
                throw new InvalidPacketException(
                    $"Malformed packet header: expected at least {sizeof( AEPacketId )} bytes" );
            }

            this.PacketId = this.InternalPacket.ReadPacketId();
        }

        public override byte[] FinalizePacket()
        {
            if ( this._finalized )
            {
                throw new InvalidOperationException( "A packet may only be finalized once." );
            }
            this._finalized = true;

            Packet myLittlePacket = new Packet();

            myLittlePacket.WriteInt32( (int) this.PacketId );
            myLittlePacket.WriteBytes( this.InternalPacket.FinalizePacket() );

            return myLittlePacket.FinalizePacket();
        }
    }
}