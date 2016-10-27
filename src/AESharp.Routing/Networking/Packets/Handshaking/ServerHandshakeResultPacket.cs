using System.Collections.Generic;
using AESharp.Core.Extensions;
using AESharp.Routing.Core;
using AESharp.Routing.Extensions;
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

        public List<RoutingComponent> OtherAvailableComponents = new List<RoutingComponent>();
        public RoutingComponent OurComponent = new RoutingComponent();

        public SHRPResult Result;

        public ServerHandshakeResultPacket() : base( AEPacketId.ServerHandshakeResult )
        {
        }

        public ServerHandshakeResultPacket( RoutingMetaPacket metaPacket ) : base( metaPacket )
        {
            this.InternalMetaPacket.PacketId = AEPacketId.ServerHandshakeResult;

            this.Result = this.ReadSHRPResult();

            if ( this.Result == SHRPResult.Success )
            {
                this.OurComponent = this.InternalPacket.ReadRoutingComponent();
                this.OtherAvailableComponents = this.InternalPacket.ReadList( PacketExtensions.ReadRoutingComponent );
            }
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            this.WriteSHRPResult( this.Result );

            if ( this.Result == SHRPResult.Success )
            {
                this.InternalPacket.WriteRoutingComponent( this.OurComponent );
                this.InternalPacket.WriteList( this.OtherAvailableComponents, PacketExtensions.WriteRoutingComponent );
            }

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