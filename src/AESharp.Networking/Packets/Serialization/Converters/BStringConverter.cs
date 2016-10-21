using System;
using System.IO;

namespace AESharp.Networking.Packets.Serialization.Converters
{
    public sealed class BStringConverter : BinaryConverter<string>
    {
        public override string Read( BinaryReader reader, object structure, Type type, string currentValue, int? length )
        {
            byte len = reader.ReadByte();
            return new string( reader.ReadChars( len ) );
        }

        public override void Write( BinaryWriter writer, object structure, Type type, string value, int? length )
        {
            writer.Write( (byte) value.Length );
            writer.Write( value.ToCharArray() );
        }
    }
}