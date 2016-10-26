using System;
using AESharp.Core.Extensions;

namespace AESharp.Routing.Networking.Packets.Handshaking
{
    public class ServerHandshakeResultPacket : AEPacket
    {
        public enum SHRPResult : byte
        {
            Success,
            Failure
        }

        public Guid AssignedGuid;

        public SHRPResult Result;

        public ServerHandshakeResultPacket() : base( AEPacketId.ServerHandshakeResult )
        {
        }

        public ServerHandshakeResultPacket( byte[] data ) : base( data )
        {
            this.Result = this.ReadSHRPResult();
            this.AssignedGuid = this.InternalPacket.ReadGuid();
        }

        public override byte[] FinalizePacket()
        {
            this.WriteSHRPResult( this.Result );
            this.InternalPacket.WriteGuid( this.AssignedGuid );

            return base.FinalizePacket();
        }

        private SHRPResult ReadSHRPResult()
        {
            byte b = this.InternalPacket.ReadByte();
            EnumHelpers.ThrowIfUndefined( typeof( SHRPResult ), b );
            return (SHRPResult) b;
        }

        private void WriteSHRPResult( SHRPResult value )
        {
            this.InternalPacket.WriteByte( (byte) value );
        }
    }
}