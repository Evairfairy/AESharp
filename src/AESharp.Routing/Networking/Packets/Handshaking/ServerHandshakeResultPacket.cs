using System;
using AESharp.Core.Extensions;
using AESharp.Routing.Middleware;

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

        public ServerHandshakeResultPacket( RoutingMetaPacket metaPacket ) : base( metaPacket )
        {
            this.InternalMetaPacket.PacketId = AEPacketId.ServerHandshakeResult;

            this.Result = this.ReadSHRPResult();
            this.AssignedGuid = this.InternalPacket.ReadGuid();
        }

        public override RoutingMetaPacket FinalizePacket()
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