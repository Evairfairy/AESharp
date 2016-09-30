using System;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Collections.Generic;
using AESharp.Core.Extensions;
using AESharp.Networking;
using AESharp.Networking.Data;
using AESharp.Networking.Events;
using AESharp.Networking.Packets.Serialization;
using AESharp.Networking.Packets;

namespace AESharp.Logon
{
    public static class Program
    {
        private static readonly Dictionary<PacketId, Type> PacketTypes;

        static Program()
        {
            PacketTypes = new Dictionary<PacketId, Type>
            {
                [PacketId.Logon] = typeof( LogonPacket ),
            };
        }

        public static void Main( string[] args )
        {
            // Build (de)serializers before they're needed to speed up packet reads/writes
            PacketSerialization.CacheObjects( typeof( LogonPacket ) );

            AETcpServer server = new AETcpServer( IPAddress.Any, 3724 );
            server.StartListening();

            server.ReceiveData += ServerOnReceiveData;

            Console.WriteLine( "Listening..." );
            Console.ReadLine();
        }

        private static void ServerOnReceiveData( object sender, NetworkEventArgs networkEventArgs )
        {
            var packetId = (PacketId)networkEventArgs.Stream.ReadByte();
            Type type;
            if( !PacketTypes.TryGetValue( packetId, out type ) )
            {
                Console.Error.WriteLine( "Unknown packet 0x{0:X2}", (int)packetId );
                networkEventArgs.Cancel = true;
                return;
            }

            var packet = (LogonPacket)PacketSerialization.DeserializeObject( type, networkEventArgs.Stream );

            Console.WriteLine( "Received logon packet:" );
            Console.WriteLine( $"\tOpcode:\t\t\t{packetId}" );
            Console.WriteLine( $"\tError:\t\t\t{packet.Error}" );
            Console.WriteLine( $"\tLength:\t\t\t{packet.Length}" );
            Console.WriteLine( $"\tGame:\t\t\t{packet.Game}" );
            Console.WriteLine( $"\tBuild:\t\t\t{packet.Build}" );
            Console.WriteLine( $"\tPlatform:\t\t{packet.Platform}" );
            Console.WriteLine( $"\tOS:\t\t\t{packet.OS}" );
            Console.WriteLine( $"\tCountry:\t\t{packet.Country}" );
            Console.WriteLine( $"\tTimezone Bias:\t\t{packet.TimezoneBias}" );
            Console.WriteLine( $"\tIP:\t\t\t{packet.IPAddress}" );
            Console.WriteLine( $"\tAccount Name:\t\t{packet.AccountName}" );

            // Nothing else to do at this stage in development
            networkEventArgs.Cancel = true;

            //NetworkPacket packet = new NetworkPacket(networkEventArgs.Data);

            //Console.WriteLine($"Reading 4 byte header");

            //int opcode = packet.ReadByte();
            //int error = packet.ReadByte();
            //int length = packet.ReadShort();
            //string game = packet.ReadFixedString( 4 ).Flip();
            //string build = $"{packet.ReadByte()}.{packet.ReadByte()}.{packet.ReadByte()} {packet.ReadShort()}";
            //string platform = packet.ReadFixedString( 4 ).Flip();
            //string os = packet.ReadFixedString( 4 ).Flip();
            //string country = packet.ReadFixedString( 4 ).Flip();
            //uint timezoneBias = packet.ReadUInt();
            //string ip = $"{packet.ReadByte()}.{packet.ReadByte()}.{packet.ReadByte()}.{packet.ReadByte()}";
            //byte accountNameLength = packet.ReadByte();
            //string accountName = packet.ReadFixedString( accountNameLength );

            //Console.WriteLine( $"Received logon packet:" );
            //Console.WriteLine( $"\tOpcode:\t\t\t{opcode}" );
            //Console.WriteLine( $"\tError:\t\t\t{error}" );
            //Console.WriteLine( $"\tLength:\t\t\t{length}" );
            //Console.WriteLine( $"\tGame:\t\t\t{game}" );
            //Console.WriteLine( $"\tBuild:\t\t\t{build}" );
            //Console.WriteLine( $"\tPlatform:\t\t{platform}" );
            //Console.WriteLine( $"\tOS:\t\t\t{os}" );
            //Console.WriteLine( $"\tCountry:\t\t{country}" );
            //Console.WriteLine( $"\tTimezone Bias:\t\t{timezoneBias}" );
            //Console.WriteLine( $"\tIP:\t\t\t{ip}" );
            //Console.WriteLine( $"\tAccount Name Length:\t{accountNameLength}" );
            //Console.WriteLine( $"\tAccount Name:\t\t{accountName}" );

        }
    }
}