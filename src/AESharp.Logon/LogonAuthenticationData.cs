using AESharp.Core.Crypto;

namespace AESharp.Logon
{
    public class LogonAuthenticationData
    {
        public bool Initialised { get; } = false;

        // Init this manually after we're sure the packet isn't junk
        public SRP6 Srp6Data { get; private set; }

        public void InitSRP6()
        {
            this.Srp6Data = new SRP6();
        }
    }
}
