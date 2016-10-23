namespace AESharp.Logon.Universal.Networking.Packets
{
    public enum LogonOpcodes
    {
        Challenge = 0x0,
        Proof = 0x1,
        ReconnectChallenge = 0x2,
        RealmList = 0x10,
        Invalid = 0xff
    }
}