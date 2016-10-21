namespace AESharp.Router.Routing
{
    internal enum RoutingPacketId : byte
    {
        // General communication
        InitiateHandshake = 0,
        AcceptHandshake = 1,
        RefuseHandshake = 2,
        RegisterRouter = 3,
        RegisterComponent = 4,
        Disconnect = 5,
        KeepAlive = 6
    }
}