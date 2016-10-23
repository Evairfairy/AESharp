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
        public LogonAuthenticationData AuthData { get; } = new LogonAuthenticationData();

        public LogonRemoteClient( TcpClient rawClient, CancellationTokenSource tokenSource )
            : base( rawClient, tokenSource ) { }

        public override async Task HandleDataAsync( byte[] data, CancellationToken token )
        {
            LogonPacket logonPacket = new LogonPacket( data );

            if( token.IsCancellationRequested )
                return;

            switch( logonPacket.Opcode )
            {
                case (byte)LogonOpcodes.Challenge:
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
                    if( account == null )
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

                        if( account.Banned )
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

                        Console.WriteLine( $"Validating username and password for account {account.Username}" );

                        this.AuthData.InitSRP6(account.Username, account.PasswordHash.ByteRepresentationToByteArray());

                        //byte unk2;
                        //byte[] b;
                        //byte[] g;
                        //byte[] n;
                        //byte[] s;
                        //byte[] unk3;
                        //byte unk4;

                        //this.AuthData.Srp6Data.GenerateAuthLogonChallenge( account.PasswordHash, out unk2, out b, out g,
                        //    out n, out s, out unk3, out unk4 );

                        //byte[] pevB;
                        //byte[] gen;
                        //byte[] mod;
                        //byte[] salt;
                        //this.AuthData.Srp6Data.GenerateAuthLogonChallenge_WC( account.PasswordHash, out pevB, out gen, out mod, out salt );

                        Packet pack = new Packet();
                        pack.WriteByte( 0 );
                        pack.WriteByte( 0 );
                        pack.WriteByte( 0 );
                        BigNumber b = this.AuthData.Srp6.PublicEphemeralValueB;
                        pack.WriteBytes( b.GetBytes(32) );

                        pack.WriteByte( 1 );
                        pack.WriteBytes( this.AuthData.Srp6.Generator.GetBytes(1) );

                        pack.WriteByte( 32 );
                        pack.WriteBytes( this.AuthData.Srp6.Modulus.GetBytes(32) );

                        pack.WriteBytes( this.AuthData.Srp6.Salt.GetBytes(32) );

                        Random rand = new Random(Environment.TickCount);
                        byte[] randBytes = new byte[16];
                        rand.NextBytes( randBytes );
                        pack.WriteBytes( randBytes );

                        pack.WriteByte( 0 );

                        //pack.WriteBytes( pevB );
                        //pack.WriteByte( 1 );
                        //pack.WriteByte( gen[0] );
                        //pack.WriteByte( 32 );
                        //pack.WriteBytes( mod );
                        //pack.WriteBytes( salt );

                        //pack.WriteBytes( this.AuthData.Srp6Data.GetRandomBytes( 16 ) );
                        //pack.WriteByte( 0x0 );

                        //ChallengeResponsePacket responsePacket = new ChallengeResponsePacket
                        //{
                        //    Error = ChallengeResponsePacket.ChallengeResponseError.Success
                        //};
                        
                        //responsePacket.SetAuthData( b, g, n, s, unk3, unk4 );

                        await this.SendPacketAsync( pack, token );
                    }
                    break;
                }
                case (byte)LogonOpcodes.Proof:
                {
                    ProofPacket proofPacket = new ProofPacket( logonPacket );
                    
                    //this.AuthData.Srp6Data.ProcessAuthLogonProof( "TESTGM", proofPacket.A, proofPacket.M1 );
                    bool proofValid = this.AuthData.Srp6.IsClientProofValid( proofPacket.A, proofPacket.M1 );
                    
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
