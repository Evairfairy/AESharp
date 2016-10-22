using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;

namespace AESharp.Logon.Universal.Networking.Packets
{
    public class ChallengeResponsePacket
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

        public ChallengeResponseError Error = ChallengeResponseError.Invalid;

        public byte[] BuildPacket()
        {
            if ( this.Error == ChallengeResponseError.Invalid )
            {
                throw new InvalidPacketException( $"{nameof(this.Error)} has not been set");
            }

            Packet packet = new Packet();
            packet.WriteByte( 0x0 );
            packet.WriteByte( 0x0 );
            packet.WriteByte( (byte) this.Error );

            return packet.InternalBuffer;
        }
    }
}