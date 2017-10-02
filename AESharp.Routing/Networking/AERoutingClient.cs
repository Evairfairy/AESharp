using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Networking.Middleware;
using AESharp.Routing.Core;
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

        public readonly ComponentRepository ObjectRepository;

        public bool Authenticated = false;
        public RoutingComponent ComponentData = new RoutingComponent();

        public new Guid ClientGuid
        {
            get => ComponentData.Guid;
            set => ComponentData.Guid = value;
        }

        public AERoutingClient(TcpClient rawClient, AEPacketHandler<AERoutingClient> handler,
            MiddlewareHandler<RoutingMetaPacket, AERoutingClient> incomingMiddlewareHandler,
            MiddlewareHandler<RoutingMetaPacket, AERoutingClient> outgoingMiddlewareHandler,
            ComponentRepository objectRepository) : base(rawClient)
        {
            _handler = handler;
            _incomingMiddlewareHandler = incomingMiddlewareHandler;
            _outgoingMiddlewareHandler = outgoingMiddlewareHandler;
            ObjectRepository = objectRepository;
        }

        public async Task SendPayloadToComponents(IEnumerable<AERoutingClient> clients, AEPacketId id, byte[] payload)
        {
            foreach (AERoutingClient client in clients)
            {
                // Sending packets to ourself is not valid
                if (client.ComponentData.Guid == ComponentData.Guid)
                {
                    continue;
                }

                // Copy this in case middleware modifies the payload (todo: change model to preserve payload)
                byte[] payloadCopy = new byte[payload.Length];
                Array.Copy(payload, payloadCopy, payloadCopy.Length);

                RoutingMetaPacket metaPacket = new RoutingMetaPacket
                {
                    PacketId = id,
                    Payload = payloadCopy,
                    Sender = ComponentData.Guid,
                    Target = client.ComponentData.Guid
                };

                await SendDataAsync(metaPacket);
            }
        }

        public override async Task SendDataAsync(RoutingMetaPacket metaPacket)
        {
            await _outgoingMiddlewareHandler.RunMiddlewareAsync(metaPacket, this);

            if (metaPacket.Handled)
            {
                Console.WriteLine("Finished handling outgoing AEPacket in middleware");
                return;
            }

            await base.SendDataAsync(metaPacket);
        }

        public override async Task HandleDataAsync(RoutingMetaPacket metaPacket)
        {
            await _incomingMiddlewareHandler.RunMiddlewareAsync(metaPacket, this);

            if (metaPacket.Handled)
            {
                Console.WriteLine($"Finished handling incoming AEPacket in middleware");
                return;
            }

            try
            {
                await _handler.HandlePacket(metaPacket, this);
            }
            // Server sent an unknown packet id
            // This should never happen so rethrow
            catch (UnhandledAEPacketException ex)
            {
                Console.WriteLine(ex);
                Disconnect();
                throw;
            }
            // Server sent a known packet id but we're not handling it
            catch (UnregisteredAEHandlerException ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}