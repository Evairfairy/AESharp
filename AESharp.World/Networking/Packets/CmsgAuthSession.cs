namespace AESharp.World.Networking.Packets
{
    public class CmsgAuthSession
    {
        public string Account;
        public uint ClientBuild;
        public uint ClientSeed;
        public uint Unk2;
        public uint Unk3;
        public ulong Unk4;
        public uint Unk5;
        public uint Unk6;
        public uint Unk7;

        public CmsgAuthSession(RealmPacket packet)
        {
            ClientBuild = packet.ReadUInt32();
            Unk2 = packet.ReadUInt32();
            Account = packet.ReadCString();
            Unk3 = packet.ReadUInt32();
            ClientSeed = packet.ReadUInt32();
            Unk4 = packet.ReadUInt64();
            Unk5 = packet.ReadUInt32();
            Unk6 = packet.ReadUInt32();
            Unk7 = packet.ReadUInt32();
        }
    }
}