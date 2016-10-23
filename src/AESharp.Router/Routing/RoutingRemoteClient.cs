using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;
using AESharp.Router.Routing.Packets;

namespace AESharp.Router.Routing
{
    internal sealed class RoutingRemoteClient : RemoteClient
    {
        public const ushort RoutingPort = 10695;
        public const ushort ProtocolVersion = 1;

        public RoutingRemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
            : base( rawClient, tokenSource )
        {
        }

        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            if ( token.IsCancellationRequested )
            {
                return;
            }

            RoutingPacketId id = (RoutingPacketId) data[0];
            switch ( id )
            {
                case RoutingPacketId.InitiateHandshake:
                {
                    InitiateHandshakePacket packet = new InitiateHandshakePacket( data );
                    if ( packet.ProtocolVersion != ProtocolVersion )
                    {
                        DisconnectPacket disconnect = new DisconnectPacket(
                            $"Requested protocol version ({packet.ProtocolVersion}) " +
                            $"is different than the expected version ({ProtocolVersion})" );

                        await this.SendPacketAsync( disconnect, token );
                        await this.Disconnect( TimeSpan.FromMilliseconds( 100 ) );
                    }
                    break;
                }

                default:
                    throw new InvalidPacketException(
                        $"Received unknown or unimplemented packet (opcode: 0x{(byte) id:X2})" );
            }
        }

        private void InitiateHandshakeHandler( InitiateHandshakePacket packet )
        {
        }
    }
}