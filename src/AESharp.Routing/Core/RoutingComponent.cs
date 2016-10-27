using System;
using System.Collections.Generic;

namespace AESharp.Routing.Core
{
    public class RoutingComponent
    {
        public Guid Guid = Guid.Empty;
        public List<RoutingComponent> OwnedObjects = new List<RoutingComponent>();
        public ComponentType Type = ComponentType.Invalid;
    }
}