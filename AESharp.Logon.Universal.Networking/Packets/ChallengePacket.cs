using System;
using System.Net;
using AESharp.Core.Extensions;

namespace AESharp.Logon.Universal.Networking.Packets
{
    public class ChallengePacket
    {
        public byte Error { get; }
        public ushort Size { get; }
        public string Game { get; }
        public Version Build { get; }
        public string Platform { get; }
        public string OS { get; }
        public string Country { get; }
        public uint TimezoneBias { get; }
        public IPAddress IP { get; }
        public string AccountName { get; }

        public ChallengePacket(LogonPacket packet)
        {
            Error = packet.ReadByte();
            Size = packet.ReadUInt16();
            Game = packet.ReadFixedString(4).Reverse();
            Build = packet.ReadVersion();
            Platform = packet.ReadFixedString(4).Reverse();
            OS = packet.ReadFixedString(4).Reverse();
            Country = packet.ReadFixedString(4).Reverse();
            TimezoneBias = packet.ReadUInt32();
            IP = packet.ReadIPAddress4();
            AccountName = packet.ReadFixedString(packet.ReadByte());
        }
    }
}