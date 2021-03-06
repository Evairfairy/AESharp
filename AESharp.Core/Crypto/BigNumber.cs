﻿using System;

namespace AESharp.Core.Crypto
{
    public class BigNumber
    {
        private const int MaxLength = 70;

        private uint[] data;
        public int DataLength;

        // Approved
        public BigNumber(long value)
        {
            data = new uint[MaxLength];
            var tempVal = value;

            DataLength = 0;
            while (value != 0 && DataLength < MaxLength)
            {
                data[DataLength] = (uint) (value & 0xffffffff);
                value >>= 32;
                ++DataLength;
            }

            if (tempVal > 0)
            {
                if (value != 0 || (data[MaxLength - 1] & 0x80000000) != 0)
                    throw new ArithmeticException(
                        $"Positive overflow while constructing BigNumber with parameter {tempVal}");
            }
            else if (tempVal < 0)
            {
                if (value != -1 || (data[DataLength - 1] & 0x80000000) == 0)
                    throw new ArithmeticException(
                        $"Negative underflow while constructing BigNumber with parameter {tempVal}");
            }

            if (DataLength == 0)
                DataLength = 1;
        }

        // Approved
        public BigNumber(string value, int radix)
        {
            var multiplier = new BigNumber(1);
            var result = new BigNumber();
            value = value.ToUpper().Trim();
            var limit = 0;

            if (value[0] == '-')
                limit = 1;

            for (var i = value.Length - 1; i >= limit; --i)
            {
                int posVal = value[i];

                if (posVal >= '0' && posVal <= '9')
                    posVal -= '0';
                else if (posVal >= 'A' && posVal <= 'Z')
                    posVal = posVal - 'A' + 10;
                else
                    posVal = 9999999;

                if (posVal >= radix)
                    throw new ArithmeticException($"Invalid string when constructing {nameof(BigNumber)} ({value})");

                if (value[0] == '-')
                    posVal = -posVal;

                result = result + multiplier * posVal;

                if (i - 1 >= limit)
                    multiplier = multiplier * radix;
            }

            if (value[0] == '-')
            {
                if ((result.data[MaxLength - 1] & 0x80000000) == 0)
                    throw new ArithmeticException($"Negative underflow while constructing {nameof(BigNumber)}");
            }
            else
            {
                if ((result.data[MaxLength - 1] & 0x80000000) != 0)
                    throw new ArithmeticException($"Positive overflow while constructing {nameof(BigNumber)}");
            }

            data = new uint[MaxLength];
            for (var i = 0; i < result.DataLength; ++i)
            {
                data[i] = result.data[i];
            }

            DataLength = result.DataLength;
        }

        // Approved
        public BigNumber()
        {
            data = new uint[MaxLength];
            DataLength = 1;
        }

        // Approved
        public BigNumber(BigNumber bn)
        {
            SetValue(bn);
        }

        // Approved
        public BigNumber(byte[] inData)
        {
            inData = (byte[]) inData.Clone();

            Reverse(inData);
            DataLength = inData.Length >> 2;

            var leftOver = inData.Length & 0x3;

            // Length is not a multiple of 4
            if (leftOver != 0)
                ++DataLength;

            data = new uint[MaxLength];

            for (int i = inData.Length - 1, j = 0; i >= 3; i -= 4, ++j)
            {
                data[j] =
                    (uint)
                    ((inData[i - 3] << 24) + (inData[i - 2] << 16) + (inData[i - 1] << 8) + inData[i]);
            }

            switch (leftOver)
            {
                case 1:
                {
                    data[DataLength - 1] = inData[0];
                    break;
                }
                case 2:
                {
                    data[DataLength - 1] = (uint) ((inData[0] << 8) + inData[1]);
                    break;
                }
                case 3:
                {
                    data[DataLength - 1] = (uint) ((inData[0] << 16) + (inData[1] << 8) + inData[2]);
                    break;
                }
            }

            while (DataLength > 1 && data[DataLength - 1] == 0)
            {
                --DataLength;
            }
        }

