namespace AESharp.Networking.Interfaces
{
    public interface IRealPacket
    {
        byte[] InternalBuffer { get; }
        int BufferPosition { get; set; }

        byte[] ReadBytes( int count );
        byte ReadByte();
        char ReadChar();
        bool ReadBool();
        short ReadShort();
        ushort ReadUShort();
        int ReadInt();
        uint ReadUInt();
        long ReadLong();
        ulong ReadULong();
        string ReadFixedString( int len );
        string ReadCString();

        void WriteBytes( byte[] val );
        void WriteByte( byte val );
        void WriteChar( char val );
        void WriteBool( bool val );
        void WriteShort( short val );
        void WriteUShort( ushort val );
        void WriteInt( int val );
        void WriteUInt( uint val );
        void WriteLong( long val );
        void WriteULong( ulong val );

        byte[] BuildPacket();
    }
}