using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization.Transformers
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true )]
    public sealed class ReverseAttribute : TransformAttribute
    {
        private static readonly Type StringType;

        static ReverseAttribute()
        {
            StringType = typeof( string );
        }

        public override bool CanTransform( Type type )
            => type == StringType;

        public override object Transform( object value )
        {
            var str = value as string;
            return new String( str.Reverse().ToArray() );
        }
    }
}
