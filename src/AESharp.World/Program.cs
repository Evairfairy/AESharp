using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Extensions;
using AESharp.Networking;
using AESharp.World.Networking;
using AESharp.World.Networking.Middleware;

namespace AESharp.World
{
    public class Program
    {
        public static void Main( string[] args )
        {
            TcpServer server = new TcpServer( new IPEndPoint( IPAddress.Loopback, 8095 ) );
            server.Start( AcceptClientActionAsync );

            Console.WriteLine( "Realm router now listening" );
            Console.ReadLine();
        }

        private static async void AcceptClientActionAsync( TcpClient rawClient )
        {
            Console.WriteLine( "Accepting Realm Client" );
            RealmRemoteClient client = new RealmRemoteClient( rawClient );

            Guid clientGuid = Guid.Empty;

            Console.WriteLine( $"Using realm seed: 0x{client.Seed:x}" );

            try
            {
                clientGuid = RealmServices.RemoteClients.AddClient( client );

                RealmPacket packet = new RealmPacket( true )
                {
                    Opcode = 0x1ec
                };

                packet.WriteUInt32( 1 ); // unk1
                packet.WriteUInt32( client.Seed );
                packet.WriteUInt32( 0 ); // unk2
                packet.WriteUInt32( 0 ); // unk3
                packet.WriteUInt32( 0 ); // unk4
                packet.WriteUInt32( 0 ); // unk5

                Task.Run( async () =>
                          {
                              // Give us time to start listening
                              await Task.Delay( 500 );
                              await client.SendDataAsync( new RealmMetaPacket( packet.FinalizePacket() ) );
                          } ).RunAsync();

                await client.ListenForDataTask();
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Unhandled exception in {nameof( AcceptClientActionAsync )}: {ex}" );
            }
            finally
            {
                if ( clientGuid != Guid.Empty )
                {
                    RealmServices.RemoteClients.RemoveClient( clientGuid );
                }
                Console.WriteLine( $"Client disconnected" );
            }
        }
    }
}