        // Approved
        public BigNumber(uint[] inData)
        {
            DataLength = inData.Length;

            if (DataLength > MaxLength)
                throw new ArithmeticException("Byte overflow in constructor");

            data = new uint[MaxLength];

            for (int i = DataLength - 1, j = 0; i >= 0; --i, ++j)
            {
                data[j] = inData[i];
            }

            while (DataLength > 1 && data[DataLength - 1] == 0)
            {
                --DataLength;
            }
        }

        // Approved
        public static implicit operator BigNumber(byte[] value)
        {
            return new BigNumber(value);
        }

        // Approved
        private static void Reverse<T>(T[] buffer)
        {
            Reverse(buffer, buffer.Length);
        }

        // Approved
        private static void Reverse<T>(T[] buffer, int length)
        {
            for (var i = 0; i < length / 2; ++i)
            {
                var temp = buffer[i];
                buffer[i] = buffer[length - i - 1];
                buffer[length - i - 1] = temp;
            }
        }

        // Approved
        private void SetValue(BigNumber bn)
        {
            data = new uint[MaxLength];

            DataLength = bn.DataLength;

            for (var i = 0; i < DataLength; ++i)
            {
                data[i] = bn.data[i];
            }
        }

        // Approved
        public static BigNumber operator *(BigNumber bn1, int bn2)
        {
            return bn1 * (BigNumber) bn2;
        }

        // Approved
        public static BigNumber operator +(BigNumber bn1, BigNumber bn2)
        {
            var result = new BigNumber();

            result.DataLength = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;

            long carry = 0;
            for (var i = 0; i < result.DataLength; ++i)
            {
                long bnData1 = bn1.data[i];
                long bnData2 = bn2.data[i];
                var sum = bnData1 + bnData2 + carry;
                carry = sum >> 32;
                result.data[i] = (uint) (sum & 0xffffffff);
            }

            if (carry != 0 && result.DataLength < MaxLength)
            {
                result.data[result.DataLength] = (uint) carry;
                ++result.DataLength;
            }

            while (result.DataLength > 1 && result.data[result.DataLength - 1] == 0)
            {
                --result.DataLength;
            }

            var lastPos = MaxLength - 1;
            if ((bn1.data[lastPos] & 0x80000000) == (bn2.data[lastPos] & 0x80000000) &&
                (result.data[lastPos] & 0x80000000) != (bn1.data[lastPos] & 0x80000000))
                throw new ArithmeticException();

            return result;
        }

        // Approved
        public static BigNumber operator *(BigNumber bn1, BigNumber bn2)
        {
            var lastPos = MaxLength - 1;
            var bn1IsNegative = false;
            var bn2IsNegative = false;

            try
            {
                if ((bn1.data[lastPos] & 0x80000000) != 0)
                {
                    bn1IsNegative = true;
                    bn1 = -bn1;
                }

                if ((bn2.data[lastPos] & 0x80000000) != 0)
                {
                    bn2IsNegative = true;
                    bn2 = -bn2;
                }
            }
            catch
            {
                // ignored
            }

            var result = new BigNumber();

            try
            {
                for (var i = 0; i < bn1.DataLength; ++i)
                {
                    if (bn1.data[i] == 0)
                        continue;

                    ulong mcarry = 0;
                    for (int j = 0, k = i; j < bn2.DataLength; ++j, ++k)
                    {
                        ulong bn1Data = bn1.data[i];
                        ulong bn2Data = bn2.data[j];
                        var val = bn1Data * bn2Data + result.data[k] + mcarry;

                        result.data[k] = (uint) (val & 0xffffffff);
                        mcarry = val >> 32;
                    }

                    if (mcarry != 0)
                        result.data[i + bn2.DataLength] = (uint) mcarry;
                }
            }
            catch
            {
                throw new ArithmeticException("Multiplication overflow");
            }

            result.DataLength = bn1.DataLength + bn2.DataLength;
            if (result.DataLength > MaxLength)
                result.DataLength = MaxLength;

            while (result.DataLength > 1 && result.data[result.DataLength - 1] == 0)
            {
                --result.DataLength;
            }

            if ((result.data[lastPos] & 0x80000000) != 0)
            {
                // ReSharper disable once InvertIf
                if (bn1IsNegative != bn2IsNegative && result.data[lastPos] == 0x80000000)
                {
                    if (result.DataLength == 1)
                        return result;

                    var isMaxNegative = true;
                    for (var i = 0; i < result.DataLength - 1 && isMaxNegative; ++i)
                    {
                        if (result.data[i] != 0)
                            isMaxNegative = false;
                    }

                    if (isMaxNegative)
                        return result;
                }

                throw new ArithmeticException("Multiplication overflow");
            }

            if (bn1IsNegative != bn2IsNegative)
                return -result;

            return result;
        }

