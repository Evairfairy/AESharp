using System;

namespace AESharp.Core.Crypto
{
    public class BigNumber
    {
        private const int MaxLength = 70;

        private uint[] data;
        public int DataLength;

        // Approved
        public BigNumber( long value )
        {
            this.data = new uint[MaxLength];
            long tempVal = value;

            this.DataLength = 0;
            while ( ( value != 0 ) && ( this.DataLength < MaxLength ) )
            {
                this.data[this.DataLength] = (uint)( value & 0xffffffff );
                value >>= 32;
                ++this.DataLength;
            }

            if ( tempVal > 0 )
            {
                if ( ( value != 0 ) || ( ( this.data[MaxLength - 1] & 0x80000000 ) != 0 ) )
                {
                    throw new ArithmeticException(
                                                  $"Positive overflow while constructing BigNumber with parameter {tempVal}" );
                }
            }
            else if ( tempVal < 0 )
            {
                if ( ( value != -1 ) || ( ( this.data[this.DataLength - 1] & 0x80000000 ) == 0 ) )
                {
                    throw new ArithmeticException(
                                                  $"Negative underflow while constructing BigNumber with parameter {tempVal}" );
                }
            }

            if ( this.DataLength == 0 )
            {
                this.DataLength = 1;
            }
        }

        // Approved
        public BigNumber( string value, int radix )
        {
            BigNumber multiplier = new BigNumber( 1 );
            BigNumber result = new BigNumber();
            value = value.ToUpper().Trim();
            int limit = 0;

            if ( value[0] == '-' )
            {
                limit = 1;
            }

            for ( int i = value.Length - 1; i >= limit; --i )
            {
                int posVal = value[i];

                if ( ( posVal >= '0' ) && ( posVal <= '9' ) )
                {
                    posVal -= '0';
                }
                else if ( ( posVal >= 'A' ) && ( posVal <= 'Z' ) )
                {
                    posVal = posVal - 'A' + 10;
                }
                else
                {
                    // Arbitrary large value
                    posVal = 9999999;
                }

                if ( posVal >= radix )
                {
                    throw new ArithmeticException( $"Invalid string when constructing {nameof( BigNumber )} ({value})" );
                }

                if ( value[0] == '-' )
                {
                    posVal = -posVal;
                }

                result = result + multiplier * posVal;

                if ( i - 1 >= limit )
                {
                    multiplier = multiplier * radix;
                }
            }

            if ( value[0] == '-' )
            {
                if ( ( result.data[MaxLength - 1] & 0x80000000 ) == 0 )
                {
                    throw new ArithmeticException( $"Negative underflow while constructing {nameof( BigNumber )}" );
                }
            }
            else
            {
                if ( ( result.data[MaxLength - 1] & 0x80000000 ) != 0 )
                {
                    throw new ArithmeticException( $"Positive overflow while constructing {nameof( BigNumber )}" );
                }
            }

            this.data = new uint[MaxLength];
            for ( int i = 0; i < result.DataLength; ++i )
            {
                this.data[i] = result.data[i];
            }

            this.DataLength = result.DataLength;
        }

        // Approved
        public BigNumber()
        {
            this.data = new uint[MaxLength];
            this.DataLength = 1;
        }

        // Approved
        public BigNumber( BigNumber bn )
        {
            this.SetValue( bn );
        }

        // Approved
        public BigNumber( byte[] inData )
        {
            inData = (byte[])inData.Clone();

            Reverse( inData );
            this.DataLength = inData.Length >> 2;

            int leftOver = inData.Length & 0x3;

            // Length is not a multiple of 4
            if ( leftOver != 0 )
            {
                ++this.DataLength;
            }

            this.data = new uint[MaxLength];

            for ( int i = inData.Length - 1, j = 0; i >= 3; i -= 4, ++j )
            {
                this.data[j] =
                        (uint)
                        ( ( inData[i - 3] << 24 ) + ( inData[i - 2] << 16 ) + ( inData[i - 1] << 8 ) + inData[i] );
            }

            switch ( leftOver )
            {
                case 1:
                {
                    this.data[this.DataLength - 1] = inData[0];
                    break;
                }
                case 2:
                {
                    this.data[this.DataLength - 1] = (uint)( ( inData[0] << 8 ) + inData[1] );
                    break;
                }
                case 3:
                {
                    this.data[this.DataLength - 1] = (uint)( ( inData[0] << 16 ) + ( inData[1] << 8 ) + inData[2] );
                    break;
                }
            }

            while ( ( this.DataLength > 1 ) && ( this.data[this.DataLength - 1] == 0 ) )
            {
                --this.DataLength;
            }
        }

