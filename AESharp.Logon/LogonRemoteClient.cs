using System;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Logon.Universal.Networking.Middleware;
using AESharp.Logon.Universal.Networking.Packets;
using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;

namespace AESharp.Logon
{
    public class LogonRemoteClient : RemoteClient<LogonMetaPacket>
    {
        public LogonAuthenticationData AuthData { get; } = new LogonAuthenticationData();

        public LogonRemoteClient(TcpClient rawClient) : base(rawClient)
        {
        }

        public override async Task SendDataAsync(LogonMetaPacket metaPacket)
        {
            metaPacket = await LogonServices.OutgoingLogonMiddleware.RunMiddlewareAsync(metaPacket, this);

            if (metaPacket.Handled)
            {
                Console.WriteLine("Outgoing logon middleware handled metaPacket");
                return;
            }

            await base.SendDataAsync(metaPacket);
        }

        public override async Task HandleDataAsync(LogonMetaPacket metaPacket)
        {
            metaPacket = await LogonServices.IncomingLogonMiddleware.RunMiddlewareAsync(metaPacket, this);
            if (metaPacket.Handled)
            {
                Console.WriteLine("Incoming logon middleware handled metaPacket");
                return;
            }

            var logonPacket = new LogonPacket(metaPacket);

            switch (logonPacket.Opcode)
            {
                case LogonOpcodes.Challenge:
                    await PacketHandlers.HandleChallengeAsync(this, logonPacket);
                    break;
                case LogonOpcodes.Proof:
                    await PacketHandlers.HandleProofAsync(this, logonPacket);
                    break;
                case LogonOpcodes.RealmList:
                    await PacketHandlers.HandleRealmListAsync(this, logonPacket);
                    break;
                case LogonOpcodes.ReconnectChallenge:
                case LogonOpcodes.Invalid:
                default:
                    throw new InvalidPacketException($"Received unsupported opcode: 0x{logonPacket.Opcode:x2}");
            }
        }
    }
}