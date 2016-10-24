namespace AESharp.Router.Protocol
{
    public enum RoutingPacketId : byte
    {
        // General communication
        InitiateHandshake = 0,
        AcceptHandshake = 1,
        RegisterComponent = 2,
        Disconnect = 3,
        KeepAlive = 4
    }
}