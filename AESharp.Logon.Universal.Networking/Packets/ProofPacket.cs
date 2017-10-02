namespace AESharp.Logon.Universal.Networking.Packets
{
    public class ProofPacket
    {
        public byte[] A;
        public byte[] CrcHash;
        public byte[] M1;
        public byte NumberOfKeys;
        public byte Unk;

        public ProofPacket(LogonPacket packet)
        {
            A = packet.ReadBytes(32);
            M1 = packet.ReadBytes(20);
            CrcHash = packet.ReadBytes(20);
            NumberOfKeys = packet.ReadByte();
            Unk = packet.ReadByte();
        }
    }
}