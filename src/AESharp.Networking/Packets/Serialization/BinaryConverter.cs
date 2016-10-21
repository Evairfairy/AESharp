using System;
using System.IO;

namespace AESharp.Networking.Packets.Serialization
{
    public abstract class BinaryConverter
    {
        public abstract bool CanRead( Type type );
        public abstract bool CanWrite( Type type );

        public abstract object Read( BinaryReader reader, object structure, Type type, object currentValue, int? length );
        public abstract void Write( BinaryWriter writer, object structure, Type type, object value, int? length );

        internal object ReadImpl( BinaryReader reader, object structure, Type type, object currentvalue, int? length )
        {
            if ( !this.CanRead( type ) )
            {
                throw new NotSupportedException( $"Deserializer cannot read type {type.FullName}" );
            }

            return this.Read( reader, structure, type, currentvalue, length );
        }

        internal void WriteImpl( BinaryWriter writer, object structure, Type type, object value, int? length )
        {
            if ( !this.CanWrite( type ) )
            {
                throw new NotSupportedException( $"Serializer cannot write type {type.FullName}" );
            }

            this.Write( writer, structure, type, value, length );
        }
    }

    public abstract class BinaryConverter< V > : BinaryConverter<V, object>
    {
    }

    public abstract class BinaryConverter< V, S > : BinaryConverter
    {
        public override bool CanRead( Type type )
            => type == typeof( V );

        public override bool CanWrite( Type type )
            => type == typeof( V );

        public abstract V Read( BinaryReader reader, S structure, Type type, V currentValue, int? length );
        public abstract void Write( BinaryWriter writer, S structure, Type type, V value, int? length );

        public override object Read( BinaryReader reader, object structure, Type type, object currentValue, int? length )
            => this.Read( reader, (S) structure, type, (V) currentValue, length );

        public override void Write( BinaryWriter writer, object structure, Type type, object value, int? length )
            => this.Write( writer, (S) structure, type, (V) value, length );
    }
}