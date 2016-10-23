using System;
using System.Security.Cryptography;
using System.Text;
using AESharp.Core.Extensions;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Math;

namespace AESharp.Core.Crypto
{
    public class SRP6
    {
        public BigInteger Generator; // g
        public BigInteger SafePrime; // N
        public BigInteger Salt; // s
        public BigInteger ServerPrivateValue; // b
        public BigInteger ServerPublicValue; // B

        public BigInteger SessionKey;

        private readonly Sha1Digest Sha1Digest;
        public BigInteger Verifier; // v

        public SRP6()
        {
            this.Sha1Digest = new Sha1Digest();

            this.SafePrime = this.MakeUnsignedBigInt( new byte[]
                                                      {
                                                          0x89, 0x4B, 0x64, 0x5E, 0x89, 0xE1, 0x53, 0x5B, 0xBD, 0xAD,
                                                          0x5B, 0x8B, 0x29, 0x06, 0x50, 0x53, 0x08,
                                                          0x01, 0xB1, 0x8E, 0xBF, 0xBF, 0x5E, 0x8F, 0xAB, 0x3C, 0x82,
                                                          0x87, 0x2A, 0x3E, 0x9B, 0xB7
                                                      } );

            //this.SafePrime =
            //    this.MakeUnsignedBigInt(
            //        "894B645E89E1535BBDAD5B8B290650530801B18EBFBF5E8FAB3C82872A3E9BB7".ByteRepresentationToByteArray() );

            this.Generator = this.MakeUnsignedBigInt( BitConverter.GetBytes( (uint)7 ) );

            byte[] buffer = new byte[32];
            RandomNumberGenerator csprng = RandomNumberGenerator.Create();
            csprng.GetBytes( buffer );

            this.Salt = this.MakeUnsignedBigInt( buffer );
        }

        public BigInteger MakeUnsignedBigInt( byte[] data )
        {
            return new BigInteger( 1, data );
        }

        public byte[] GetRandomBytes( int bytes )
        {
            byte[] buffer = new byte[bytes];
            RandomNumberGenerator csprng = RandomNumberGenerator.Create();
            csprng.GetBytes( buffer );
            return buffer;
        }

        public void GenerateAuthLogonChallenge( string passwordHash, out byte unk2, out byte[] b, out byte[] g,
                                                out byte[] n, out byte[] s, out byte[] unk3, out byte unk4 )
        {
            byte[] sha1Bytes = this.GetSaltedPasswordHashBytes( passwordHash );

            BigInteger x = this.MakeUnsignedBigInt( sha1Bytes );
            this.Verifier = this.Generator.ModPow( x, this.SafePrime );

            byte[] bytes = this.GetRandomBytes( 19 );
            this.ServerPrivateValue = this.MakeUnsignedBigInt( bytes );

            const byte k = 3;

            BigInteger gmod = this.Generator.ModPow( this.ServerPrivateValue, this.SafePrime );

            BigInteger v1 = this.Verifier.Multiply( this.MakeUnsignedBigInt( new[] { k } ) );
            BigInteger v2 = v1.Add( gmod );
            this.ServerPublicValue = v2.Mod( this.SafePrime );

            BigInteger unk = this.MakeUnsignedBigInt( this.GetRandomBytes( 16 ) );

            unk2 = 0;
            b = this.ServerPublicValue.ToByteArrayUnsigned();
            g = new[] { this.Generator.ToByteArrayUnsigned()[0] };
            n = this.SafePrime.ToByteArrayUnsigned();
            s = this.Salt.ToByteArrayUnsigned();
            unk3 = unk.ToByteArrayUnsigned();
            unk4 = 0;
        }

