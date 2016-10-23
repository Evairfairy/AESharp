using System;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using AESharp.Core.Crypto;
using AESharp.Core.Extensions;
using AESharp.Logon.Accounts;
using AESharp.Logon.Universal.Networking.Packets;
using AESharp.Networking.Data;
using AESharp.Networking.Exceptions;

namespace AESharp.Logon
{
    public class LogonRemoteClient : RemoteClient
    {
        public LogonRemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
            : base( rawClient, tokenSource )
        {
        }

        public LogonAuthenticationData AuthData { get; } = new LogonAuthenticationData();

        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            LogonPacket logonPacket = new LogonPacket( data );

            if ( token.IsCancellationRequested )
            {
                return;
            }

            switch ( logonPacket.Opcode )
            {
                case (byte) LogonOpcodes.Challenge:
                {
                    ChallengePacket packet = new ChallengePacket( logonPacket );
                    Console.WriteLine( "Received logon packet:" );
                    Console.WriteLine( $"\tError:\t\t\t{packet.Error}" );
                    Console.WriteLine( $"\tSize:\t\t\t{packet.Size}" );
                    Console.WriteLine( $"\tGame:\t\t\t{packet.Game}" );
                    Console.WriteLine( $"\tBuild:\t\t\t{packet.Build}" );
                    Console.WriteLine( $"\tPlatform:\t\t{packet.Platform}" );
                    Console.WriteLine( $"\tOS:\t\t\t{packet.OS}" );
                    Console.WriteLine( $"\tCountry:\t\t{packet.Country}" );
                    Console.WriteLine( $"\tTimezone Bias:\t\t{packet.TimezoneBias}" );
                    Console.WriteLine( $"\tIP:\t\t\t{packet.IP}" );
                    Console.WriteLine( $"\tAccount Name:\t\t{packet.AccountName}" );

                    Console.Write( $"Validating username... " );
                    Account account = LogonServices.Accounts.GetAccount( packet.AccountName );
                    if ( account == null )
                    {
                        Console.WriteLine( $"failed. Account {packet.AccountName} does not exist." );

                        ChallengeResponsePacket response = new ChallengeResponsePacket
                        {
                            Error = ChallengeResponsePacket.ChallengeResponseError.NoSuchAccount
                        };
                        await this.SendPacketAsync( response.Build(), token );
                    }
                    else
                    {
                        Console.WriteLine( "success!" );

                        if ( account.Banned )
                        {
                            Console.WriteLine( $"Account {account.Username} is currently banned." );
                            ChallengeResponsePacket response = new ChallengeResponsePacket
                            {
                                Error = ChallengeResponsePacket.ChallengeResponseError.AccountClosed
                            };
                            await this.SendPacketAsync( response.Build(), token );
                            await this.Disconnect( TimeSpan.FromMilliseconds( 100 ) );
                            return;
                        }

                        this.AuthData.DbAccount = account;

                        Console.WriteLine( $"Validating username and password for account {account.Username}" );

                        this.AuthData.InitSRP6( account.Username, account.PasswordHash.ByteRepresentationToByteArray() );

                        Packet pack = new Packet();
                        pack.WriteByte( 0 );
                        pack.WriteByte( 0 );
                        pack.WriteByte( 0 );
                        BigNumber b = this.AuthData.Srp6.PublicEphemeralValueB;
                        pack.WriteBytes( b.GetBytes( 32 ) );

                        pack.WriteByte( 1 );
                        pack.WriteBytes( this.AuthData.Srp6.Generator.GetBytes( 1 ) );

                        pack.WriteByte( 32 );
                        pack.WriteBytes( this.AuthData.Srp6.Modulus.GetBytes( 32 ) );

                        pack.WriteBytes( this.AuthData.Srp6.Salt.GetBytes( 32 ) );

                        Random rand = new Random( Environment.TickCount );
                        byte[] randBytes = new byte[16];
                        rand.NextBytes( randBytes );
                        pack.WriteBytes( randBytes );

                        pack.WriteByte( 0 );

                        await this.SendPacketAsync( pack, token );
                    }
                    break;
                }
                case (byte) LogonOpcodes.Proof:
                {
                    ProofPacket proofPacket = new ProofPacket( logonPacket );

                    bool proofValid = this.AuthData.Srp6.IsClientProofValid( proofPacket.A, proofPacket.M1 );
                    if ( !proofValid )
                    {
                        ChallengeResponsePacket response = new ChallengeResponsePacket
                        {
                            Error = ChallengeResponsePacket.ChallengeResponseError.NoSuchAccount
                        };
                        await this.SendPacketAsync( response.Build(), token );
                        return;
                    }

                    Packet successPacket = new Packet();
                    successPacket.WriteByte( 0x1 );
                    successPacket.WriteByte( 0x0 );
                    successPacket.WriteBytes( this.AuthData.Srp6.ServerSessionKeyProof.GetBytes( 20 ) );
                    successPacket.WriteInt32( 0 );
                    successPacket.WriteInt32( 0 );
                    successPacket.WriteInt16( 0 );

                    await this.SendPacketAsync( successPacket, token );

                    break;
                }
                case (byte) LogonOpcodes.RealmList:
                {
                    Packet realmPacket = new Packet();
                    realmPacket.WriteByte( 0x10 );

                    long oldPosition = realmPacket.BufferPosition;
                    realmPacket.WriteInt16( 0 );
                    realmPacket.WriteInt32( 0 );

                    realmPacket.WriteInt16( 0 );

                    // Write realms here
                    //realmPacket.WriteByte( 0 ); // ServerType
                    //realmPacket.WriteByte( 0 ); // Status
                    //realmPacket.WriteByte(0  ); // Flags
                    //realmPacket.WriteCString( "Example Realm" );
                    //realmPacket.WriteCString( "127.0.0.1:8085" );
                    //realmPacket.WriteSingle( 0 ); // Population
                    //realmPacket.WriteByte( 3 ); // Characters
                    //realmPacket.WriteByte( 0 ); // TimeZone
                    //realmPacket.WriteByte( 0 );

                    realmPacket.WriteByte( 0x10 );
                    realmPacket.WriteByte( 0x0 );

                    realmPacket.BufferPosition = oldPosition;
                    realmPacket.WriteInt16( (short) ( realmPacket.Length - 3 ) );

                    await this.SendPacketAsync( realmPacket, token );

                    break;
                }
                default:
                {
                    throw new InvalidPacketException( $"Received unsupported opcode: 0x{logonPacket.Opcode:x2}" );
                }
            }
        }
    }
}