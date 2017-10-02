namespace AESharp.Core.Crypto
{
    public class RC4Engine
    {
        private byte _indexOne;
        private byte _indexTwo;
        private byte[] _permutation;

        public bool Initialized { get; private set; }
        public byte[] Key { get; private set; }

        public RC4Engine()
        {
            Reset();
        }

        private void Reset()
        {
            _permutation = new byte[256];
            for (var i = 0; i < _permutation.Length; ++i)
            {
                _permutation[i] = (byte) i;
            }

            _indexOne = 0;
            _indexTwo = 0;
            Initialized = false;
        }

        public void Setup(byte[] key)
        {
            Key = key;

            Reset();

            uint i = 0;
            byte j = 0;

            while (i < 256)
            {
                unchecked
                {
                    j += (byte) (_permutation[i] + key[i % key.Length]);
                    var k = _permutation[i];
                    _permutation[i] = _permutation[j];
                    _permutation[j] = k;
                }

                ++i;
            }

            Initialized = true;
        }

        public byte[] Process(byte[] input)
        {
            var buffer = new byte[input.Length];

            uint i = 0;

            while (i < input.Length)
            {
                unchecked
                {
                    ++_indexOne;
                    _indexTwo += _permutation[_indexOne];

                    var k = _permutation[_indexOne];
                    _permutation[_indexOne] = _permutation[_indexTwo];
                    _permutation[_indexTwo] = k;

                    var j = (byte) (_permutation[_indexOne] + _permutation[_indexTwo]);
                    buffer[i] = (byte) (input[i] ^ _permutation[j]);
                }

                ++i;
            }

            return buffer;
        }
    }
}