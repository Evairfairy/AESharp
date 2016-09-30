using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using AESharp.Networking.Packets.Serialization;
using AESharp.Networking.Packets.Serialization.Converters;
using AESharp.Networking.Packets.Serialization.Transformers;

namespace AESharp.Networking.Packets
{
    public sealed class LogonPacket
    {
        public byte Error { get; private set; }

        public short Length { get; private set; }

        [FixedLength( 4 ), Reverse]
        public string Game { get; private set; }

        public Version Build { get; private set; }

        [FixedLength( 4 ), Reverse]
        public string Platform { get; private set; }

        [FixedLength( 4 ), Reverse]
        public string OS { get; private set; }

        [FixedLength( 4 ), Reverse]
        public string Country { get; private set; }

        public uint TimezoneBias { get; private set; }

        public IPAddress IPAddress { get; private set; }

        [BinaryConverter( typeof( BStringConverter ) )]
        public string AccountName { get; private set; }
    }
}
