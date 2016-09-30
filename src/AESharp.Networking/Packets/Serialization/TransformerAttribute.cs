using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization
{
    [Flags]
    public enum SerializationMode
    {
        Read = 1 << 0,
        Write = 1 << 1,
        Both = Read | Write,
    }

    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true )]
    public abstract class TransformerAttribute : Attribute
    {
        protected abstract bool CanTransform( Type type );

        public SerializationMode SerializationMode { get; }

        public TransformerAttribute( SerializationMode mode )
        {
            this.SerializationMode = mode;
        }

        protected abstract object TransformValue( object value, int? length );

        internal object Transform( object value, int? length )
        {
            var type = value.GetType();
            if( !this.CanTransform( type ) )
                throw new NotSupportedException( $"Cannot transform {type.FullName}" );

            return this.TransformValue( value, length );
        }
    }
}
