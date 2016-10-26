using System.Threading.Tasks;

namespace AESharp.Networking.Middleware
{
    public abstract class Middleware<TContext> : IMiddleware<TContext>
    {
        public abstract Task<byte[]> CallMiddlewareAsync( byte[] data, TContext context );
    }
}