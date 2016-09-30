using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization.Transformers
{
    [AttributeUsage( AttributeTargets.Property | AttributeTargets.Field )]
    public class TrimAttribute : StringTransformerAttribute
    {
        private static readonly char[] TrimChars;

        static TrimAttribute()
        {
            TrimChars = new[] {  ' ', '\0' };
        }

        public StringSide StringSide { get; }

        public TrimAttribute( StringSide side = StringSide.Both, SerializationMode mode = SerializationMode.Read )
            : base( mode )
        {
            this.StringSide = side;
        }

        protected override object TransformValue( object value, int? _ )
        {
            var str = value as string;

            switch( this.StringSide )
            {
                case StringSide.Start:
                    return str.TrimStart( TrimChars );
                case StringSide.End:
                    return str.TrimEnd( TrimChars );
                case StringSide.Both:
                    return str.Trim( TrimChars );
                default:
                    throw new NotSupportedException( this.StringSide.ToString() );
            }
        }
    }
}
