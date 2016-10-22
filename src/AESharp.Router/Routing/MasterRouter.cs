using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;
using AESharp.Networking;
using AESharp.Networking.Events;
using AESharp.Networking.Interfaces;
using AESharp.Networking.Packets;
using AESharp.Networking.Packets.Serialization;
using AESharp.Router.Routing.Packets.Handlers;

namespace AESharp.Router.Routing
{
    public sealed class MasterRouter
    {
        public const ushort ListenPort = 10695;
        public const ushort ProtocolVersion = 1;

        private static readonly ReadOnlyDictionary<RoutingPacketId, IPacketHandler> _packets;
        private static MasterRouter _instance;

        private readonly IPacketSerializer _serializer;

        static MasterRouter()
        {
            Dictionary<RoutingPacketId, IPacketHandler> packets = new Dictionary<RoutingPacketId, IPacketHandler>
            {
                [RoutingPacketId.InitiateHandshake] = new InitiateHandshakePacketHandler()
            };

            _packets = new ReadOnlyDictionary<RoutingPacketId, IPacketHandler>( packets );
        }

        private MasterRouter()
        {
            // Client-mode constructor
        }

        // Server-mode constructor
        internal MasterRouter( IPAddress address )
        {
            PacketSerialization serializer = new PacketSerialization();
            IEnumerable<Type> types = _packets.Select( p => p.Value.Type );
            serializer.CacheObjects( types );

            this._serializer = serializer;
        }

        public static MasterRouter Instance => _instance ?? ( _instance = new MasterRouter() );

        internal void StartServer()
        {
            RoutingNetworkEngine networkEngine = new RoutingNetworkEngine();
            TcpServer server = new TcpServer( IPAddress.Any, ListenPort, networkEngine, this._serializer );

            server.ReceiveData += this.Server_ReceiveData;
            server.Start();
        }

        private void Server_ReceiveData( object sender, NetworkEventArgs e )
        {
            RoutingPacketId id = (RoutingPacketId) e.DataStream.ReadByte();

            IPacketHandler handler;
            if ( !_packets.TryGetValue( id, out handler ) )
            {
                e.DisconnectClient = true;
                return;
            }

            object packet = this._serializer.DeserializePacket( handler.Type, e.DataStream, Encoding.UTF8 );
            PacketHandlerResult result = handler.HandlePacket( packet );

            if ( result.ResponsePacket != null )
            {
                e.Client.SendPacket( result.ResponsePacket );
            }

            if ( result.DisconnectClient )
            {
                e.DisconnectClient = result.DisconnectClient;
            }
            else
            {
                e.Client.HandleIncomingPackets();
            }
        }
    }
}