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
            this.Reset();
        }

        private void Reset()
        {
            this._permutation = new byte[256];
            for ( int i = 0; i < this._permutation.Length; ++i )
            {
                this._permutation[i] = (byte)i;
            }

            this._indexOne = 0;
            this._indexTwo = 0;
            this.Initialized = false;
        }

        public void Setup( byte[] key )
        {
            this.Key = key;

            this.Reset();

            uint i = 0;
            byte j = 0;

            while ( i < 256 )
            {
                unchecked
                {
                    j += (byte)( this._permutation[i] + key[i % key.Length] );
                    byte k = this._permutation[i];
                    this._permutation[i] = this._permutation[j];
                    this._permutation[j] = k;
                }

                ++i;
            }

            this.Initialized = true;
        }

        public byte[] Process( byte[] input )
        {
            byte[] buffer = new byte[input.Length];

            uint i = 0;

            while ( i < input.Length )
            {
                unchecked
                {
                    ++this._indexOne;
                    this._indexTwo += this._permutation[this._indexOne];

                    byte k = this._permutation[this._indexOne];
                    this._permutation[this._indexOne] = this._permutation[this._indexTwo];
                    this._permutation[this._indexTwo] = k;

                    byte j = (byte)( this._permutation[this._indexOne] + this._permutation[this._indexTwo] );
                    buffer[i] = (byte)( input[i] ^ this._permutation[j] );
                }

                ++i;
            }

            return buffer;
        }
    }
}