        // Approved
        public BigNumber( uint[] inData )
        {
            this.DataLength = inData.Length;

            if ( this.DataLength > MaxLength )
            {
                throw new ArithmeticException( "Byte overflow in constructor" );
            }

            this.data = new uint[MaxLength];

            for ( int i = this.DataLength - 1, j = 0; i >= 0; --i, ++j )
            {
                this.data[j] = inData[i];
            }

            while ( ( this.DataLength > 1 ) && ( this.data[this.DataLength - 1] == 0 ) )
            {
                --this.DataLength;
            }
        }

        // Approved
        public static implicit operator BigNumber( byte[] value )
        {
            return new BigNumber( value );
        }

        // Approved
        private static void Reverse<T>( T[] buffer )
        {
            Reverse( buffer, buffer.Length );
        }

        // Approved
        private static void Reverse<T>( T[] buffer, int length )
        {
            for ( int i = 0; i < length / 2; ++i )
            {
                T temp = buffer[i];
                buffer[i] = buffer[length - i - 1];
                buffer[length - i - 1] = temp;
            }
        }

        // Approved
        private void SetValue( BigNumber bn )
        {
            this.data = new uint[MaxLength];

            this.DataLength = bn.DataLength;

            for ( int i = 0; i < this.DataLength; ++i )
            {
                this.data[i] = bn.data[i];
            }
        }

        // Approved
        public static BigNumber operator *( BigNumber bn1, int bn2 )
        {
            return bn1 * (BigNumber)bn2;
        }

        // Approved
        public static BigNumber operator +( BigNumber bn1, BigNumber bn2 )
        {
            BigNumber result = new BigNumber();

            result.DataLength = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;

            long carry = 0;
            for ( int i = 0; i < result.DataLength; ++i )
            {
                long bnData1 = bn1.data[i];
                long bnData2 = bn2.data[i];
                long sum = bnData1 + bnData2 + carry;
                carry = sum >> 32;
                result.data[i] = (uint)( sum & 0xffffffff );
            }

            if ( ( carry != 0 ) && ( result.DataLength < MaxLength ) )
            {
                result.data[result.DataLength] = (uint)carry;
                ++result.DataLength;
            }

            while ( ( result.DataLength > 1 ) && ( result.data[result.DataLength - 1] == 0 ) )
            {
                --result.DataLength;
            }

            int lastPos = MaxLength - 1;
            if ( ( ( bn1.data[lastPos] & 0x80000000 ) == ( bn2.data[lastPos] & 0x80000000 ) ) &&
                 ( ( result.data[lastPos] & 0x80000000 ) != ( bn1.data[lastPos] & 0x80000000 ) ) )
            {
                throw new ArithmeticException();
            }

            return result;
        }

