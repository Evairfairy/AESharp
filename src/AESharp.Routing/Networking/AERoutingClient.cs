﻿using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Networking.Middleware;
using AESharp.Routing.Exceptions;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking.Packets;

namespace AESharp.Routing.Networking
{
    public class AERoutingClient : RemoteClient<RoutingMetaPacket>
    {
        private readonly AEPacketHandler<AERoutingClient> _handler;
        private readonly MiddlewareHandler<RoutingMetaPacket, AERoutingClient> _incomingMiddlewareHandler;
        private readonly MiddlewareHandler<RoutingMetaPacket, AERoutingClient> _outgoingMiddlewareHandler;

        public bool Authenticated = false;

        public AERoutingClient( TcpClient rawClient, AEPacketHandler<AERoutingClient> handler,
            MiddlewareHandler<RoutingMetaPacket, AERoutingClient> incomingMiddlewareHandler,
            MiddlewareHandler<RoutingMetaPacket, AERoutingClient> outgoingMiddlewareHandler ) : base( rawClient )
        {
            this._handler = handler;
            this._incomingMiddlewareHandler = incomingMiddlewareHandler;
            this._outgoingMiddlewareHandler = outgoingMiddlewareHandler;
        }

        public override async Task SendDataAsync( RoutingMetaPacket metaPacket )
        {
            await this._outgoingMiddlewareHandler.RunMiddlewareAsync( metaPacket, this );

            if ( metaPacket.Handled )
            {
                Console.WriteLine( "Finished handling outgoing AEPacket in middleware" );
                return;
            }

            await base.SendDataAsync( metaPacket );
        }

        public override async Task HandleDataAsync( RoutingMetaPacket metaPacket )
        {
            await this._incomingMiddlewareHandler.RunMiddlewareAsync( metaPacket, this );

            if ( metaPacket.Handled )
            {
                Console.WriteLine( $"Finished handling incoming AEPacket in middleware" );
                return;
            }

            try
            {
                await this._handler.HandlePacket( metaPacket, this );
            }
            // Server sent an unknown packet id
            // This should never happen so rethrow
            catch ( UnhandledAEPacketException ex )
            {
                Console.WriteLine( ex );
                this.Disconnect();
                throw;
            }
            // Server sent a known packet id but we're not handling it
            catch ( UnregisteredAEHandlerException ex )
            {
                Console.WriteLine( ex );
            }
        }
    }
}