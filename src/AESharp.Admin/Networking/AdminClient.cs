using System;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AESharp.Core.Crypto;
using AESharp.Networking;
using AESharp.Networking.Data;
using AESharp.Networking.Events;

namespace AESharp.Admin.Networking
{
    public class AdminClient
    {
        public AdminClient()
        {
            this.DecryptEngine = null;
            this.Client = null;
        }

        public AENetworkClient Client { get; private set; }
        public RC4Engine DecryptEngine { get; private set; }
        public RC4Engine EncryptEngine { get; private set; }

        public async Task Connect( string host, int port )
        {
            try
            {
                this.Client = new AENetworkClient( new TcpClient() );
                this.Client.ReceiveData += this.ClientOnReceiveData;
                await this.Client.Connect( host, port );

                byte[] keyBytes = Encoding.ASCII.GetBytes( "ascent" );
                byte[] shaBytes = SHA1.Create().ComputeHash( keyBytes );

                this.DecryptEngine = new RC4Engine();
                this.DecryptEngine.Setup( shaBytes );

                this.EncryptEngine = new RC4Engine();
                this.EncryptEngine.Setup( shaBytes );

#pragma warning disable 4014
                this.Client.ReceiveDataTask();
#pragma warning restore 4014
            }
            catch ( Exception ex )
            {
                Console.WriteLine( "Exception occurred in AdminClient->Connect" );
                Console.WriteLine( ex );
            }

            if ( ( this.Client == null ) || !this.Client.Connected )
            {
                Console.WriteLine( "Failed to connect" );
                return;
            }

            Console.WriteLine( "Connected" );
        }

        private void ClientOnReceiveData( object sender, NetworkEventArgs networkEventArgs )
        {
            // TODO: Engineer the code such that this can definitely never happen
            if ( networkEventArgs.Client != this.Client )
            {
                Console.WriteLine( "Critical Error: Client passed to us in networkEventArgs is not our AENetworkClient" );
                throw new Exception(
                    "Critical Error: Client passed to us in networkEventArgs is not our AENetworkClient" );
            }

            byte[] decryptedData = this.DecryptEngine.Process(networkEventArgs.Data);
            NetworkPacket packet = new NetworkPacket(decryptedData);

            ushort opcode = packet.ReadUShort();
            uint length = packet.ReadUInt(true);
            uint result = packet.ReadUInt();

            Console.WriteLine($"Got data: [{opcode}, {length}, {result}]");

            this.RegisterFakeRealm();

            networkEventArgs.Cancel = true;
        }

        private void RegisterFakeRealm()
        {
            NetworkPacket packet = new NetworkPacket();

            packet.WriteUShort( 1 ); // Opcode
            packet.WriteBytes( BitConverter.GetBytes( (uint)0 ) );

            packet.WriteCString( "AE# Fake Realm" ); // Name
            packet.WriteCString( "127.0.0.1:8129" ); // Address
            packet.WriteUInt( 2 ); // Flags
            packet.WriteUInt( 0 ); // Icon
            packet.WriteUInt( 28 ); // TimeZone
            packet.WriteSingle( 2 ); // Population
            packet.WriteByte( 0 ); // Lock
            packet.WriteUInt( 12340 ); // GameBuild

            int length = packet.BytesWritten;

            length -= 6; // Ignore header

            // Overwrite the length with the real packet length
            packet.WriteBytesAndSeek( BitConverter.GetBytes( (uint)length ).Reverse().ToArray(), 2 );

            // Finally, encrypt the packet and send it
            packet.Encrypt( this.EncryptEngine );
            this.Client.SendPacket( packet );
        }
    }
}