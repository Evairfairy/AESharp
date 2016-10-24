namespace AESharp.Logon.Universal.Networking.Packets
{
    public class ProofPacket
    {
        public byte[] A;
        public byte[] CrcHash;
        public byte[] M1;
        public byte NumberOfKeys;
        public byte Unk;

        public ProofPacket( LogonPacket packet )
        {
            this.A = packet.ReadBytes( 32 );
            this.M1 = packet.ReadBytes( 20 );
            this.CrcHash = packet.ReadBytes( 20 );
            this.NumberOfKeys = packet.ReadByte();
            this.Unk = packet.ReadByte();
        }
    }
}