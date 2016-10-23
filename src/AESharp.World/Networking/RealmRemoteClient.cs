using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;
using AESharp.Networking.Extensions;
using AESharp.World.Networking.Packets;

namespace AESharp.World.Networking
{
    public class RealmRemoteClient : RemoteClient
    {
        private uint _seed;

        public uint Seed
        {
            get
            {
                if ( this._seed == 0 )
                {
                    byte[] seedBytes = new byte[4];

                    Random rand = new Random( Environment.TickCount );
                    rand.NextBytes( seedBytes );
                    this._seed = BitConverter.ToUInt32( seedBytes, 0 );
                }

                return this._seed;
            }
        }

        public RealmRemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
            : base( rawClient, tokenSource )
        {
        }

        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            RealmPacket realmPacket = new RealmPacket( data, false );
            if ( token.IsCancellationRequested )
            {
                return;
            }

            switch ( realmPacket.Opcode )
            {
                // CmsgAuthSession
                case 0x1ed:
                {
                    CmsgAuthSession packet = new CmsgAuthSession( realmPacket );
                    Console.WriteLine( $"\tClient Build:\t{packet.ClientBuild}" );
                    Console.WriteLine( $"\tUnk2:\t\t{packet.Unk2}" );
                    Console.WriteLine( $"\tAccount Name:\t{packet.Account}" );
                    Console.WriteLine( $"\tUnk3:\t\t{packet.Unk3}" );
                    Console.WriteLine( $"\tClient Seed:\t{packet.ClientSeed}" );
                    Console.WriteLine( $"\tUnk4:\t\t{packet.Unk4}" );
                    Console.WriteLine( $"\tUnk5:\t\t{packet.Unk5}" );
                    Console.WriteLine( $"\tUnk6:\t\t{packet.Unk6}" );
                    Console.WriteLine( $"\tUnk7:\t\t{packet.Unk7}" );

                    // Currently unhandled
                    await this.DisconnectEx( 500 );

                    break;
                }
                default:
                {
                    throw new InvalidPacketException( $"Received unsupported opcode: 0x{realmPacket.Opcode:x2}" );
                }
            }
        }
    }
}