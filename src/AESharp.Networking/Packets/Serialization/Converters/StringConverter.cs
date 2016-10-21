using System;
using System.IO;

namespace AESharp.Networking.Packets.Serialization.Converters
{
    public enum StringPrefix
    {
        None,
        Int8,
        UInt8,
        Int16,
        UInt16,
        Int32
    }

    public enum StringTerminator
    {
        None,
        Null,
        Space
    }

    public sealed class StringConverter : BinaryConverter<string>
    {
        public StringConverter( StringPrefix prefix, StringTerminator terminator )
        {
            this.Prefix = prefix;
            this.Terminator = terminator;
        }

        public StringPrefix Prefix { get; }
        public StringTerminator Terminator { get; }

        public override string Read( BinaryReader reader, object structure, Type type, string currentValue, int? length )
        {
            switch ( this.Prefix )
            {
                case StringPrefix.Int8:
                    length = reader.ReadSByte();
                    break;
                case StringPrefix.UInt8:
                    length = reader.ReadByte();
                    break;
                case StringPrefix.Int16:
                    length = reader.ReadInt16();
                    break;
                case StringPrefix.UInt16:
                    length = reader.ReadUInt16();
                    break;
                case StringPrefix.Int32:
                    length = reader.ReadInt32();
                    break;

                default:
                    throw new NotImplementedException( this.Prefix.ToString() );
            }

            switch ( this.Terminator )
            {
                case StringTerminator.Null:
                case StringTerminator.Space:
                    reader.ReadChar(); // we don't actually care what the terminator is
                    break;
            }

            char[] buffer = reader.ReadChars( length.Value );
            return new string( buffer );
        }

        public override void Write( BinaryWriter writer, object structure, Type type, string value, int? length )
        {
            switch ( this.Prefix )
            {
                case StringPrefix.Int8:
                    writer.Write( (sbyte) value.Length );
                    break;
                case StringPrefix.UInt8:
                    writer.Write( (byte) value.Length );
                    break;
                case StringPrefix.Int16:
                    writer.Write( (short) value.Length );
                    break;
                case StringPrefix.UInt16:
                    writer.Write( (ushort) value.Length );
                    break;
                case StringPrefix.Int32:
                    writer.Write( value.Length );
                    break;

                default:
                    throw new NotImplementedException( this.Prefix.ToString() );
            }

            switch ( this.Terminator )
            {
                case StringTerminator.Null:
                    writer.Write( '\0' );
                    break;
                case StringTerminator.Space:
                    writer.Write( ' ' );
                    break;
            }

            writer.Write( value.ToCharArray() );
        }
    }
}