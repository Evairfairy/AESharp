namespace AESharp.Networking.Middleware
{
    public class MetaPacket
    {
        public byte[] Payload;
        public bool Handled = false;

        public MetaPacket( byte[] payload )
        {
            this.Payload = payload;
        }
    }
}