        // Approved
        public static BigNumber operator -(BigNumber bn1)
        {
            if (bn1.DataLength == 1 && bn1.data[0] == 0)
                return new BigNumber();

            var result = new BigNumber(bn1);

            for (var i = 0; i < MaxLength; ++i)
            {
                result.data[i] = ~bn1.data[i];
            }

            long carry = 1;
            var index = 0;

            while (carry != 0 && index < MaxLength)
            {
                long val;
                val = result.data[index];
                ++val;

                result.data[index] = (uint) (val & 0xffffffff);
                carry = val >> 32;

                ++index;
            }

            if ((bn1.data[MaxLength - 1] & 0x80000000) == (result.data[MaxLength - 1] & 0x80000000))
                throw new ArithmeticException($"Overflow in negation");

            result.DataLength = MaxLength;

            while (result.DataLength > 1 && result.data[result.DataLength - 1] == 0)
            {
                --result.DataLength;
            }

            return result;
        }

        // Approved
        public static explicit operator BigNumber(int value)
        {
            return new BigNumber(value);
        }

        // Approved
        public static explicit operator BigNumber(long value)
        {
            return new BigNumber(value);
        }

        // Approved
        public byte[] GetBytes()
        {
            var numBits = BitCount();
            var numBytes = numBits >> 3;
            if ((numBits & 0x7) != 0)
                ++numBytes;

            return GetBytes(numBytes);
        }

        // Approved
        public static BigNumber operator ^(BigNumber bn1, BigNumber bn2)
        {
            var result = new BigNumber();

            var len = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;

            for (var i = 0; i < len; ++i)
            {
                var sum = bn1.data[i] ^ bn2.data[i];
                result.data[i] = sum;
            }

            result.DataLength = MaxLength;

            while (result.DataLength > 1 && result.data[result.DataLength - 1] == 0)
            {
                --result.DataLength;
            }

            return result;
        }

        // Finished
        public static bool operator <(BigNumber bn1, int bn2)
        {
            return bn1 < (BigNumber) bn2;
        }

        // Finished
        public static bool operator >(BigNumber bn1, int bn2)
        {
            return bn1 > (BigNumber) bn2;
        }

        // Finished
        public static bool operator ==(BigNumber bn1, int bn2)
        {
            return bn1 == (BigNumber) bn2;
        }

        // Finished
        public static bool operator !=(BigNumber bn1, int bn2)
        {
            return bn1 != (BigNumber) bn2;
        }

        // Finished
        public static bool operator ==(BigNumber bn1, BigNumber bn2)
        {
            if ((object) bn1 == null && (object) bn2 == null)
                return true;

            if ((object) bn1 == null || (object) bn2 == null)
                return false;

            return bn1.Equals(bn2);
        }

        // Finished
        public static bool operator !=(BigNumber bn1, BigNumber bn2)
        {
            if ((object) bn1 == null && (object) bn2 == null)
                return false;

            if ((object) bn1 == null || (object) bn2 == null)
                return true;

            return !bn1.Equals(bn2);
        }

        // Finished
        public override bool Equals(object o)
        {
            var bn = (BigNumber) o;

            if (DataLength != bn.DataLength)
                return false;

            for (var i = 0; i < DataLength; ++i)
            {
                if (data[i] != bn.data[i])
                    return false;
            }

            return true;
        }

