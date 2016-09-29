using System;
using System.Linq;
using System.Net;
using System.Text;
using AESharp.Core.Extensions;
using AESharp.Networking;
using AESharp.Networking.Data;
using AESharp.Networking.Events;

namespace AESharp.Logon
{
    public class Program
    {
        public static void Main( string[] args )
        {
            AETcpServer server = new AETcpServer( IPAddress.Any, 3724 );
            server.StartListening();

            server.ReceiveData += ServerOnReceiveData;

            Console.ReadLine();
        }

        private static void ServerOnReceiveData( object sender, NetworkEventArgs networkEventArgs )
        {
            NetworkPacket packet = new NetworkPacket(networkEventArgs.Data);

            Console.WriteLine($"Reading 4 byte header");

            int opcode = packet.ReadByte();
            int error = packet.ReadByte();
            int length = packet.ReadShort();
            string game = packet.ReadFixedString( 4 ).Flip();
            string build = $"{packet.ReadByte()}.{packet.ReadByte()}.{packet.ReadByte()} {packet.ReadShort()}";
            string platform = packet.ReadFixedString( 4 ).Flip();
            string os = packet.ReadFixedString( 4 ).Flip();
            string country = packet.ReadFixedString( 4 ).Flip();
            uint timezoneBias = packet.ReadUInt();
            string ip = $"{packet.ReadByte()}.{packet.ReadByte()}.{packet.ReadByte()}.{packet.ReadByte()}";
            byte accountNameLength = packet.ReadByte();
            string accountName = packet.ReadFixedString( accountNameLength );

            Console.WriteLine( $"Received logon packet:" );
            Console.WriteLine( $"\tOpcode:\t\t\t{opcode}" );
            Console.WriteLine( $"\tError:\t\t\t{error}" );
            Console.WriteLine( $"\tLength:\t\t\t{length}" );
            Console.WriteLine( $"\tGame:\t\t\t{game}" );
            Console.WriteLine( $"\tBuild:\t\t\t{build}" );
            Console.WriteLine( $"\tPlatform:\t\t{platform}" );
            Console.WriteLine( $"\tOS:\t\t\t{os}" );
            Console.WriteLine( $"\tCountry:\t\t{country}" );
            Console.WriteLine( $"\tTimezone Bias:\t\t{timezoneBias}" );
            Console.WriteLine( $"\tIP:\t\t\t{ip}" );
            Console.WriteLine( $"\tAccount Name Length:\t{accountNameLength}" );
            Console.WriteLine( $"\tAccount Name:\t\t{accountName}" );
            
            // Nothing else to do at this stage in development
            networkEventArgs.Cancel = true;
        }
    }
}