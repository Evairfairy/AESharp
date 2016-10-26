using System.Threading.Tasks;

namespace AESharp.Networking.Middleware
{
    public interface IMiddleware<TContext>
    {
        Task<byte[]> CallMiddlewareAsync( byte[] data, TContext context );
    }
}