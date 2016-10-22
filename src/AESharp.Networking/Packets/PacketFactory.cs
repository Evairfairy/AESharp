using AESharp.Core.Interfaces;
using AESharp.Networking.Interfaces;

namespace AESharp.Networking.Packets
{
    public class PacketFactory // : IPacketFactory
    {
        private readonly ILogger _logger;
        private readonly IPacketSerializer _serializer;

        public PacketFactory( ILogger logger, IPacketSerializer serializer )
        {
            this._logger = logger;
            this._serializer = serializer;
        }
    }
}