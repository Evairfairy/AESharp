using System;
using System.Threading.Tasks;
using AESharp.Core.Container;
using AESharp.Routing.Exceptions;

namespace AESharp.Routing.Networking.Packets
{
    public class AEPacketHandler<TPacketContext>
    {
        private readonly ThreadSafeDictionary<
            AEPacketId,
            Func<AEPacket, TPacketContext, Task>
        > _handlers = new ThreadSafeDictionary<
            AEPacketId,
            Func<AEPacket, TPacketContext, Task>
        >();

        protected bool IsMasterServer { get; }

        public AEPacketHandler( bool isMasterServer )
        {
            this.IsMasterServer = isMasterServer;
        }

        public void RegisterHandler( AEPacketId id, Func<AEPacket, TPacketContext, Task> handler )
        {
            this._handlers.ReplaceOrAdd( id, handler );
        }

        public async Task HandlePacket( AEPacket packet, TPacketContext context )
        {
            if ( !this._handlers.ContainsKey( packet.PacketId ) )
            {
                throw new UnhandledAEPacketException( (int) packet.PacketId );
            }

            Func<AEPacket, TPacketContext, Task> handler = this._handlers.Get( packet.PacketId );

            await handler( packet, context );
        }

        public void ThrowIfRequiredHandlerNotRegistered()
        {
            foreach ( AEPacketId id in Enum.GetValues( typeof( AEPacketId ) ) )
            {
                if ( id.ToString().StartsWith( "Client" ) )
                {
                    // The client doesn't need to handle client-only packets
                    if ( !this.IsMasterServer )
                    {
                        continue;
                    }
                }

                if ( id.ToString().StartsWith( "Server" ) )
                {
                    // The server doesn't need to handle server-only packets
                    if ( this.IsMasterServer )
                    {
                        continue;
                    }
                }

                this.ThrowIfHandlerNotRegistered( id );
            }
        }

        private void ThrowIfHandlerNotRegistered( AEPacketId id )
        {
            if ( !this._handlers.ContainsKey( id ) )
            {
                throw new UnregisteredAEHandlerException( $"Unregistered handler for AEPacket {id} ({id:x})" );
            }
        }
    }
}