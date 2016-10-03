using System.Numerics;
using System.Security.Cryptography;

namespace AESharp.Core.Crypto
{
    public class SRP6
    {
        public BigInteger SafePrime; // N
        public BigInteger Generator; // g
        public BigInteger Salt; // s
        public BigInteger Verifier; // v
        public BigInteger ServerPrivateValue; // b
        public BigInteger ServerPublicValue; // B

        public SRP6()
        {
            this.SafePrime = new BigInteger(
            new byte[]
            {
                0x89, 0x4B, 0x64, 0x5E, 0x89, 0xE1, 0x53, 0x5B, 0xBD, 0xAD, 0x5B, 0x8B, 0x29, 0x06, 0x50, 0x53, 0x08,
                0x01, 0xB1, 0x8E, 0xBF, 0xBF, 0x5E, 0x8F, 0xAB, 0x3C, 0x82, 0x87, 0x2A, 0x3E, 0x9B, 0xB7
            } );

            this.Generator = new BigInteger(7);
            
            byte[] buffer = new byte[32];
            RandomNumberGenerator csprng = RandomNumberGenerator.Create();
            csprng.GetBytes( buffer );

            this.Salt = new BigInteger(buffer);
        }
    }
}