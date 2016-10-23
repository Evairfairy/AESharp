using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AESharp.Core.Crypto
{
    public class SecureRemotePassword6
    {
        private const uint KeyLength = 32;
        private static readonly RandomNumberGenerator RandomGenerator = RandomNumberGenerator.Create();
        private static readonly HashAlgorithm Sha1Algorithm = SHA1.Create();
        private static readonly BigNumber _generator = new BigNumber(7);
        private static readonly BigNumber _modulus = new BigNumber("B79B3E2A87823CAB8F5EBFBF8EB10108535006298B5BADBD5B53E1895E644B89", 16);

        private BigNumber _credentialsHash;
        private BigNumber _salt;
        private BigNumber _sessionKey;
        private BigNumber _publicEphemeralValueA;
        private BigNumber _secretEphemeralValueA = RandomNumber();
        private BigNumber _publicEphemeralValueB;
        private BigNumber _secretEphemeralValueB;
        private BigNumber _verifier;
        private string _username;

        public string Username
        {
            get { return this._username; }
            private set { this._username = value.ToUpper(); }
        }

        public BigNumber Credentials { get; set; }

        public SecureRemotePassword6(string username, BigNumber credentials)
        {
            this.Username = username;
            this.Credentials = credentials;
        }

        private static BigNumber RandomNumber()
        {
            return RandomNumber(KeyLength);
   ;     }

        private static BigNumber RandomNumber(uint size)
        {
            byte[] buffer = new byte[size];

            RandomGenerator.GetBytes( buffer );

            if ( buffer[0] == 0 )
            {
                buffer[0] = 1;
            }

            return new BigNumber( buffer );
        }

        public BigNumber ClientSessionKeyProof
            =>
            this.Hash( this.Hash( this.Modulus ) ^ this.Hash( this.Generator ), this.Hash( this.Username ),
                this.Salt, this.PublicEphemeralValueA,
                this.PublicEphemeralValueB, this.SessionKey );

        public BigNumber ServerSessionKeyProof
            => this.Hash( this.PublicEphemeralValueA, this.ClientSessionKeyProof, this.SessionKey );

        public BigNumber Multiplier => (BigNumber) 3;

        public BigNumber Salt
        {
            set { this._salt = value; }
            get { return this._salt ?? ( this._salt = RandomNumber() ); }
        }

        public BigNumber CredentialsHash
        {
            get
            {
                if ( this._credentialsHash == null )
                {
                    this._credentialsHash = this.Hash( this.Salt, this.Credentials );
                }

                return this._credentialsHash;
            }
        }

        public BigNumber PublicEphemeralValueA
        {
            get { return this._publicEphemeralValueA; }
            set
            {
                this._publicEphemeralValueA = value;
                this._publicEphemeralValueA %= this.Modulus;

                if ( this._publicEphemeralValueA < 0 )
                {
                    this._publicEphemeralValueA += this.Modulus;
                }

                if ( this._publicEphemeralValueA == 0 )
                {
                    throw new InvalidDataException($"{nameof( this.PublicEphemeralValueA )} cannot be 0 Mod N");
                }
            }
        }

        public BigNumber PublicEphemeralValueB
        {
            get
            {
                if ( this._publicEphemeralValueB == null )
                {
                    this._secretEphemeralValueB = RandomNumber();
                    this._publicEphemeralValueB = this.Multiplier * this.Verifier + this.Generator.ModPow( this._secretEphemeralValueB, this.Modulus );
                    this._publicEphemeralValueB %= this.Modulus;

                    if ( this._publicEphemeralValueB < 0 )
                    {
                        this._publicEphemeralValueB += this.Modulus;
                    }
                }

                return this._publicEphemeralValueB;
            }
        }

        public BigNumber ScramblingParameter => this.Hash( this.PublicEphemeralValueA, this.PublicEphemeralValueB );

        public BigNumber SessionKeyRaw
        {
            get
            {
                if ( this._sessionKey == null )
                {
                    if ( this._publicEphemeralValueA == null )
                    {
                        return null;
                    }

                    BigNumber S = this.Verifier.ModPow( this.ScramblingParameter, this.Modulus );
                    S = S * this.PublicEphemeralValueA % this.Modulus;
                    S = S.ModPow( this._secretEphemeralValueB, this.Modulus );

                    this._sessionKey = S;
                }

                return this._sessionKey;
            }
        }

        public BigNumber Verifier
        {
            get
            {
                if ( this._verifier == null )
                {
                    this._verifier = this.Generator.ModPow( this.CredentialsHash, this.Modulus );
                }

                if ( this._verifier < 0 )
                {
                    this._verifier += this.Modulus;
                }

                return this._verifier;
            }
            set { this._verifier = value; }
        }

        public BigNumber SessionKey
        {
            get
            {
                byte[] data = this.SessionKeyRaw.GetBytes( 32 );

                byte[] temp = new byte[16];
                for ( int i = 0; i < temp.Length; ++i )
                {
                    temp[i] = data[2 * i];
                }

                byte[] hash1 = this.Hash( temp ).GetBytes( 20 );

                for ( int i = 0; i < temp.Length; ++i )
                {
                    temp[i] = data[2 * i + 1];
                }

                byte[] hash2 = this.Hash( temp ).GetBytes( 20 );

                data = new byte[40];

                for ( int i = 0; i < data.Length; ++i )
                {
                    data[i] = i % 2 == 0 ? hash1[i / 2] : hash2[i / 2];
                }

                return new BigNumber(data);
            }
        }

        public BigNumber Generator => _generator;

        public BigNumber Modulus => _modulus;

        public bool IsClientProofValid( BigNumber clientProof )
        {
            BigNumber myProof = this.ClientSessionKeyProof;

            Console.Write( "Client M: " );
            foreach (byte b in clientProof.GetBytes())
            {
                Console.Write($"{b:x}");
            }
            Console.WriteLine();
            Console.Write("Our M: ");
            foreach (byte b in myProof.GetBytes())
            {
                Console.Write($"{b:x}");
            }
            Console.WriteLine();

            return myProof == clientProof;
        }

        public BigNumber Hash( params HashUtilities.HashDataBroker[] brokers )
        {
            return HashUtilities.HashToBigNumber( Sha1Algorithm, brokers );
        }

        public static byte[] GenerateCredentialsHash( string username, string password )
        {
            byte[] buffer =
                Sha1Algorithm.ComputeHash( Encoding.UTF8.GetBytes( $"{username.ToUpper()}:{password.ToUpper()}" ) );

            return buffer;
        }

        public bool IsClientProofValid( byte[] packetA, byte[] clientProof )
        {
            this.PublicEphemeralValueA = packetA;

            return this.IsClientProofValid( clientProof );
   ;     }
    }
}