        // Approved
        public static BigNumber operator *( BigNumber bn1, BigNumber bn2 )
        {
            int lastPos = MaxLength - 1;
            bool bn1IsNegative = false;
            bool bn2IsNegative = false;

            try
            {
                if ( ( bn1.data[lastPos] & 0x80000000 ) != 0 )
                {
                    bn1IsNegative = true;
                    bn1 = -bn1;
                }

                if ( ( bn2.data[lastPos] & 0x80000000 ) != 0 )
                {
                    bn2IsNegative = true;
                    bn2 = -bn2;
                }
            }
            catch
            {
                // ignored
            }

            BigNumber result = new BigNumber();

            try
            {
                for ( int i = 0; i < bn1.DataLength; ++i )
                {
                    if ( bn1.data[i] == 0 )
                    {
                        continue;
                    }

                    ulong mcarry = 0;
                    for ( int j = 0, k = i; j < bn2.DataLength; ++j, ++k )
                    {
                        ulong bn1Data = bn1.data[i];
                        ulong bn2Data = bn2.data[j];
                        ulong val = bn1Data * bn2Data + result.data[k] + mcarry;

                        result.data[k] = (uint)( val & 0xffffffff );
                        mcarry = val >> 32;
                    }

                    if ( mcarry != 0 )
                    {
                        result.data[i + bn2.DataLength] = (uint)mcarry;
                    }
                }
            }
            catch
            {
                throw new ArithmeticException( "Multiplication overflow" );
            }

            result.DataLength = bn1.DataLength + bn2.DataLength;
            if ( result.DataLength > MaxLength )
            {
                result.DataLength = MaxLength;
            }

            while ( ( result.DataLength > 1 ) && ( result.data[result.DataLength - 1] == 0 ) )
            {
                --result.DataLength;
            }

            if ( ( result.data[lastPos] & 0x80000000 ) != 0 )
            {
                // ReSharper disable once InvertIf
                if ( ( bn1IsNegative != bn2IsNegative ) && ( result.data[lastPos] == 0x80000000 ) )
                {
                    if ( result.DataLength == 1 )
                    {
                        return result;
                    }

                    bool isMaxNegative = true;
                    for ( int i = 0; ( i < result.DataLength - 1 ) && isMaxNegative; ++i )
                    {
                        if ( result.data[i] != 0 )
                        {
                            isMaxNegative = false;
                        }
                    }

                    if ( isMaxNegative )
                    {
                        return result;
                    }
                }

                throw new ArithmeticException( "Multiplication overflow" );
            }

            if ( bn1IsNegative != bn2IsNegative )
            {
                return -result;
            }

            return result;
        }

        // Approved
        public static BigNumber operator -( BigNumber bn1 )
        {
            if ( ( bn1.DataLength == 1 ) && ( bn1.data[0] == 0 ) )
            {
                return new BigNumber();
            }

            BigNumber result = new BigNumber( bn1 );

            for ( int i = 0; i < MaxLength; ++i )
            {
                result.data[i] = ~bn1.data[i];
            }

            long carry = 1;
            int index = 0;

            while ( ( carry != 0 ) && ( index < MaxLength ) )
            {
                long val;
                val = result.data[index];
                ++val;

                result.data[index] = (uint)( val & 0xffffffff );
                carry = val >> 32;

                ++index;
            }

            if ( ( bn1.data[MaxLength - 1] & 0x80000000 ) == ( result.data[MaxLength - 1] & 0x80000000 ) )
            {
                throw new ArithmeticException( $"Overflow in negation" );
            }

            result.DataLength = MaxLength;

            while ( ( result.DataLength > 1 ) && ( result.data[result.DataLength - 1] == 0 ) )
            {
                --result.DataLength;
            }

            return result;
        }

        // Approved
        public static explicit operator BigNumber( int value )
        {
            return new BigNumber( value );
        }

        // Approved
        public static explicit operator BigNumber( long value )
        {
            return new BigNumber( value );
        }

        // Approved
        public byte[] GetBytes()
        {
            int numBits = this.BitCount();
            int numBytes = numBits >> 3;
            if ( ( numBits & 0x7 ) != 0 )
            {
                ++numBytes;
            }

            return this.GetBytes( numBytes );
        }

        // Approved
        public static BigNumber operator ^( BigNumber bn1, BigNumber bn2 )
        {
            BigNumber result = new BigNumber();

            int len = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;

            for ( int i = 0; i < len; ++i )
            {
                uint sum = bn1.data[i] ^ bn2.data[i];
                result.data[i] = sum;
            }

            result.DataLength = MaxLength;

            while ( ( result.DataLength > 1 ) && ( result.data[result.DataLength - 1] == 0 ) )
            {
                --result.DataLength;
            }

            return result;
        }

