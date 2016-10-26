using System.Collections.Generic;
using System.Threading.Tasks;

namespace AESharp.Networking.Middleware
{
    public class MiddlewareHandler<TContext>
    {
        private readonly List<IMiddleware<TContext>> _middleware = new List<IMiddleware<TContext>>();

        public void RegisterMiddleware( IMiddleware<TContext> middleware )
        {
            this._middleware.Add( middleware );
        }

        public async Task<byte[]> RunMiddlewareAsync( byte[] data, TContext context )
        {
            foreach ( IMiddleware<TContext> middleware in this._middleware )
            {
                data = await middleware.CallMiddlewareAsync( data, context );

                if ( data == null )
                {
                    break;
                }
            }

            return data;
        }
    }
}