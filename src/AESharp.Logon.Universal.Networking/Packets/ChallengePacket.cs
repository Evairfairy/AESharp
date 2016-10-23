using System;
using System.Net;
using AESharp.Core.Extensions;

namespace AESharp.Logon.Universal.Networking.Packets
{
    public class ChallengePacket
    {
        public byte Error { get; private set; }
        public ushort Size { get; private set; }
        public string Game { get; private set; }
        public Version Build { get; private set; }
        public string Platform { get; private set; }
        public string OS { get; private set; }
        public string Country { get; private set; }
        public uint TimezoneBias { get; private set; }
        public IPAddress IP { get; private set; }
        public string AccountName { get; private set; }

        public ChallengePacket( LogonPacket packet )
        {
            this.Error = packet.ReadByte();
            this.Size = packet.ReadUInt16();
            this.Game = packet.ReadFixedString( 4 ).Flip();
            this.Build = packet.ReadVersion();
            this.Platform = packet.ReadFixedString( 4 ).Flip();
            this.OS = packet.ReadFixedString( 4 ).Flip();
            this.Country = packet.ReadFixedString( 4 ).Flip();
            this.TimezoneBias = packet.ReadUInt32();
            this.IP = packet.ReadIPAddress4();
            this.AccountName = packet.ReadFixedString( packet.ReadByte() );
        }
    }
}