        // Finished
        public static bool operator <( BigNumber bn1, int bn2 )
        {
            return bn1 < (BigNumber)bn2;
        }

        // Finished
        public static bool operator >( BigNumber bn1, int bn2 )
        {
            return bn1 > (BigNumber)bn2;
        }

        // Finished
        public static bool operator ==( BigNumber bn1, int bn2 )
        {
            return bn1 == (BigNumber)bn2;
        }

        // Finished
        public static bool operator !=( BigNumber bn1, int bn2 )
        {
            return bn1 != (BigNumber)bn2;
        }

        // Finished
        public static bool operator ==( BigNumber bn1, BigNumber bn2 )
        {
            if ( ( (object)bn1 == null ) && ( (object)bn2 == null ) )
            {
                return true;
            }

            if ( ( (object)bn1 == null ) || ( (object)bn2 == null ) )
            {
                return false;
            }

            return bn1.Equals( bn2 );
        }

        // Finished
        public static bool operator !=( BigNumber bn1, BigNumber bn2 )
        {
            if ( ( (object)bn1 == null ) && ( (object)bn2 == null ) )
            {
                return false;
            }

            if ( ( (object)bn1 == null ) || ( (object)bn2 == null ) )
            {
                return true;
            }

            return !bn1.Equals( bn2 );
        }

        // Finished
        public override bool Equals( object o )
        {
            BigNumber bn = (BigNumber)o;

            if ( this.DataLength != bn.DataLength )
            {
                return false;
            }

            for ( int i = 0; i < this.DataLength; ++i )
            {
                if ( this.data[i] != bn.data[i] )
                {
                    return false;
                }
            }

            return true;
        }

        // Finished
        public static BigNumber operator %( BigNumber bn1, BigNumber bn2 )
        {
            BigNumber quotient = new BigNumber();
            BigNumber remainder = new BigNumber( bn1 );

            int lastPos = MaxLength - 1;
            bool dividendNegative = false;

            if ( ( bn1.data[lastPos] & 0x80000000 ) != 0 )
            {
                bn1 = -bn1;
                dividendNegative = true;
            }

            if ( ( bn2.data[lastPos] & 0x80000000 ) != 0 )
            {
                bn2 = -bn2;
            }

            if ( bn1 < bn2 )
            {
                return remainder;
            }


            if ( bn2.DataLength == 1 )
            {
                SingleByteDivide( bn1, bn2, quotient, remainder );
            }
            else
            {
                MultiByteDivide( bn1, bn2, quotient, remainder );
            }

            if ( dividendNegative )
            {
                return -remainder;
            }

            return remainder;
        }

