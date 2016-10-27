using AESharp.Routing.Networking.Handlers;

namespace AESharp.Routing.Networking.Packets
{
    public class AEDefaultPacketHandler<TContext> : AEPacketHandler<TContext>
            where TContext : AERoutingClient
    {
        public void RegisterDefaultClientHandlers()
        {
            this.ClientHandshakeBeginHandler = HandshakeHandlers.ClientHandshakeBeginHandler;
            this.ServerHandshakeResultHandler = HandshakeHandlers.ServerHandshakeResultHandler;
        }
    }
}