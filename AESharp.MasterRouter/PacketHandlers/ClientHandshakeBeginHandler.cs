using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AESharp.Routing.Core;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Handlers;
using AESharp.Routing.Networking.Packets.Handshaking;
using AESharp.Routing.Networking.Packets.Objects;

namespace AESharp.MasterRouter.PacketHandlers
{
    public static class ClientHandshakeBeginHandler
    {
        private static bool SendToOtherComponentsPredicate(AERoutingClient context, AERoutingClient item)
        {
            // Only send if it's a real component (i.e. not a player etc)
            return item.ComponentData.IsRealComponent;
        }

        public static async Task HandleClientHandshakeBegin(ClientHandshakeBeginPacket packet,
            AERoutingClient context)
        {
            //await HandshakeHandlers.ClientHandshakeBeginHandler( packet, context );

            if (!HandshakeHandlers.ValidateHandshakeProtocol(packet))
            {
                Console.WriteLine(
                    $"Invalid protocol (got: {packet.Protocol}) (exp: {Constants.LatestAEProtocolVersion})");
                context.Disconnect();
                return;
            }

            if (!HandshakeHandlers.ValidateHandshakeAuthentication(packet))
            {
                Console.WriteLine(
                    $"Authentication failure (got: {packet.Password}) (exp: {Constants._TEMP_RouterAuthPassword})");
                context.Disconnect();
                return;
            }

            context.Authenticated = true;
            context.ComponentData = packet.Component;
            context.ComponentData.Guid = Guid.NewGuid();

            Console.WriteLine($"Successfully authenticated {context.ComponentData.Guid}");

            List<AERoutingClient> clients =
                MasterRouterServices.RemoteClients.GetClients(
                    item =>
                        SendToOtherComponentsPredicate(context,
                            item));

            ServerObjectAvailabilityChanged snoap = new ServerObjectAvailabilityChanged
            {
                RoutingObject = context.ComponentData,
                Available = true
            };

            await context.SendPayloadToComponents(clients, snoap.PacketId, snoap.FinalizePacket().Payload);
        }
    }
}