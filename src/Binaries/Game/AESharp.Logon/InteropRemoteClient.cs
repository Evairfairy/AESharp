using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;

namespace AESharp.Logon
{
    public class InteropRemoteClient : RemoteClient
    {
        public InteropRemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
            : base( rawClient, tokenSource )
        {
        }

        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            if ( token.IsCancellationRequested )
            {
                return;
            }

            Packet packet = new Packet( data );
            int opcode = packet.ReadInt32();

            switch ( opcode )
            {
                case 0x1000:
                {
                    string accountName = packet.ReadShortString();

                    List<LogonRemoteClient> clients = LogonServices.LogonClients.GetAllClients();

                    LogonRemoteClient client =
                        clients.Find( x => x.AuthData.DbAccount.Username.ToUpper() == accountName.ToUpper() );
                    if ( client == null )
                    {
                        Packet response = new Packet();
                        response.WriteInt32( 0x1001 );
                        response.WriteShortString( accountName );
                        response.WriteBoolean( false );

                        await this.SendPacketAsync( response, token );
                    }
                    else
                    {
                        Packet response = new Packet();
                        response.WriteInt32( 0x1001 );
                        response.WriteShortString( accountName );
                        response.WriteBoolean( true );
                        response.WriteBytes( client.AuthData.Srp6.SessionKeyRaw.GetBytes( 40 ) );

                        await this.SendPacketAsync( response, token );
                    }

                    break;
                }
                default:
                {
                    throw new InvalidPacketException(
                        $"Received unknown or unimplemented packet (opcode: 0x{opcode:x2})" );
                }
            }
        }
    }
}