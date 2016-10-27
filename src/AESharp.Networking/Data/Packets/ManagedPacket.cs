using System.Text;
using AESharp.Networking.Middleware;

namespace AESharp.Networking.Data.Packets
{
    public abstract class ManagedPacket<TMetaPacket> where TMetaPacket : MetaPacket, IPacket<TMetaPacket>
    {
        protected readonly Packet InternalPacket;

        public ManagedPacket( Encoding encoding = null )
        {
            this.InternalPacket = new Packet( encoding );
        }

        public ManagedPacket( byte[] data, Encoding encoding = null )
        {
            this.InternalPacket = new Packet( data, encoding );
        }

        public abstract TMetaPacket FinalizePacket();
    }
}