using System;
using System.Collections.Generic;

namespace AESharp.Routing.Core
{
    public class ComponentRepository
    {
        private readonly List<RoutingComponent> _components = new List<RoutingComponent>();

        public void AddObject( RoutingComponent obj )
        {
            if ( obj.Guid == Guid.Empty )
            {
                throw new ArgumentException( "Tried to add an object to the repository whose guid was empty" );
            }

            lock ( this._components )
            {
                this._components.Add( obj );
            }
        }

        public void RemoveObject( Guid objGuid )
        {
            lock ( this._components )
            {
                this._components.RemoveAll( x => x.Guid == objGuid );
            }
        }
    }
}