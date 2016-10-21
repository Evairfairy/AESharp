using System;

namespace AESharp.Networking.Packets.Serialization.Transformers
{
    public enum StringSide
    {
        Start,
        End,
        Both
    }

    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true )]
    public abstract class StringTransformerAttribute : TransformerAttribute
    {
        private static readonly Type StringType;

        static StringTransformerAttribute()
        {
            StringType = typeof( string );
        }

        public StringTransformerAttribute( SerializationMode mode )
            : base( mode )
        {
        }

        protected override bool CanTransform( Type type )
            => type == StringType;
    }
}