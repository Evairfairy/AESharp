using System;
using System.Threading.Tasks;
using AESharp.Networking.Data;

namespace AESharp.Networking.Extensions
{
    public static class RemoteClientExtensions
    {
        public static async Task DisconnectEx( this RemoteClient client, int delay )
        {
            await client.Disconnect( TimeSpan.FromMilliseconds( delay ) );
        }
    }
}
