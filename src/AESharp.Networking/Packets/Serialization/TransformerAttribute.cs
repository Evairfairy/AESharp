using System;

namespace AESharp.Networking.Packets.Serialization
{
    [Flags]
    public enum SerializationMode
    {
        Read = 1 << 0,
        Write = 1 << 1,
        Both = Read | Write
    }

    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true )]
    public abstract class TransformerAttribute : Attribute
    {
        public TransformerAttribute( SerializationMode mode )
        {
            this.SerializationMode = mode;
        }

        public SerializationMode SerializationMode { get; }
        protected abstract bool CanTransform( Type type );

        protected abstract object TransformValue( object value, int? length );

        internal object Transform( object value, int? length )
        {
            Type type = value.GetType();
            if ( !this.CanTransform( type ) )
            {
                throw new NotSupportedException( $"Cannot transform {type.FullName}" );
            }

            return this.TransformValue( value, length );
        }
    }
}