using System;
using System.Threading.Tasks;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Core;
using AESharp.Routing.Networking.Packets.Handshaking;

namespace AESharp.Routing.Networking.Handlers
{
    public static class HandshakeHandlers
    {
        /// <summary>
        ///     Default handler called when a ClientHandshakeBegin packet is received
        /// </summary>
        /// <param name="packet">Packet received</param>
        /// <param name="context">Context object</param>
        /// <returns>Task</returns>
        public static async Task ClientHandshakeBeginHandler( ClientHandshakeBeginPacket packet, AERoutingClient context )
        {
            if ( packet.Protocol != Constants.LatestAEProtocolVersion )
            {
                throw new InvalidPacketException(
                    $"Received handshake with protocol version {packet.Protocol} but version {Constants.LatestAEProtocolVersion} is required" );
            }

            ServerHandshakeResultPacket response = new ServerHandshakeResultPacket();
            if ( packet.Password != Constants._TEMP_RouterAuthPassword )
            {
                response.Result = ServerHandshakeResultPacket.SHRPResult.Failure;
                await context.SendDataAsync( response.FinalizePacket() );
                await context.Disconnect( TimeSpan.FromMilliseconds( 500 ) );

                return;
            }

            context.ClientGuid = Guid.NewGuid();

            response.Result = ServerHandshakeResultPacket.SHRPResult.Success;
            response.AssignedGuid = Guid.NewGuid();

            await context.SendDataAsync( response.FinalizePacket() );
        }

        public static async Task ServerHandshakeResultHandler( ServerHandshakeResultPacket packet,
            AERoutingClient context )
        {
        }
    }
}