        // Finished
        public static BigNumber operator %(BigNumber bn1, BigNumber bn2)
        {
            var quotient = new BigNumber();
            var remainder = new BigNumber(bn1);

            var lastPos = MaxLength - 1;
            var dividendNegative = false;

            if ((bn1.data[lastPos] & 0x80000000) != 0)
            {
                bn1 = -bn1;
                dividendNegative = true;
            }

            if ((bn2.data[lastPos] & 0x80000000) != 0)
                bn2 = -bn2;

            if (bn1 < bn2)
                return remainder;


            if (bn2.DataLength == 1)
                SingleByteDivide(bn1, bn2, quotient, remainder);
            else
                MultiByteDivide(bn1, bn2, quotient, remainder);

            if (dividendNegative)
                return -remainder;

            return remainder;
        }

        // Finished
        private static void MultiByteDivide(BigNumber bn1, BigNumber bn2, BigNumber outQuotient,
            BigNumber outRemainder)
        {
            var result = new uint[MaxLength];

            var remainderLen = bn1.DataLength + 1;
            var remainder = new uint[remainderLen];

            var mask = 0x80000000;
            var val = bn2.data[bn2.DataLength - 1];
            var shift = 0;
            var resultPos = 0;

            while (mask != 0 && (val & mask) == 0)
            {
                ++shift;
                mask >>= 1;
            }

            for (var i = 0; i < bn1.DataLength; ++i)
            {
                remainder[i] = bn1.data[i];
            }

            ShiftLeft(remainder, shift);
            bn2 = bn2 << shift;

            var j = remainderLen - bn2.DataLength;
            var pos = remainderLen - 1;

            ulong firstDivisorByte = bn2.data[bn2.DataLength - 1];
            ulong secondDivisorByte = bn2.data[bn2.DataLength - 2];

            var divisorLen = bn2.DataLength + 1;
            var dividendPart = new uint[divisorLen];

            while (j > 0)
            {
                var dividend = ((ulong) remainder[pos] << 32) + remainder[pos - 1];

                var qHat = dividend / firstDivisorByte;
                var rHat = dividend % firstDivisorByte;

                var done = false;
                while (!done)
                {
                    done = true;

                    if (qHat == 0x100000000 || qHat * secondDivisorByte > (rHat << 32) + remainder[pos - 2])
                    {
                        --qHat;
                        rHat += firstDivisorByte;

                        if (rHat < 0x100000000)
                            done = false;
                    }
                }

                for (var h = 0; h < divisorLen; ++h)
                {
                    dividendPart[h] = remainder[pos - h];
                }

                var kk = new BigNumber(dividendPart);
                var ss = bn2 * (long) qHat;

                while (ss > kk)
                {
                    --qHat;
                    ss -= bn2;
                }
                var yy = kk - ss;

                for (var h = 0; h < divisorLen; ++h)
                {
                    remainder[pos - h] = yy.data[bn2.DataLength - h];
                }

                result[resultPos++] = (uint) qHat;

                --pos;
                --j;
            }

            outQuotient.DataLength = resultPos;
            var y = 0;
            for (var x = outQuotient.DataLength - 1; x >= 0; --x, ++y)
            {
                outQuotient.data[y] = result[x];
            }

            for (; y < MaxLength; ++y)
            {
                outQuotient.data[y] = 0;
            }

            while (outQuotient.DataLength > 1 && outQuotient.data[outQuotient.DataLength - 1] == 0)
            {
                --outQuotient.DataLength;
            }

            if (outQuotient.DataLength == 0)
                outQuotient.DataLength = 1;

            outRemainder.DataLength = ShiftRight(remainder, shift);

            for (y = 0; y < outRemainder.DataLength; ++y)
            {
                outRemainder.data[y] = remainder[y];
            }
            for (; y < MaxLength; ++y)
            {
                outRemainder.data[y] = 0;
            }
        }

        // Finished
        private static int ShiftRight(uint[] buffer, int shiftVal)
        {
            var shiftAmount = 32;
            var invShift = 0;
            var bufLen = buffer.Length;

            while (bufLen > 1 && buffer[bufLen - 1] == 0)
            {
                --bufLen;
            }

            for (var count = shiftVal; count > 0;)
            {
                if (count < shiftAmount)
                {
                    shiftAmount = count;
                    invShift = 32 - shiftAmount;
                }

                ulong carry = 0;
                for (var i = bufLen - 1; i >= 0; --i)
                {
                    var val = (ulong) buffer[i] << invShift;
                    val |= carry;

                    carry = (ulong) buffer[i] << invShift;
                    buffer[i] = (uint) val;
                }

                count -= shiftAmount;
            }

            while (bufLen > 1 && buffer[bufLen - 1] == 0)
            {
                --bufLen;
            }

            return bufLen;
        }

