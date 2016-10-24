using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;

namespace AESharp.Logon.Universal.Networking.Packets
{
    public class ChallengeResponsePacket : Packet
    {
        public enum ChallengeResponseError : byte
        {
            Success = 0x0,
            IPBanned = 0x1,
            AccountClosed = 0x3,
            NoSuchAccount = 0x4,
            AccountInUse = 0x6,
            PreorderTimeLimit = 0x7,
            ServerFull = 0x8,
            InvalidBuild = 0x9,
            ClientUpdateRequired = 0xa,
            AccountFrozen = 0xc,
            Invalid = 0xff
        }

        public byte[] B = new byte[32];

        public ChallengeResponseError Error = ChallengeResponseError.Invalid;
        public byte[] g = new byte[1];
        public byte[] n = new byte[32];
        public byte[] s = new byte[32];
        public byte[] unk3 = new byte[16];
        public byte unk4;

        public void SetAuthData( byte[] B, byte[] g, byte[] n, byte[] s, byte[] unk3, byte unk4 )
        {
            this.B = B;
            this.g = g;
            this.n = n;
            this.s = s;
            this.unk3 = unk3;
            this.unk4 = unk4;
        }

        public Packet Build()
        {
            if ( this.Error == ChallengeResponseError.Invalid )
            {
                throw new InvalidPacketException( $"{nameof( this.Error )} has not been set" );
            }

            this.WriteByte( 0x0 );
            this.WriteByte( 0x0 );
            this.WriteByte( (byte) this.Error );

            if ( this.Error != ChallengeResponseError.Success )
            {
                return this;
            }

            if ( this.B.Length != 32 )
            {
                throw new InvalidPacketException( $"Expected B to be 32 bytes but it was {this.B.Length} bytes" );
            }

            if ( this.g.Length != 1 )
            {
                throw new InvalidPacketException( $"Expected g to be 1 byte but it was {this.g.Length} bytes" );
            }

            if ( this.n.Length != 32 )
            {
                throw new InvalidPacketException( $"Expected n to be 32 bytes but it was {this.n.Length} bytes" );
            }

            if ( this.s.Length != 32 )
            {
                throw new InvalidPacketException( $"Expected s to be 32 bytes but it was {this.s.Length} bytes" );
            }

            if ( this.unk3.Length != 16 )
            {
                throw new InvalidPacketException( $"Expected unk3 to be 16 bytes but it was {this.unk3.Length} bytes" );
            }

            this.WriteBytes( this.B );
            this.WriteByte( (byte) this.g.Length );
            this.WriteBytes( this.g );
            this.WriteByte( (byte) this.n.Length );
            this.WriteBytes( this.n );
            this.WriteBytes( this.s );
            this.WriteBytes( this.unk3 );
            this.WriteByte( this.unk4 );

            return this;
        }
    }
}