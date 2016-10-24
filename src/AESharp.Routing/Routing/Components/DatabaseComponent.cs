using System.Net;

namespace AESharp.Routing.Routing.Components
{
    public abstract class DatabaseComponent : Component
    {
        protected DatabaseComponent( IPAddress remoteAddress )
            : base( remoteAddress )
        {
        }
    }
}