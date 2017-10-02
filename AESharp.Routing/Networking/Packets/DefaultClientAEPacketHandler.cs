using AESharp.Routing.Networking.Handlers;

namespace AESharp.Routing.Networking.Packets
{
    public class AEDefaultPacketHandler<TContext> : AEPacketHandler<TContext>
        where TContext : AERoutingClient
    {
        public void RegisterDefaultClientHandlers()
        {
            ClientHandshakeBeginHandler = HandshakeHandlers.ClientHandshakeBeginHandler;
            ServerHandshakeResultHandler = HandshakeHandlers.ServerHandshakeResultHandler;
        }
    }
}