using System.Text;

namespace AESharp.Networking.Data.Packets
{
    public abstract class ManagedPacket : IPacket
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

        public abstract byte[] FinalizePacket();
    }
}