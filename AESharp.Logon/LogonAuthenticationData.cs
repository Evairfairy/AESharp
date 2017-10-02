using AESharp.Core.Crypto;
using AESharp.Logon.Accounts;

namespace AESharp.Logon
{
    public class LogonAuthenticationData
    {
        public bool Initialised { get; } = false;
        public Account DbAccount { get; set; }

        // Init this manually after we're sure the packet isn't junk
        public SecureRemotePassword6 Srp6 { get; private set; }

        public void InitSRP6( string username, byte[] passwordHash )
        {
            this.Srp6 = new SecureRemotePassword6( username,
                SecureRemotePassword6.GenerateCredentialsHash( "TESTGM", "TESTGM" ) );
        }
    }
}