        // Approved
        public static BigNumber operator -(BigNumber bn1, BigNumber bn2)
        {
            var result = new BigNumber();

            result.DataLength = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;

            long carryIn = 0;
            for (var i = 0; i < result.DataLength; ++i)
            {
                long bn1Data = bn1.data[i];
                long bn2Data = bn2.data[i];

                var diff = bn1Data - bn2Data - carryIn;
                result.data[i] = (uint) (diff & 0xffffffff);

                carryIn = diff < 0 ? 1 : 0;
            }

            if (carryIn != 0)
            {
                for (var i = result.DataLength; i < MaxLength; ++i)
                {
                    result.data[i] = 0xffffffff;
                }

                result.DataLength = MaxLength;
            }

            while (result.DataLength > 1 && result.data[result.DataLength - 1] == 0)
            {
                --result.DataLength;
            }

            var lastPos = MaxLength - 1;
            if ((bn1.data[lastPos] & 0x80000000) != (bn2.data[lastPos] & 0x80000000) &&
                (result.data[lastPos] & 0x80000000) != (bn1.data[lastPos] & 0x80000000))
                throw new ArithmeticException();

            return result;
        }

        // Approved
        public static BigNumber operator *(BigNumber bn1, long bn2)
        {
            return bn1 * (BigNumber) bn2;
        }

        // Finished
        public static BigNumber operator <<(BigNumber bn1, int shiftVal)
        {
            var result = new BigNumber(bn1);
            result.DataLength = ShiftLeft(result.data, shiftVal);

            return result;
        }

        // Finished
        private static int ShiftLeft(uint[] buffer, int shiftVal)
        {
            var shiftAmount = 32;
            var bufLen = buffer.Length;

            while (bufLen > 1 && buffer[bufLen - 1] == 0)
            {
                --bufLen;
            }

            for (var count = shiftVal; count > 0;)
            {
                if (count < shiftAmount)
                    shiftAmount = count;

                ulong carry = 0;
                for (var i = 0; i < bufLen; ++i)
                {
                    var val = (ulong) buffer[i] << shiftAmount;
                    val |= carry;

                    buffer[i] = (uint) (val & 0xffffffff);
                    carry = val >> 32;
                }

                if (carry != 0)
                    if (bufLen + 1 <= buffer.Length)
                    {
                        buffer[bufLen] = (uint) carry;
                        ++bufLen;
                    }

                count -= shiftAmount;
            }
            return bufLen;
        }

        // Finished
        private static void SingleByteDivide(BigNumber bn1, BigNumber bn2, BigNumber outQuotient,
            BigNumber outRemainder)
        {
            var result = new uint[MaxLength];
            var resultPos = 0;

            for (var i = 0; i < MaxLength; ++i)
            {
                outRemainder.data[i] = bn1.data[i];
            }
            outRemainder.DataLength = bn1.DataLength;

            while (outRemainder.DataLength > 1 && outRemainder.data[outRemainder.DataLength - 1] == 0)
            {
                --outRemainder.DataLength;
            }

            ulong divisor = bn2.data[0];
            var pos = outRemainder.DataLength - 1;
            ulong dividend = outRemainder.data[pos];

            if (dividend >= divisor)
            {
                var quotient = dividend / divisor;
                result[resultPos++] = (uint) quotient;

                outRemainder.data[pos] = (uint) (dividend % divisor);
            }
            --pos;

            while (pos >= 0)
            {
                dividend = ((ulong) outRemainder.data[pos + 1] << 32) + outRemainder.data[pos];
                var quotient = dividend / divisor;
                result[resultPos++] = (uint) quotient;

                outRemainder.data[pos + 1] = 0;
                outRemainder.data[pos--] = (uint) (dividend % divisor);
            }

            outQuotient.DataLength = resultPos;
            var j = 0;
            for (var i = outQuotient.DataLength - 1; i >= 0; --i, ++j)
            {
                outQuotient.data[j] = result[i];
            }
            for (; j < MaxLength; ++j)
            {
                outQuotient.data[j] = 0;
            }

            while (outQuotient.DataLength > 1 && outQuotient.data[outQuotient.DataLength - 1] == 0)
            {
                --outQuotient.DataLength;
            }

            if (outQuotient.DataLength == 0)
                outQuotient.DataLength = 1;

            while (outRemainder.DataLength > 1 && outRemainder.data[outRemainder.DataLength - 1] == 0)
            {
                --outRemainder.DataLength;
            }
        }

