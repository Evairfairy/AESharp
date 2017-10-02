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

        private static readonly BigNumber _modulus =
            new BigNumber("B79B3E2A87823CAB8F5EBFBF8EB10108535006298B5BADBD5B53E1895E644B89", 16);

        private BigNumber _credentialsHash;
        private BigNumber _publicEphemeralValueA;
        private BigNumber _publicEphemeralValueB;
        private BigNumber _salt;
        private BigNumber _secretEphemeralValueA = RandomNumber();
        private BigNumber _secretEphemeralValueB;
        private BigNumber _sessionKey;
        private string _username;
        private BigNumber _verifier;

        public string Username
        {
            get => _username;
            private set => _username = value.ToUpper();
        }

        public BigNumber Credentials { get; set; }

        public BigNumber ClientSessionKeyProof
            =>
                Hash(Hash(Modulus) ^ Hash(Generator), Hash(Username),
                    Salt, PublicEphemeralValueA,
                    PublicEphemeralValueB, SessionKey);

        public BigNumber ServerSessionKeyProof
            => Hash(PublicEphemeralValueA, ClientSessionKeyProof, SessionKey);

        public BigNumber Multiplier => (BigNumber) 3;

        public BigNumber Salt
        {
            set => _salt = value;
            get => _salt ?? (_salt = RandomNumber());
        }

        public BigNumber CredentialsHash
        {
            get
            {
                if (_credentialsHash == null)
                {
                    _credentialsHash = Hash(Salt, Credentials);
                }

                return _credentialsHash;
            }
        }

        public BigNumber PublicEphemeralValueA
        {
            get => _publicEphemeralValueA;
            set
            {
                _publicEphemeralValueA = value;
                _publicEphemeralValueA %= Modulus;

                if (_publicEphemeralValueA < 0)
                {
                    _publicEphemeralValueA += Modulus;
                }

                if (_publicEphemeralValueA == 0)
                {
                    throw new InvalidDataException($"{nameof(PublicEphemeralValueA)} cannot be 0 Mod N");
                }
            }
        }

        public BigNumber PublicEphemeralValueB
        {
            get
            {
                if (_publicEphemeralValueB == null)
                {
                    _secretEphemeralValueB = RandomNumber();
                    _publicEphemeralValueB = Multiplier * Verifier +
                                             Generator.ModPow(_secretEphemeralValueB, Modulus);
                    _publicEphemeralValueB %= Modulus;

                    if (_publicEphemeralValueB < 0)
                    {
                        _publicEphemeralValueB += Modulus;
                    }
                }

                return _publicEphemeralValueB;
            }
        }

        public BigNumber ScramblingParameter => Hash(PublicEphemeralValueA, PublicEphemeralValueB);

        public BigNumber SessionKeyRaw
        {
            get
            {
                if (_sessionKey == null)
                {
                    if (_publicEphemeralValueA == null)
                    {
                        return null;
                    }

                    BigNumber S = Verifier.ModPow(ScramblingParameter, Modulus);
                    S = S * PublicEphemeralValueA % Modulus;
                    S = S.ModPow(_secretEphemeralValueB, Modulus);

                    _sessionKey = S;
                }

                return _sessionKey;
            }
        }

        public BigNumber Verifier
        {
            get
            {
                if (_verifier == null)
                {
                    _verifier = Generator.ModPow(CredentialsHash, Modulus);
                }

                if (_verifier < 0)
                {
                    _verifier += Modulus;
                }

                return _verifier;
            }
            set => _verifier = value;
        }

        public BigNumber SessionKey
        {
            get
            {
                byte[] data = SessionKeyRaw.GetBytes(32);

                byte[] temp = new byte[16];
                for (int i = 0; i < temp.Length; ++i)
                {
                    temp[i] = data[2 * i];
                }

                byte[] hash1 = Hash(temp).GetBytes(20);

                for (int i = 0; i < temp.Length; ++i)
                {
                    temp[i] = data[2 * i + 1];
                }

                byte[] hash2 = Hash(temp).GetBytes(20);

                data = new byte[40];

                for (int i = 0; i < data.Length; ++i)
                {
                    data[i] = i % 2 == 0 ? hash1[i / 2] : hash2[i / 2];
                }

                return new BigNumber(data);
            }
        }

        public BigNumber Generator => _generator;

        public BigNumber Modulus => _modulus;

        public SecureRemotePassword6(string username, BigNumber credentials)
        {
            Username = username;
            Credentials = credentials;
        }

        private static BigNumber RandomNumber()
        {
            return RandomNumber(KeyLength);
            ;
        }

        private static BigNumber RandomNumber(uint size)
        {
            byte[] buffer = new byte[size];

            RandomGenerator.GetBytes(buffer);

            if (buffer[0] == 0)
            {
                buffer[0] = 1;
            }

            return new BigNumber(buffer);
        }

        public bool IsClientProofValid(BigNumber clientProof)
        {
            BigNumber myProof = ClientSessionKeyProof;

            Console.Write("Client M: ");
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

        public BigNumber Hash(params HashUtilities.HashDataBroker[] brokers)
        {
            return HashUtilities.HashToBigNumber(Sha1Algorithm, brokers);
        }

        public static byte[] GenerateCredentialsHash(string username, string password)
        {
            byte[] buffer =
                Sha1Algorithm.ComputeHash(Encoding.UTF8.GetBytes($"{username.ToUpper()}:{password.ToUpper()}"));

            return buffer;
        }

        public bool IsClientProofValid(byte[] packetA, byte[] clientProof)
        {
            PublicEphemeralValueA = packetA;

            return IsClientProofValid(clientProof);
            ;
        }
    }
}