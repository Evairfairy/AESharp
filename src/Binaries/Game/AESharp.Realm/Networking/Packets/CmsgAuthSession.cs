namespace AESharp.Realm.Networking.Packets
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

        public CmsgAuthSession( RealmPacket packet )
        {
            this.ClientBuild = packet.ReadUInt32();
            this.Unk2 = packet.ReadUInt32();
            this.Account = packet.ReadCString();
            this.Unk3 = packet.ReadUInt32();
            this.ClientSeed = packet.ReadUInt32();
            this.Unk4 = packet.ReadUInt64();
            this.Unk5 = packet.ReadUInt32();
            this.Unk6 = packet.ReadUInt32();
            this.Unk7 = packet.ReadUInt32();
        }
    }
}