        // Finished
        private static void MultiByteDivide( BigNumber bn1, BigNumber bn2, BigNumber outQuotient,
                                             BigNumber outRemainder )
        {
            uint[] result = new uint[MaxLength];

            int remainderLen = bn1.DataLength + 1;
            uint[] remainder = new uint[remainderLen];

            uint mask = 0x80000000;
            uint val = bn2.data[bn2.DataLength - 1];
            int shift = 0;
            int resultPos = 0;

            while ( ( mask != 0 ) && ( ( val & mask ) == 0 ) )
            {
                ++shift;
                mask >>= 1;
            }

            for ( int i = 0; i < bn1.DataLength; ++i )
            {
                remainder[i] = bn1.data[i];
            }

            ShiftLeft( remainder, shift );
            bn2 = bn2 << shift;

            int j = remainderLen - bn2.DataLength;
            int pos = remainderLen - 1;

            ulong firstDivisorByte = bn2.data[bn2.DataLength - 1];
            ulong secondDivisorByte = bn2.data[bn2.DataLength - 2];

            int divisorLen = bn2.DataLength + 1;
            uint[] dividendPart = new uint[divisorLen];

            while ( j > 0 )
            {
                ulong dividend = ( (ulong)remainder[pos] << 32 ) + remainder[pos - 1];

                ulong qHat = dividend / firstDivisorByte;
                ulong rHat = dividend % firstDivisorByte;

                bool done = false;
                while ( !done )
                {
                    done = true;

                    if ( ( qHat == 0x100000000 ) || ( qHat * secondDivisorByte > ( rHat << 32 ) + remainder[pos - 2] ) )
                    {
                        --qHat;
                        rHat += firstDivisorByte;

                        if ( rHat < 0x100000000 )
                        {
                            done = false;
                        }
                    }
                }

                for ( int h = 0; h < divisorLen; ++h )
                {
                    dividendPart[h] = remainder[pos - h];
                }

                BigNumber kk = new BigNumber( dividendPart );
                BigNumber ss = bn2 * (long)qHat;

                while ( ss > kk )
                {
                    --qHat;
                    ss -= bn2;
                }
                BigNumber yy = kk - ss;

                for ( int h = 0; h < divisorLen; ++h )
                {
                    remainder[pos - h] = yy.data[bn2.DataLength - h];
                }

                result[resultPos++] = (uint)qHat;

                --pos;
                --j;
            }

            outQuotient.DataLength = resultPos;
            int y = 0;
            for ( int x = outQuotient.DataLength - 1; x >= 0; --x, ++y )
            {
                outQuotient.data[y] = result[x];
            }

            for ( ; y < MaxLength; ++y )
            {
                outQuotient.data[y] = 0;
            }

            while ( ( outQuotient.DataLength > 1 ) && ( outQuotient.data[outQuotient.DataLength - 1] == 0 ) )
            {
                --outQuotient.DataLength;
            }

            if ( outQuotient.DataLength == 0 )
            {
                outQuotient.DataLength = 1;
            }

            outRemainder.DataLength = ShiftRight( remainder, shift );

            for ( y = 0; y < outRemainder.DataLength; ++y )
            {
                outRemainder.data[y] = remainder[y];
            }
            for ( ; y < MaxLength; ++y )
            {
                outRemainder.data[y] = 0;
            }
        }

        // Finished
        private static int ShiftRight( uint[] buffer, int shiftVal )
        {
            int shiftAmount = 32;
            int invShift = 0;
            int bufLen = buffer.Length;

            while ( ( bufLen > 1 ) && ( buffer[bufLen - 1] == 0 ) )
            {
                --bufLen;
            }

            for ( int count = shiftVal; count > 0; )
            {
                if ( count < shiftAmount )
                {
                    shiftAmount = count;
                    invShift = 32 - shiftAmount;
                }

                ulong carry = 0;
                for ( int i = bufLen - 1; i >= 0; --i )
                {
                    ulong val = (ulong)buffer[i] << invShift;
                    val |= carry;

                    carry = (ulong)buffer[i] << invShift;
                    buffer[i] = (uint)val;
                }

                count -= shiftAmount;
            }

            while ( ( bufLen > 1 ) && ( buffer[bufLen - 1] == 0 ) )
            {
                --bufLen;
            }

            return bufLen;
        }

        // Approved
        public static BigNumber operator -( BigNumber bn1, BigNumber bn2 )
        {
            BigNumber result = new BigNumber();

            result.DataLength = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;

            long carryIn = 0;
            for ( int i = 0; i < result.DataLength; ++i )
            {
                long bn1Data = bn1.data[i];
                long bn2Data = bn2.data[i];

                long diff = bn1Data - bn2Data - carryIn;
                result.data[i] = (uint)( diff & 0xffffffff );

                carryIn = diff < 0 ? 1 : 0;
            }

            if ( carryIn != 0 )
            {
                for ( int i = result.DataLength; i < MaxLength; ++i )
                {
                    result.data[i] = 0xffffffff;
                }

                result.DataLength = MaxLength;
            }

            while ( ( result.DataLength > 1 ) && ( result.data[result.DataLength - 1] == 0 ) )
            {
                --result.DataLength;
            }

            int lastPos = MaxLength - 1;
            if ( ( ( bn1.data[lastPos] & 0x80000000 ) != ( bn2.data[lastPos] & 0x80000000 ) ) &&
                 ( ( result.data[lastPos] & 0x80000000 ) != ( bn1.data[lastPos] & 0x80000000 ) ) )
            {
                throw new ArithmeticException();
            }

            return result;
        }

