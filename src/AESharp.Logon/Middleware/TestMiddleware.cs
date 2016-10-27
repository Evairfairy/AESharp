using System;
using System.Threading.Tasks;
using AESharp.Networking.Middleware;

namespace AESharp.Logon.Middleware
{
    public class TestMiddleware : IMiddleware<LogonRemoteClient>
    {
        public async Task<byte[]> CallMiddlewareAsync( byte[] data, LogonRemoteClient context )
        {
            Console.WriteLine( $"[{context.ClientGuid}]: handling {data.Length} bytes" );

            return data;
        }
    }
}