using AESharp.Networking.Middleware;

namespace AESharp.World.Networking.Middleware
{
    public class RealmMetaPacket : MetaPacket
    {
        public RealmMetaPacket()
        {
        }

        public RealmMetaPacket(byte[] payload) : base(payload)
        {
        }
    }
}