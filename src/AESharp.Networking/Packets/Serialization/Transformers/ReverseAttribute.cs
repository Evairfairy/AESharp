using System;
using System.Linq;

namespace AESharp.Networking.Packets.Serialization.Transformers
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true )]
    public sealed class ReverseAttribute : StringTransformerAttribute
    {
        public ReverseAttribute( SerializationMode mode = SerializationMode.Both )
            : base( mode )
        {
        }

        protected override object TransformValue( object value, int? _ )
        {
            string str = value as string;
            return new string( str.Reverse().ToArray() );
        }
    }
}