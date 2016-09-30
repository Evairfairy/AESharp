using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization.Transformers
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true )]
    public sealed class ReverseAttribute : StringTransformerAttribute
    {
        public ReverseAttribute( SerializationMode mode = SerializationMode.Both )
            : base( mode ) { }
        
        protected override object TransformValue( object value, int? _ )
        {
            var str = value as string;
            return new String( str.Reverse().ToArray() );
        }
    }
}
