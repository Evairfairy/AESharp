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
                Console.WriteLine( $"Adding new AEObject: {obj.Type}/{obj.Guid}" );
                this._components.Add( obj );
            }
        }

        public void RemoveObject( Guid objGuid )
        {
            lock ( this._components )
            {
                Console.WriteLine( $"Removing AEObjects with guid: {objGuid}" );
                this._components.RemoveAll( x => x.Guid == objGuid );
            }
        }

        public List<RoutingComponent> GetAllObjects()
        {
            List<RoutingComponent> ret = new List<RoutingComponent>();

            lock ( this._components )
            {
                ret.AddRange( this._components );
            }

            return ret;
        }
    }
}