        // Approved
        public static bool operator <(BigNumber bn1, BigNumber bn2)
        {
            var pos = MaxLength - 1;

            if ((bn1.data[pos] & 0x80000000) != 0 && (bn2.data[pos] & 0x80000000) == 0)
                return true;

            if ((bn1.data[pos] & 0x80000000) == 0 && (bn2.data[pos] & 0x80000000) != 0)
                return false;

            var len = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;
            for (pos = len - 1; pos >= 0 && bn1.data[pos] == bn2.data[pos]; --pos)
            {
                // Ignored
            }

            if (pos >= 0)
            {
                if (bn1.data[pos] < bn2.data[pos])
                    return true;

                return false;
            }

            return false;
        }

        // Approved
        public static bool operator >(BigNumber bn1, BigNumber bn2)
        {
            var pos = MaxLength - 1;

            if ((bn1.data[pos] & 0x80000000) != 0 && (bn2.data[pos] & 0x80000000) == 0)
                return false;

            if ((bn1.data[pos] & 0x80000000) == 0 && (bn2.data[pos] & 0x80000000) != 0)
                return true;

            var len = bn1.DataLength > bn2.DataLength ? bn1.DataLength : bn2.DataLength;
            for (pos = len - 1; pos >= 0 && bn1.data[pos] == bn2.data[pos]; --pos)
            {
                // Ignored
            }

            if (pos >= 0)
            {
                if (bn1.data[pos] > bn2.data[pos])
                    return true;

                return false;
            }

            return false;
        }

        // Approved
        public byte[] GetBytes(int numBytes)
        {
            var result = new byte[numBytes];

            var numBits = BitCount();
            var realNumBytes = numBits >> 3;
            if ((numBits & 0x7) != 0)
                ++realNumBytes;

            for (var i = 0; i < realNumBytes; ++i)
            {
                for (var b = 0; b < 4; ++b)
                {
                    if (i * 4 + b >= realNumBytes)
                        return result;

                    result[i * 4 + b] = (byte) ((data[i] >> (b * 8)) & 0xff);
                }
            }

            return result;
        }

        // Approved
        public int BitCount()
        {
            while (DataLength > 1 && data[DataLength - 1] == 0)
            {
                --DataLength;
            }

            var value = data[DataLength - 1];
            var mask = 0x80000000;
            var bits = 32;

            while (bits > 0 && (value & mask) == 0)
            {
                --bits;
                mask >>= 1;
            }

            bits += (DataLength - 1) << 5;

            return bits;
        }

        // Approved
        public static BigNumber operator /(BigNumber bn1, BigNumber bn2)
        {
            var quotient = new BigNumber();
            var remainder = new BigNumber();

            var lastPos = MaxLength - 1;
            var divisorNegative = false;
            var dividendNegative = false;

            if ((bn1.data[lastPos] & 0x80000000) != 0)
            {
                bn1 = -bn1;
                dividendNegative = true;
            }

            if ((bn2.data[lastPos] & 0x80000000) != 0)
            {
                bn2 = -bn2;
                divisorNegative = true;
            }

            if (bn1 < bn2)
                return quotient;

            if (bn2.DataLength == 1)
                SingleByteDivide(bn1, bn2, quotient, remainder);
            else
                MultiByteDivide(bn1, bn2, quotient, remainder);

            if (dividendNegative != divisorNegative)
                return -quotient;

            return quotient;
        }

