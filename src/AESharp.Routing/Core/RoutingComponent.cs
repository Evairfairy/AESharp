using System;
using System.Collections.Generic;

namespace AESharp.Routing.Core
{
    public class RoutingComponent
    {
        public Guid Guid = Guid.Empty;
        public List<RoutingComponent> OwnedObjects = new List<RoutingComponent>();
        public ComponentType Type = ComponentType.Invalid;

        public bool IsRealComponent
        {
            get
            {
                switch ( this.Type )
                {
                    case ComponentType.MasterRouter:
                    case ComponentType.UniversalAuthServer:
                    case ComponentType.UniversalWorldServer:
                        return true;
                    default:
                        return false;
                }
            }
        }
    }
}