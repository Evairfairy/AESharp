using AESharp.Networking.Middleware;

namespace AESharp.Logon.Universal.Networking.Middleware
{
    public class LogonMetaPacket : MetaPacket
    {
        public LogonMetaPacket() { }

        public LogonMetaPacket( byte[] payload ) : base( payload ) { }
    }
}