        // Finished
        public BigNumber ModPow(BigNumber exp, BigNumber n)
        {
            if ((exp.data[MaxLength - 1] & 0x80000000) != 0)
                throw new ArithmeticException("Positive exponents only");

            var resultNum = (BigNumber) 1;
            BigNumber tempNum;
            var thisNegative = false;

            if ((data[MaxLength - 1] & 0x80000000) != 0)
            {
                tempNum = -this % n;
                thisNegative = true;
            }
            else
            {
                tempNum = this % n;
            }

            var constant = new BigNumber();

            var i = n.DataLength << 1;
            constant.data[i] = 0x00000001;
            constant.DataLength = i + 1;

            constant = constant / n;
            var totalBits = exp.BitCount();
            var count = 0;

            for (var pos = 0; pos < exp.DataLength; ++pos)
            {
                uint mask = 0x1;

                for (var index = 0; index < 32; ++index)
                {
                    if ((exp.data[pos] & mask) != 0)
                        resultNum = BarrettReduction(resultNum * tempNum, n, constant);

                    mask <<= 1;

                    tempNum = BarrettReduction(tempNum * tempNum, n, constant);

                    if (tempNum.DataLength == 1 && tempNum.data[0] == 1)
                    {
                        if (thisNegative && (exp.data[0] & 0x1) != 0)
                            return -resultNum;

                        return resultNum;
                    }

                    ++count;
                    if (count == totalBits)
                        break;
                }
            }

            if (thisNegative && (exp.data[0] & 0x1) != 0)
                return -resultNum;

            return resultNum;
        }

        // Finished
        private static BigNumber BarrettReduction(BigNumber x, BigNumber n, BigNumber constant)
        {
            var k = n.DataLength;
            var kPlusOne = k + 1;
            var kMinusOne = k - 1;

            var q1 = new BigNumber();

            for (int i = kMinusOne, j = 0; i < x.DataLength; ++i, ++j)
            {
                q1.data[j] = x.data[i];
            }

            q1.DataLength = x.DataLength - kMinusOne;

            if (q1.DataLength <= 0)
                q1.DataLength = 1;

            var q2 = q1 * constant;
            var q3 = new BigNumber();

            for (int i = kPlusOne, j = 0; i < q2.DataLength; ++i, ++j)
            {
                q3.data[j] = q2.data[i];
            }
            q3.DataLength = q2.DataLength - kPlusOne;
            if (q3.DataLength <= 0)
                q3.DataLength = 1;

            //Approved to here

            var r1 = new BigNumber();
            var lengthToCopy = x.DataLength > kPlusOne ? kPlusOne : x.DataLength;
            for (var i = 0; i < lengthToCopy; ++i)
            {
                r1.data[i] = x.data[i];
            }
            r1.DataLength = lengthToCopy;

            var r2 = new BigNumber();
            for (var i = 0; i < q3.DataLength; ++i)
            {
                if (q3.data[i] == 0)
                    continue;

                ulong mcarry = 0;
                var t = i;
                for (var j = 0; j < n.DataLength && t < kPlusOne; ++j, ++t)
                {
                    ulong q3Data = q3.data[i];
                    ulong nData = n.data[j];

                    var val = q3Data * nData + r2.data[t] + mcarry;

                    r2.data[t] = (uint) (val & 0xffffffff);
                    mcarry = val >> 32;
                }

                if (t < kPlusOne)
                    r2.data[t] = (uint) mcarry;
            }

            r2.DataLength = kPlusOne;

            while (r2.DataLength > 1 && r2.data[r2.DataLength - 1] == 0)
            {
                --r2.DataLength;
            }

            r1 -= r2;

            if ((r1.data[MaxLength - 1] & 0x80000000) != 0)
            {
                var val = new BigNumber();
                val.data[kPlusOne] = 0x1;
                val.DataLength = kPlusOne + 1;
                r1 += val;
            }

            while (r1 >= n)
            {
                r1 -= n;
            }

            return r1;
        }

        // Approved
        public static bool operator >=(BigNumber bn1, BigNumber bn2)
        {
            return bn1 == bn2 || bn1 > bn2;
        }

        // Approved
        public static bool operator <=(BigNumber bn1, BigNumber bn2)
        {
            return bn1 == bn2 || bn1 < bn2;
        }
    }
}