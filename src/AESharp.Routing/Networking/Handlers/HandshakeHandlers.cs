using System;
using System.Threading.Tasks;
using AESharp.Networking.Exceptions;
using AESharp.Routing.Core;
using AESharp.Routing.Networking.Packets.Handshaking;

namespace AESharp.Routing.Networking.Handlers
{
    public static class HandshakeHandlers
    {
        public static bool ValidateHandshakeProtocol( ClientHandshakeBeginPacket packet )
        {
            return packet.Protocol == Constants.LatestAEProtocolVersion;
        }

        public static bool ValidateHandshakeAuthentication( ClientHandshakeBeginPacket packet )
        {
            return packet.Password == Constants._TEMP_RouterAuthPassword;
        }

        /// <summary>
        ///     Default handler called when a ClientHandshakeBegin packet is received
        /// </summary>
        /// <param name="packet">Packet received</param>
        /// <param name="context">Context object</param>
        /// <returns>Task</returns>
        public static async Task ClientHandshakeBeginHandler( ClientHandshakeBeginPacket packet, AERoutingClient context )
        {
            Console.WriteLine( "Received AE# handshake" );
            if ( !ValidateHandshakeProtocol( packet ) )
            {
                throw new InvalidPacketException(
                    $"Received handshake with protocol version {packet.Protocol} but version {Constants.LatestAEProtocolVersion} is required" );
            }

            ServerHandshakeResultPacket response = new ServerHandshakeResultPacket();
            if ( !ValidateHandshakeAuthentication( packet ) )
            {
                Console.WriteLine(
                    $"Password does not match (expected: {Constants._TEMP_RouterAuthPassword}) (got: {packet.Password})" );
                response.Result = ServerHandshakeResultPacket.SHRPResult.Failure;
                await context.SendDataAsync( response.FinalizePacket() );
                context.Disconnect();

                return;
            }

            context.Authenticated = true;
            context.ComponentData = packet.Component;

            // Overwrite any existing guid - master router should dictate this
            context.ComponentData.Guid = Guid.NewGuid();

            Console.WriteLine( $"Password matched, allocating guid: {context.ComponentData.Guid}" );
            Console.WriteLine( $"Got component of type {context.ComponentData.Type}" );
            Console.WriteLine( $"Component owns {context.ComponentData.OwnedObjects.Count} objects" );

            response.Result = ServerHandshakeResultPacket.SHRPResult.Success;
            response.OurComponent = context.ComponentData;
            response.OtherAvailableComponents = context.ObjectRepository.GetAllObjects();

            context.ObjectRepository.AddObject( context.ComponentData );

            await context.SendDataAsync( response.FinalizePacket() );
        }

        public static async Task ServerHandshakeResultHandler( ServerHandshakeResultPacket packet,
            AERoutingClient context )
        {
            Console.WriteLine( "Received AE# handshake result" );
            if ( packet.Result == ServerHandshakeResultPacket.SHRPResult.Failure )
            {
                Console.WriteLine( $"Failed to authenticate with master router (reason: generic failure)" );
                context.Disconnect();
                return;
            }

            if ( packet.Result == ServerHandshakeResultPacket.SHRPResult.Success )
            {
                // Authenticated
                context.ComponentData = packet.OurComponent;

                foreach ( RoutingComponent component in packet.OtherAvailableComponents )
                {
                    context.ObjectRepository.AddObject( component );
                }

                context.Authenticated = true;
                Console.WriteLine( $"Authenticated successfully, we have guid: {context.ClientGuid}" );

                context.ObjectRepository.AddObject( context.ComponentData );
            }
        }
    }
}