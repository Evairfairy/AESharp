using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace AESharp.Router.Routing.Components
{
    public abstract class Component : RoutingRemoteClient
    {
        protected Component( IPAddress remoteAddress )
            : base( remoteAddress, new CancellationTokenSource() )
        {
        }

        public override Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            return base.HandleDataAsync( data, token );
        }
    }
}