        public void ProcessAuthLogonProof( string username, byte[] packetA, byte[] packetM )
        {
            BigInteger A = this.MakeUnsignedBigInt( packetA );

            this.ResetSha1Digest();
            this.UpdateDigest( A.ToByteArrayUnsigned() );
            this.UpdateDigest( this.ServerPublicValue.ToByteArrayUnsigned() );
            byte[] finalHash = this.GetFinalSha1Hash();

            BigInteger u = this.MakeUnsignedBigInt( finalHash );

            BigInteger s1 = this.Verifier.ModPow( u, this.SafePrime );
            BigInteger s2 = A.Multiply( s1 );
            BigInteger S = s2.ModPow( this.ServerPrivateValue, this.SafePrime );

            byte[] t = S.ToByteArrayUnsigned();
            byte[] t1 = new byte[16];
            byte[] vK = new byte[40];

            for( int i = 0; i < 16; ++i )
                t1[i] = t[i * 2];

            this.ResetSha1Digest();
            this.UpdateDigest( t1 );
            byte[] t1Sha1 = this.GetFinalSha1Hash();

            for( int i = 0; i < 20; ++i )
                vK[i * 2] = t1Sha1[i];
            for( int i = 0; i < 16; ++i )
                t1[i] = t[i * 2 + 1];

            this.ResetSha1Digest();
            this.UpdateDigest( t1 );
            byte[] t1Sha2 = this.GetFinalSha1Hash();

            for( int i = 0; i < 20; ++i )
                vK[i * 2 + 1] = t1Sha2[i];

            this.SessionKey = this.MakeUnsignedBigInt( vK );

            this.ResetSha1Digest();
            this.UpdateDigest( this.SafePrime.ToByteArrayUnsigned() );
            byte[] hash = this.GetFinalSha1Hash();

            this.ResetSha1Digest();
            this.UpdateDigest( this.Generator.ToByteArrayUnsigned() );
            byte[] hash2 = this.GetFinalSha1Hash();

            for( int i = 0; i < 20; ++i )
                hash[i] ^= hash2[i];

            BigInteger t3 = this.MakeUnsignedBigInt( hash );

            this.ResetSha1Digest();
            this.UpdateDigest( Encoding.UTF8.GetBytes( username ) );
            byte[] t4Hash = this.GetFinalSha1Hash();

            BigInteger t4 = this.MakeUnsignedBigInt( t4Hash );

            this.ResetSha1Digest();
            this.UpdateDigest( t3.ToByteArrayUnsigned() );
            this.UpdateDigest( t4.ToByteArrayUnsigned() );
            this.UpdateDigest( this.Salt.ToByteArrayUnsigned() );
            this.UpdateDigest( A.ToByteArrayUnsigned() );
            this.UpdateDigest( this.ServerPublicValue.ToByteArrayUnsigned() );
            this.UpdateDigest( this.SessionKey.ToByteArrayUnsigned() );

            byte[] finalM = this.GetFinalSha1Hash();

            BigInteger M = this.MakeUnsignedBigInt( finalM );

            Console.Write( "Client M: " );
            foreach( byte b in packetM )
                Console.Write( $"{b:x}" );
            Console.WriteLine();
            Console.Write( "Our M: " );
            foreach( byte b in finalM )
                Console.Write( $"{b:x}" );
            Console.WriteLine();
        }

        public byte[] GetSaltedPasswordHashBytes( string passwordHash )
        {
            this.ResetSha1Digest();

            //BigInteger bn = new BigInteger( passwordHash );

            byte[] passwordBytes = passwordHash.ByteRepresentationToByteArray();
            Array.Reverse( passwordBytes );

            //byte[] passwordBytes = bn.ToByteArrayUnsigned();
            //Array.Reverse( passwordBytes );

            byte[] salt = this.Salt.ToByteArrayUnsigned();
            this.UpdateDigest( salt );
            this.UpdateDigest( passwordBytes );

            byte[] returnValue = this.GetFinalSha1Hash();

            this.ResetSha1Digest();
            return returnValue;
        }

        public void ResetSha1Digest()
        {
            this.Sha1Digest.Reset();
        }

        public void UpdateDigest( byte[] data )
        {
            this.Sha1Digest.BlockUpdate( data, 0, data.Length );
        }

        public byte[] GetFinalSha1Hash()
        {
            byte[] buffer = new byte[20];
            this.Sha1Digest.DoFinal( buffer, 0 );
            return buffer;
        }
    }
}
