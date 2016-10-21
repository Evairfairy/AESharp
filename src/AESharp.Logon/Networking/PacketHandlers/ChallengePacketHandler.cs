using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AESharp.Networking.Packets;

namespace AESharp.Logon.Networking.PacketHandlers
{
    public class ChallengePacketHandler : LogonPacketHandler<LogonChallengePacket>
    {
        public override PacketId PacketId { get; } = PacketId.Challenge;

        public override PacketHandlerResult HandlePacket( LogonChallengePacket packet )
        {
            Console.WriteLine( "Received logon packet:" );
            Console.WriteLine( $"\tOpcode:\t\t\t{this.PacketId}" );
            Console.WriteLine( $"\tError:\t\t\t{packet.Error}" );
            Console.WriteLine( $"\tLength:\t\t\t{packet.Length}" );
            Console.WriteLine( $"\tGame:\t\t\t{packet.Game}" );
            Console.WriteLine( $"\tBuild:\t\t\t{packet.Build}" );
            Console.WriteLine( $"\tPlatform:\t\t{packet.Platform}" );
            Console.WriteLine( $"\tOS:\t\t\t{packet.OS}" );
            Console.WriteLine( $"\tCountry:\t\t{packet.Country}" );
            Console.WriteLine( $"\tTimezone Bias:\t\t{packet.TimezoneBias}" );
            Console.WriteLine( $"\tIP:\t\t\t{packet.IPAddress}" );
            Console.WriteLine( $"\tAccount Name:\t\t{packet.AccountName}" );
            
            return new PacketHandlerResult( false, null /* TODO */ );
        }
    }
}
