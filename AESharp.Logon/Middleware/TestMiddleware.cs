using System;
using System.Threading.Tasks;
using AESharp.Logon.Universal.Networking.Middleware;
using AESharp.Networking.Middleware;

namespace AESharp.Logon.Middleware
{
    public class TestMiddleware : IMiddleware<LogonMetaPacket, LogonRemoteClient>
    {
        public async Task<LogonMetaPacket> CallMiddlewareAsync(LogonMetaPacket metaPacket, LogonRemoteClient context)
        {
            Console.WriteLine($"[{context.ClientGuid}]: handling {metaPacket.Payload.Length} bytes");

            return metaPacket;
        }
    }
}