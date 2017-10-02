using System.Threading.Tasks;
using AESharp.Routing.Networking.Packets.Objects;

namespace AESharp.Routing.Networking.Handlers
{
    public static class ObjectHandlers
    {
        public static async Task HandleServerNewObjectAvailable(ServerObjectAvailabilityChanged packet,
            AERoutingClient context)
        {
            if (packet.Available)
                context.ObjectRepository.AddObject(packet.RoutingObject);
            else
                context.ObjectRepository.RemoveObject(packet.RoutingObject.Guid);
        }
    }
}