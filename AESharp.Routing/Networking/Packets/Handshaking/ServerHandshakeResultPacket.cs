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

        public ServerHandshakeResultPacket() : base(AEPacketId.ServerHandshakeResult)
        {
        }

        public ServerHandshakeResultPacket(RoutingMetaPacket metaPacket) : base(metaPacket)
        {
            InternalMetaPacket.PacketId = AEPacketId.ServerHandshakeResult;

            Result = ReadSHRPResult();

            if (Result == SHRPResult.Success)
            {
                OurComponent = InternalPacket.ReadRoutingComponent();
                OtherAvailableComponents = InternalPacket.ReadList(PacketExtensions.ReadRoutingComponent);
            }
        }

        public override RoutingMetaPacket FinalizePacket()
        {
            WriteSHRPResult(Result);

            if (Result == SHRPResult.Success)
            {
                InternalPacket.WriteRoutingComponent(OurComponent);
                InternalPacket.WriteList(OtherAvailableComponents, PacketExtensions.WriteRoutingComponent);
            }

            return base.FinalizePacket();
        }

        private SHRPResult ReadSHRPResult()
        {
            var b = InternalPacket.ReadByte();
            EnumHelpers.ThrowIfUndefined(typeof(SHRPResult), b);
            return (SHRPResult) b;
        }

        private void WriteSHRPResult(SHRPResult value)
        {
            InternalPacket.WriteByte((byte) value);
        }
    }
}