        // Approved
        public static BigNumber operator *( BigNumber bn1, long bn2 )
        {
            return bn1 * (BigNumber)bn2;
        }

        // Finished
        public static BigNumber operator <<( BigNumber bn1, int shiftVal )
        {
            BigNumber result = new BigNumber( bn1 );
            result.DataLength = ShiftLeft( result.data, shiftVal );

            return result;
        }

        // Finished
        private static int ShiftLeft( uint[] buffer, int shiftVal )
        {
            int shiftAmount = 32;
            int bufLen = buffer.Length;

            while ( ( bufLen > 1 ) && ( buffer[bufLen - 1] == 0 ) )
            {
                --bufLen;
            }

            for ( int count = shiftVal; count > 0; )
            {
                if ( count < shiftAmount )
                {
                    shiftAmount = count;
                }

                ulong carry = 0;
                for ( int i = 0; i < bufLen; ++i )
                {
                    ulong val = (ulong)buffer[i] << shiftAmount;
                    val |= carry;

                    buffer[i] = (uint)( val & 0xffffffff );
                    carry = val >> 32;
                }

                if ( carry != 0 )
                {
                    if ( bufLen + 1 <= buffer.Length )
                    {
                        buffer[bufLen] = (uint)carry;
                        ++bufLen;
                    }
                }

                count -= shiftAmount;
            }
            return bufLen;
        }

        // Finished
        private static void SingleByteDivide( BigNumber bn1, BigNumber bn2, BigNumber outQuotient,
                                              BigNumber outRemainder )
        {
            uint[] result = new uint[MaxLength];
            int resultPos = 0;

            for ( int i = 0; i < MaxLength; ++i )
            {
                outRemainder.data[i] = bn1.data[i];
            }
            outRemainder.DataLength = bn1.DataLength;

            while ( ( outRemainder.DataLength > 1 ) && ( outRemainder.data[outRemainder.DataLength - 1] == 0 ) )
            {
                --outRemainder.DataLength;
            }

            ulong divisor = bn2.data[0];
            int pos = outRemainder.DataLength - 1;
            ulong dividend = outRemainder.data[pos];

            if ( dividend >= divisor )
            {
                ulong quotient = dividend / divisor;
                result[resultPos++] = (uint)quotient;

                outRemainder.data[pos] = (uint)( dividend % divisor );
            }
            --pos;

            while ( pos >= 0 )
            {
                dividend = ( (ulong)outRemainder.data[pos + 1] << 32 ) + outRemainder.data[pos];
                ulong quotient = dividend / divisor;
                result[resultPos++] = (uint)quotient;

                outRemainder.data[pos + 1] = 0;
                outRemainder.data[pos--] = (uint)( dividend % divisor );
            }

            outQuotient.DataLength = resultPos;
            int j = 0;
            for ( int i = outQuotient.DataLength - 1; i >= 0; --i, ++j )
            {
                outQuotient.data[j] = result[i];
            }
            for ( ; j < MaxLength; ++j )
            {
                outQuotient.data[j] = 0;
            }

            while ( ( outQuotient.DataLength > 1 ) && ( outQuotient.data[outQuotient.DataLength - 1] == 0 ) )
            {
                --outQuotient.DataLength;
            }

            if ( outQuotient.DataLength == 0 )
            {
                outQuotient.DataLength = 1;
            }

            while ( ( outRemainder.DataLength > 1 ) && ( outRemainder.data[outRemainder.DataLength - 1] == 0 ) )
            {
                --outRemainder.DataLength;
            }
        }

