namespace AESharp.Networking.Middleware
{
    public class MetaPacket
    {
        public bool Handled = false;
        public bool KillSender = false;
        public byte[] Payload;

        public MetaPacket()
        {
            Payload = new byte[0];
        }

        public MetaPacket(byte[] payload)
        {
            Payload = payload;
        }
    }
}