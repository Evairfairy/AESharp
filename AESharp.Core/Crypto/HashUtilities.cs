using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace AESharp.Core.Crypto
{
    public static class HashUtilities
    {
        public class HashDataBroker
        {
            internal byte[] RawData;

            internal int Length => RawData.Length;

            public HashDataBroker(byte[] data)
            {
                RawData = data;
            }

            public static implicit operator HashDataBroker(byte[] data)
            {
                return new HashDataBroker(data);
            }

            public static implicit operator HashDataBroker(string s)
            {
                return new HashDataBroker(Encoding.UTF8.GetBytes(s));
            }

            public static implicit operator HashDataBroker(BigNumber bn)
            {
                return new HashDataBroker(bn.GetBytes());
            }

            public static implicit operator HashDataBroker(uint i)
            {
                return new HashDataBroker(new BigNumber(i).GetBytes());
            }
        }

        public static byte[] FinalizeHash(HashAlgorithm algorithm, params HashDataBroker[] brokers)
        {
            MemoryStream buffer = new MemoryStream();

            foreach (HashDataBroker broker in brokers)
            {
                buffer.Write(broker.RawData, 0, broker.Length);
            }

            buffer.Position = 0;

            return algorithm.ComputeHash(buffer);
        }

        public static BigNumber HashToBigNumber(HashAlgorithm algorithm, params HashDataBroker[] brokers)
        {
            return new BigNumber(FinalizeHash(algorithm, brokers));
        }
    }
}