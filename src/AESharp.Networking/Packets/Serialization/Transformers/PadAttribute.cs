using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization.Transformers
{
    public class PadAttribute : StringTransformerAttribute
    {
        public StringSide StringSide { get; }
        public char PadChar { get; }

        public PadAttribute( StringSide side, char padChar, SerializationMode mode = SerializationMode.Write )
            : base( mode )
        {
            this.StringSide = side;
            this.PadChar = padChar;
        }

        protected override object TransformValue( object value, int? length )
        {
            if( length == null )
                throw new InvalidOperationException( "Padded strings must have a fixed length attribute" );

            var str = value as string;
            switch( this.StringSide )
            {
                case StringSide.Start:
                    return str.PadLeft( length.Value, this.PadChar );
                case StringSide.End:
                    return str.PadLeft( length.Value, this.PadChar );
                case StringSide.Both:
                    {
                        var len = length.Value;
                        var left = (int)Math.Ceiling( len / 2d );
                        var right = (int)Math.Floor( len / 2d );

                        return str.PadLeft( left, this.PadChar ).PadRight( right, this.PadChar );
                    }
                default:
                    throw new NotSupportedException( this.StringSide.ToString() );
            }
        }
    }
}
