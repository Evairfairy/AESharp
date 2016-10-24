using System.Net;

namespace AESharp.Router.Routing.Components
{
    public abstract class DatabaseComponent : Component
    {
        protected DatabaseComponent( IPAddress remoteAddress )
            : base( remoteAddress )
        {
            
        }
    }
}