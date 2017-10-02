using System;
using System.Collections.Generic;

namespace AESharp.Routing.Core
{
    public class ComponentRepository
    {
        private readonly List<RoutingComponent> _components = new List<RoutingComponent>();

        public void AddObject(RoutingComponent obj)
        {
            if (obj.Guid == Guid.Empty)
            {
                throw new ArgumentException("Tried to add an object to the repository whose guid was empty");
            }

            lock (_components)
            {
                Console.WriteLine($"Adding new AEObject: {obj.Type}/{obj.Guid}");
                _components.Add(obj);
            }
        }

        public void RemoveObject(Guid objGuid)
        {
            lock (_components)
            {
                Console.WriteLine($"Removing AEObjects with guid: {objGuid}");
                _components.RemoveAll(x => x.Guid == objGuid);
            }
        }

        public List<RoutingComponent> GetAllObjects()
        {
            List<RoutingComponent> ret = new List<RoutingComponent>();

            lock (_components)
                ret.AddRange(_components);

            return ret;
        }
    }
}