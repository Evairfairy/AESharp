//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Threading;
//using System.Threading.Tasks;
//using AESharp.Networking.Data;
//using AESharp.Networking.Exceptions;
//using AESharp.Routing.Networking;

//namespace AESharp.Routing.Routing
//{
//    public class RoutingRemoteClient : RemoteClient
//    {
//        public const ushort RoutingPort = 10695;
//        public const ushort ProtocolVersion = 1;

//        private readonly bool OutboundMode;
//        private Guid LastKeepAliveGuid;
//        private DateTime LastKeepAliveTime;

//        public RoutingRemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
//            : base( rawClient, tokenSource )
//        {
//            this.LastKeepAliveTime = DateTime.MinValue;
//            this.LastKeepAliveGuid = Guid.Empty;
//            this.OutboundMode = false;
//            this.KeepAliveLoopAsync();
//        }

//        protected RoutingRemoteClient( IPAddress remoteAddress, CancellationTokenSource tokenSource )
//            : base( new TcpClient(), tokenSource )
//        {
//            this.ConnectToMasterRouter();
//            this.OutboundMode = true;
//        }

//        private async void ConnectToMasterRouter()
//        {
//            await this.RawClient.ConnectAsync( IPAddress.Loopback, RoutingPort );
//            InitiateHandshakePacket initiateHandshake = new InitiateHandshakePacket( ProtocolVersion );

//            await this.SendDataAsync( initiateHandshake );
//            await this.ListenForDataTask( this.CancellationToken );
//        }

//        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
//        {
//            if ( token.IsCancellationRequested )
//            {
//                return;
//            }

//            AEPacketId id = (AEPacketId) data[0];
//            Console.WriteLine(
//                $"Received {Enum.GetName( typeof( AEPacketId ), id )} packet (opcode 0x{(byte) id:X2})" );
//            switch ( id )
//            {
//                case AEPacketId.ClientHandshakeBegin:
//                {
//                    InitiateHandshakePacket packet = new InitiateHandshakePacket( data );
//                    if ( packet.ProtocolVersion != ProtocolVersion )
//                    {
//                        await this.Kick( $"Requested protocol version ({packet.ProtocolVersion}) " +
//                                         $"is different than the expected version ({ProtocolVersion})", token );
//                        break;
//                    }
//                    Console.WriteLine( $"Received handshake for protocol version {packet.ProtocolVersion}" );
//                    break;
//                }

//                case AEPacketId.UnusedKeepAlive:
//                    {
//                        KeepAlivePacket keepAlive = new KeepAlivePacket(data);
//                        if (this.OutboundMode)
//                        {
//                            // Send it back with the current timestamp
//                            Console.WriteLine("  - Responding to keep alive");
//                            await this.SendDataAsync(keepAlive.WithDateTime(DateTime.UtcNow), token);
//                        }
//                        else
//                        {
//                            Console.WriteLine("  - Validating keep alive");
//                            if (keepAlive.Guid != this.LastKeepAliveGuid)
//                            {
//                                await this.Kick("Keep alive response had the wrong GUID", token);
//                                break;
//                            }

//                            this.LastKeepAliveTime = keepAlive.TimeSent;
//                        }
//                        break;
//                    }

//                case AEPacketId.UnusedDisconnect:
//                    {
//                        DisconnectPacket disconnect = new DisconnectPacket(data);
//                        Console.WriteLine($"Client kicked. Reason: {disconnect.Reason}");

//                        if (!this.Connected)
//                        {
//                            await this.Disconnect(TimeSpan.FromMilliseconds(100));
//                        }

//                        break;
//                    }

//                default:
//                    throw new InvalidPacketException(
//                        $"Received unknown or unimplemented packet (opcode: 0x{(byte) id:X2})" );
//            }
//        }

//        private async void KeepAliveLoopAsync()
//        {
//            TimeSpan timeout = TimeSpan.FromSeconds( 15 );
//            TimeSpan gracePeriod = TimeSpan.FromSeconds( 1 ); // 1 second grace period to allow for latency
//            while ( this.Connected && !this.CancellationToken.IsCancellationRequested )
//            {
//                if ( ( this.LastKeepAliveTime != DateTime.MinValue ) &&
//                     ( this.LastKeepAliveTime + timeout + gracePeriod < DateTime.UtcNow ) )
//                {
//                    Console.WriteLine( this.LastKeepAliveTime );
//                    Console.WriteLine( this.LastKeepAliveTime + timeout );
//                    Console.WriteLine( DateTime.UtcNow );
//                    await this.Kick( "Timed out", this.CancellationToken );
//                    break;
//                }

//                this.LastKeepAliveTime = DateTime.UtcNow;
//                this.LastKeepAliveGuid = Guid.NewGuid();
//                KeepAlivePacket packet = new KeepAlivePacket( this.LastKeepAliveTime, this.LastKeepAliveGuid );

//                await this.SendDataAsync( packet, this.CancellationToken );
//                await Task.Delay( timeout );
//            }
//        }

//        private async Task Kick( string reason, CancellationToken token )
//        {
//            DisconnectPacket packet = new DisconnectPacket( reason );
//            await this.SendDataAsync( packet, token );
//            await this.Disconnect( TimeSpan.FromMilliseconds( 100 ) );
//        }
//    }
//}

