using System.Threading.Tasks;

namespace AESharp.Networking.Middleware
{
    public interface IMiddleware<TMetaPacket, TContext> where TMetaPacket : MetaPacket
    {
        Task<TMetaPacket> CallMiddlewareAsync( TMetaPacket packet, TContext context );
    }
}