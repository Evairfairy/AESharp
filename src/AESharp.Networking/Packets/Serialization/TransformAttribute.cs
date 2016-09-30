using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true )]
    public abstract class TransformAttribute : Attribute
    {
        public abstract bool CanTransform( Type type );
        public abstract object Transform( object value );

        public T Transform<T>( T value )
            => (T)this.Transform( (object)value );

        internal object TransformImpl( object value )
        {
            var type = value.GetType();
            if( !this.CanTransform( type ) )
                throw new NotSupportedException( $"Cannot transform {type.FullName}" );

            return this.Transform( value );
        }
    }
}
