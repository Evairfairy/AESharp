using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;
using AESharp.World.Networking.Middleware;
using AESharp.World.Networking.Packets;

namespace AESharp.World.Networking
{
    public class RealmRemoteClient : RemoteClient<RealmMetaPacket>
    {
        private uint _seed;

        public uint Seed
        {
            get
            {
                if (_seed == 0)
                {
                    byte[] seedBytes = new byte[4];

                    Random rand = new Random(Environment.TickCount);
                    rand.NextBytes(seedBytes);
                    _seed = BitConverter.ToUInt32(seedBytes, 0);
                }

                return _seed;
            }
        }

        public RealmRemoteClient(TcpClient rawClient) : base(rawClient)
        {
        }

        public override async Task HandleDataAsync(RealmMetaPacket metaPacket)
        {
            RealmPacket realmPacket = new RealmPacket(metaPacket.Payload, false);

            switch (realmPacket.Opcode)
            {
                // CmsgAuthSession
                case 0x1ed:
                {
                    CmsgAuthSession packet = new CmsgAuthSession(realmPacket);
                    Console.WriteLine($"\tClient Build:\t{packet.ClientBuild}");
                    Console.WriteLine($"\tUnk2:\t\t{packet.Unk2}");
                    Console.WriteLine($"\tAccount Name:\t{packet.Account}");
                    Console.WriteLine($"\tUnk3:\t\t{packet.Unk3}");
                    Console.WriteLine($"\tClient Seed:\t{packet.ClientSeed}");
                    Console.WriteLine($"\tUnk4:\t\t{packet.Unk4}");
                    Console.WriteLine($"\tUnk5:\t\t{packet.Unk5}");
                    Console.WriteLine($"\tUnk6:\t\t{packet.Unk6}");
                    Console.WriteLine($"\tUnk7:\t\t{packet.Unk7}");

                    // Currently unhandled
                    Disconnect();

                    break;
                }
                default:
                {
                    throw new InvalidPacketException($"Received unsupported opcode: 0x{realmPacket.Opcode:x2}");
                }
            }
        }
    }
}