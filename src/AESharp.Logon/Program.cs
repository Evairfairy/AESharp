using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using AESharp.Core.Interfaces;
using AESharp.Core.Interfaces.Networking;
using AESharp.Logon.Networking;
using AESharp.Networking;
using AESharp.Networking.Events;
using AESharp.Networking.Packets;
using AESharp.Networking.Packets.Serialization;
using AESharp.Logon.Networking.PacketHandlers;
using SimpleInjector;

namespace AESharp.Logon
{
    public static class Program
    {
        private sealed class PacketDefinition
        {
            public Type PacketType { get; }
            public IPacketHandler Handler { get; }

            public PacketDefinition( Type packetType, IPacketHandler handler )
            {
                this.PacketType = packetType;
                this.Handler = handler;
            }
        }

        private static readonly Dictionary<PacketId, PacketDefinition> PacketTypes;
        private static Container _container;

        static Program()
        {
            PacketTypes = new Dictionary<PacketId, PacketDefinition>
            {
                [PacketId.Challenge] =
                new PacketDefinition( typeof( LogonChallengePacket ), new ChallengePacketHandler() ),
            };
        }

        public static void Main( string[] args )
        {
            _container = new Container();

            // Build (de)serializers before they're needed to speed up packet reads/writes
            PacketSerialization packetSerializer = new PacketSerialization();
            var packetTypes = PacketTypes.Values.Select( t => t.PacketType );
            packetSerializer.CacheObjects( packetTypes );

            _container.RegisterSingleton( typeof( IPacketSerializer ), packetSerializer );
            _container.RegisterSingleton<INetworkEngine, LogonNetworkEngine>();

            _container.Verify();

            AETcpServer server = _container.GetInstance<AETcpServer>();
            server.StartListening( IPAddress.Any, 3724 );

            server.ReceiveData += ServerOnReceiveData;

            Console.WriteLine( "Listening..." );
            Console.ReadLine();
        }

        private static void ServerOnReceiveData( object sender, NetworkEventArgs networkEventArgs )
        {
            IPacketSerializer serializer = _container.GetInstance<IPacketSerializer>();

            PacketId packetId = (PacketId) networkEventArgs.DataStream.ReadByte();
            PacketDefinition definition;
            if ( !PacketTypes.TryGetValue( packetId, out definition ) )
            {
                Console.Error.WriteLine( "Unknown packet 0x{0:X2}", (int) packetId );
                networkEventArgs.DisconnectClient = true;
                return;
            }
            
            object packet = serializer.DeserializePacket( definition.PacketType, networkEventArgs.DataStream, null );
            networkEventArgs.DisconnectClient = !definition.Handler.HandlePacket( packet );

            // Nothing else to do at this stage in development
            //networkEventArgs.DisconnectClient = true;
        }
    }
}