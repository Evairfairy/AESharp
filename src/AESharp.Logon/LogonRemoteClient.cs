using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Crypto;
using AESharp.Core.Extensions;
using AESharp.Logon.Accounts;
using AESharp.Logon.Universal.Networking.Packets;
using AESharp.Networking.Data;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Exceptions;

namespace AESharp.Logon
{
    public class LogonRemoteClient : RemoteClient
    {
        public LogonAuthenticationData AuthData { get; } = new LogonAuthenticationData();

        public LogonRemoteClient( TcpClient rawClient ) : base( rawClient )
        {
        }

        public override async Task SendDataAsync( byte[] data )
        {
            data = await LogonServices.OutgoingLogonMiddleware.RunMiddlewareAsync( data, this );

            if ( data == null )
            {
                Console.WriteLine( "Outgoing logon middleware handlers nulled outgoing data" );
                return;
            }

            await base.SendDataAsync( data );
        }

        public override async Task HandleDataAsync( byte[] data )
        {
            data = await LogonServices.IncomingLogonMiddleware.RunMiddlewareAsync( data, this );
            if ( data == null )
            {
                Console.WriteLine( "Incoming logon middleware handlers nulled incoming data" );
                return;
            }

            LogonPacket logonPacket = new LogonPacket( data );

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
                        await this.SendDataAsync( response.FinalizePacket() );
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
                            await this.SendDataAsync( response.FinalizePacket() );
                            this.Disconnect();
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

                        await this.SendDataAsync( pack.FinalizePacket() );
                    }
                    break;
                }
                case (byte) LogonOpcodes.Proof:
                {
                    ProofPacket proofPacket = new ProofPacket( logonPacket );

                    bool proofValid = this.AuthData.Srp6.IsClientProofValid( proofPacket.A, proofPacket.M1 );

                    Console.WriteLine( $"Authentication {( proofValid ? "successful" : "failed" )}" );

                    if ( !proofValid )
                    {
                        ChallengeResponsePacket response = new ChallengeResponsePacket
                        {
                            Error = ChallengeResponsePacket.ChallengeResponseError.NoSuchAccount
                        };
                        await this.SendDataAsync( response.FinalizePacket() );
                        return;
                    }

                    Packet successPacket = new Packet();
                    successPacket.WriteByte( 0x1 );
                    successPacket.WriteByte( 0x0 );
                    successPacket.WriteBytes( this.AuthData.Srp6.ServerSessionKeyProof.GetBytes( 20 ) );
                    successPacket.WriteInt32( 0 );
                    successPacket.WriteInt32( 0 );
                    successPacket.WriteInt16( 0 );

                    await this.SendDataAsync( successPacket.FinalizePacket() );

                    break;
                }
                case (byte) LogonOpcodes.RealmList:
                {
                    List<Realm> realms = LogonServices.Realms.GetRealms();

                    short realmCount = (short) realms.Count;

                    Console.WriteLine( $"Sending {realmCount} realms" );

                    Packet realmPacket = new Packet();
                    realmPacket.WriteByte( 0x10 );

                    long oldPosition = realmPacket.BufferPosition;
                    realmPacket.WriteInt16( 0 );
                    realmPacket.WriteInt32( 0 );

                    realmPacket.WriteInt16( realmCount );

                    foreach ( Realm realm in realms )
                    {
                        realmPacket.WriteByte( (byte) realm.Type );
                        realmPacket.WriteBoolean( realm.IsLocked );
                        realmPacket.WriteByte( (byte) realm.Flags );
                        realmPacket.WriteCString( realm.Name );
                        realmPacket.WriteCString( realm.Address );
                        realmPacket.WriteSingle( realm.Population );
                        realmPacket.WriteByte( 3 ); // Characters
                        realmPacket.WriteByte( (byte) realm.Region );
                        realmPacket.WriteByte( 0 ); // Unk
                    }

                    realmPacket.WriteByte( 0x10 );
                    realmPacket.WriteByte( 0x0 );

                    realmPacket.BufferPosition = oldPosition;
                    realmPacket.WriteInt16( (short) ( realmPacket.Length - 3 ) );

                    await this.SendDataAsync( realmPacket.FinalizePacket() );

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