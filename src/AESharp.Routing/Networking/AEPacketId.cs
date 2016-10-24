namespace AESharp.Routing.Networking
{
    public enum AEPacketId
    {
        // General communication
        ClientHandshakeBegin = 0,
        ServerHandshakeResult = 1,
        ClientHandshakeResult = 2,
        Disconnect = 3,
        KeepAlive = 4
    }
}