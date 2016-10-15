using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AESharp.Networking.Packets.Serialization.Converters
{
    public sealed class BStringConverter : BinaryConverter<string>
    {
        public override string Read( BinaryReader reader, object structure, Type type, string currentValue, int? length )
        {
            byte len = reader.ReadByte();
            return new String( reader.ReadChars( len ) );
        }

        public override void Write( BinaryWriter writer, object structure, Type type, string value, int? length )
        {
            writer.Write( (byte)value.Length );
            writer.Write( value.ToCharArray() );
        }
    }
}