        // Approved
        public static bool operator <( BigNumber bn1, BigNumber bn2 )
        {
            int pos = MaxLength - 1;

            if ( ( ( bn1.data[pos] & 0x80000000 ) != 0 ) && ( ( bn2.data[pos] & 0x80000000 ) == 0 ) )
            {
                return true;
            }

            if ( ( ( bn1.data[pos] & 0x80000000 ) == 0 ) && ( ( bn2.data[pos] & 0x80000000 ) != 0 ) )
            {
                return false;
            }

            int len = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;
            for ( pos = len - 1; ( pos >= 0 ) && ( bn1.data[pos] == bn2.data[pos] ); --pos )
            {
                // Ignored
            }

            if ( pos >= 0 )
            {
                if ( bn1.data[pos] < bn2.data[pos] )
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        // Approved
        public static bool operator >( BigNumber bn1, BigNumber bn2 )
        {
            int pos = MaxLength - 1;

            if ( ( ( bn1.data[pos] & 0x80000000 ) != 0 ) && ( ( bn2.data[pos] & 0x80000000 ) == 0 ) )
            {
                return false;
            }

            if ( ( ( bn1.data[pos] & 0x80000000 ) == 0 ) && ( ( bn2.data[pos] & 0x80000000 ) != 0 ) )
            {
                return true;
            }

            int len = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;
            for ( pos = len - 1; ( pos >= 0 ) && ( bn1.data[pos] == bn2.data[pos] ); --pos )
            {
                // Ignored
            }

            if ( pos >= 0 )
            {
                if ( bn1.data[pos] > bn2.data[pos] )
                {
                    return true;
                }

                return false;
            }

            return false;
        }

        // Approved
        public byte[] GetBytes( int numBytes )
        {
            byte[] result = new byte[numBytes];

            int numBits = this.BitCount();
            int realNumBytes = numBits >> 3;
            if ( ( numBits & 0x7 ) != 0 )
            {
                ++realNumBytes;
            }

            for ( int i = 0; i < realNumBytes; ++i )
            {
                for ( int b = 0; b < 4; ++b )
                {
                    if ( i * 4 + b >= realNumBytes )
                    {
                        return result;
                    }

                    result[i * 4 + b] = (byte)( ( this.data[i] >> ( b * 8 ) ) & 0xff );
                }
            }

            return result;
        }

        // Approved
        public int BitCount()
        {
            while ( ( this.DataLength > 1 ) && ( this.data[this.DataLength - 1] == 0 ) )
            {
                --this.DataLength;
            }

            uint value = this.data[this.DataLength - 1];
            uint mask = 0x80000000;
            int bits = 32;

            while ( ( bits > 0 ) && ( ( value & mask ) == 0 ) )
            {
                --bits;
                mask >>= 1;
            }

            bits += ( this.DataLength - 1 ) << 5;

            return bits;
        }

        // Approved
        public static BigNumber operator /( BigNumber bn1, BigNumber bn2 )
        {
            BigNumber quotient = new BigNumber();
            BigNumber remainder = new BigNumber();

            int lastPos = MaxLength - 1;
            bool divisorNegative = false;
            bool dividendNegative = false;

            if ( ( bn1.data[lastPos] & 0x80000000 ) != 0 )
            {
                bn1 = -bn1;
                dividendNegative = true;
            }

            if ( ( bn2.data[lastPos] & 0x80000000 ) != 0 )
            {
                bn2 = -bn2;
                divisorNegative = true;
            }

            if ( bn1 < bn2 )
            {
                return quotient;
            }

            if ( bn2.DataLength == 1 )
            {
                SingleByteDivide( bn1, bn2, quotient, remainder );
            }
            else
            {
                MultiByteDivide( bn1, bn2, quotient, remainder );
            }

            if ( dividendNegative != divisorNegative )
            {
                return -quotient;
            }

            return quotient;
        }

        // Finished
        public BigNumber ModPow( BigNumber exp, BigNumber n )
        {
            if ( ( exp.data[MaxLength - 1] & 0x80000000 ) != 0 )
            {
                throw new ArithmeticException( "Positive exponents only" );
            }

            BigNumber resultNum = (BigNumber)1;
            BigNumber tempNum;
            bool thisNegative = false;

            if ( ( this.data[MaxLength - 1] & 0x80000000 ) != 0 )
            {
                tempNum = -this % n;
                thisNegative = true;
            }
            else
            {
                tempNum = this % n;
            }

            BigNumber constant = new BigNumber();

            int i = n.DataLength << 1;
            constant.data[i] = 0x00000001;
            constant.DataLength = i + 1;

            constant = constant / n;
            int totalBits = exp.BitCount();
            int count = 0;

            for ( int pos = 0; pos < exp.DataLength; ++pos )
            {
                uint mask = 0x1;

                for ( int index = 0; index < 32; ++index )
                {
                    if ( ( exp.data[pos] & mask ) != 0 )
                    {
                        resultNum = BarrettReduction( resultNum * tempNum, n, constant );
                    }

                    mask <<= 1;

                    tempNum = BarrettReduction( tempNum * tempNum, n, constant );

                    if ( ( tempNum.DataLength == 1 ) && ( tempNum.data[0] == 1 ) )
                    {
                        if ( thisNegative && ( ( exp.data[0] & 0x1 ) != 0 ) )
                        {
                            return -resultNum;
                        }

                        return resultNum;
                    }

                    ++count;
                    if ( count == totalBits )
                    {
                        break;
                    }
                }
            }

            if ( thisNegative && ( ( exp.data[0] & 0x1 ) != 0 ) )
            {
                return -resultNum;
            }

            return resultNum;
        }

        // Finished
        private static BigNumber BarrettReduction( BigNumber x, BigNumber n, BigNumber constant )
        {
            int k = n.DataLength;
            int kPlusOne = k + 1;
            int kMinusOne = k - 1;

            BigNumber q1 = new BigNumber();

            for ( int i = kMinusOne, j = 0; i < x.DataLength; ++i, ++j )
            {
                q1.data[j] = x.data[i];
            }

            q1.DataLength = x.DataLength - kMinusOne;

            if ( q1.DataLength <= 0 )
            {
                q1.DataLength = 1;
            }

            BigNumber q2 = q1 * constant;
            BigNumber q3 = new BigNumber();

            for ( int i = kPlusOne, j = 0; i < q2.DataLength; ++i, ++j )
            {
                q3.data[j] = q2.data[i];
            }
            q3.DataLength = q2.DataLength - kPlusOne;
            if ( q3.DataLength <= 0 )
            {
                q3.DataLength = 1;
            }

            //Approved to here

            BigNumber r1 = new BigNumber();
            int lengthToCopy = x.DataLength > kPlusOne ? kPlusOne : x.DataLength;
            for ( int i = 0; i < lengthToCopy; ++i )
            {
                r1.data[i] = x.data[i];
            }
            r1.DataLength = lengthToCopy;

            BigNumber r2 = new BigNumber();
            for ( int i = 0; i < q3.DataLength; ++i )
            {
                if ( q3.data[i] == 0 )
                {
                    continue;
                }

                ulong mcarry = 0;
                int t = i;
                for ( int j = 0; ( j < n.DataLength ) && ( t < kPlusOne ); ++j, ++t )
                {
                    ulong q3Data = q3.data[i];
                    ulong nData = n.data[j];

                    ulong val = q3Data * nData + r2.data[t] + mcarry;

                    r2.data[t] = (uint)( val & 0xffffffff );
                    mcarry = val >> 32;
                }

                if ( t < kPlusOne )
                {
                    r2.data[t] = (uint)mcarry;
                }
            }

            r2.DataLength = kPlusOne;

            while ( ( r2.DataLength > 1 ) && ( r2.data[r2.DataLength - 1] == 0 ) )
            {
                --r2.DataLength;
            }

            r1 -= r2;

            if ( ( r1.data[MaxLength - 1] & 0x80000000 ) != 0 )
            {
                BigNumber val = new BigNumber();
                val.data[kPlusOne] = 0x1;
                val.DataLength = kPlusOne + 1;
                r1 += val;
            }

            while ( r1 >= n )
            {
                r1 -= n;
            }

            return r1;
        }

        // Approved
        public static bool operator >=( BigNumber bn1, BigNumber bn2 )
        {
            return ( bn1 == bn2 ) || ( bn1 > bn2 );
        }

        // Approved
        public static bool operator <=( BigNumber bn1, BigNumber bn2 )
        {
            return ( bn1 == bn2 ) || ( bn1 < bn2 );
        }
    }
}