using System;
using System.Net;
using AESharp.Networking.Packets.Serialization;
using AESharp.Networking.Packets.Serialization.Converters;
using AESharp.Networking.Packets.Serialization.Transformers;

// ReSharper disable RedundantArgumentDefaultValue
// ReSharper disable UnusedAutoPropertyAccessor.Local

namespace AESharp.Networking.Packets
{
    public sealed class LogonPacket
    {
        public byte Error { get; private set; }

        public short Length { get; private set; }

        [FixedLength( 4 )]
        // These transformers are executed in lexicographical order
        [Reverse]
        [Trim( mode: SerializationMode.Read )]
        [Pad( StringSide.End, '\0' )]
        public string Game { get; private set; }

        public Version Build { get; private set; }

        [FixedLength( 4 )]
        [Reverse]
        [Trim( mode: SerializationMode.Read )]
        [Pad( StringSide.End, '\0' )]
        public string Platform { get; private set; }

        [FixedLength( 4 )]
        [Reverse]
        [Trim( mode: SerializationMode.Read )]
        [Pad( StringSide.End, '\0' )]
        public string OS { get; private set; }

        [FixedLength( 4 )]
        [Reverse]
        [Trim( mode: SerializationMode.Read )]
        [Pad( StringSide.End, '\0' )]
        public string Country { get; private set; }

        public uint TimezoneBias { get; private set; }

        public IPAddress IPAddress { get; private set; }

        [BinaryConverter( typeof( BStringConverter ) )]
        public string AccountName { get; private set; }
    }
}