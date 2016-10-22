using System;
using System.Net;
using AESharp.Core.Extensions;

namespace AESharp.Logon.Universal.Networking.Packets
{
    public class ChallengePacket
    {
        public ChallengePacket( LogonPacket packet )
        {
            this.Game = packet.ReadFixedString( 4 ).Flip();
            this.Build = new Version( packet.ReadByte(), packet.ReadByte(), packet.ReadByte(), packet.ReadUShort() );
            this.Platform = packet.ReadFixedString( 4 ).Flip();
            this.OS = packet.ReadFixedString( 4 ).Flip();
            this.Country = packet.ReadFixedString( 4 ).Flip();
            this.TimezoneBias = packet.ReadUInt();
            this.IP =
                IPAddress.Parse( $"{packet.ReadByte()}.{packet.ReadByte()}.{packet.ReadByte()}.{packet.ReadByte()}" );
            this.AccountName = packet.ReadFixedString( packet.ReadByte() );
        }

        public string Game { get; private set; }
        public Version Build { get; private set; }
        public string Platform { get; private set; }
        public string OS { get; private set; }
        public string Country { get; private set; }
        public uint TimezoneBias { get; private set; }
        public IPAddress IP { get; private set; }
        public string AccountName { get; private set; }
    }
}