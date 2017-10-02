using System;
using System.IO;
using System.Net;
using System.Text;

namespace AESharp.Networking.Data.Packets
{
    public class Packet
    {
        private readonly MemoryStream _memoryStream;
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;
        private bool _finalized = false;

        public bool Disposed { get; private set; }
        public long Length => _memoryStream.Length;

        protected byte[] InternalBuffer
        {
            get
            {
                _writer.Flush();
                _memoryStream.Flush();
                return _memoryStream.ToArray();
            }
        }

        public int BufferPosition
        {
            get => (int) _memoryStream.Position;
            set => _memoryStream.Position = value;
        }

        public int BufferLength => InternalBuffer.Length;

        public Packet(Encoding encoding = null)
            : this(new MemoryStream(), encoding)
        {
        }

        public Packet(byte[] data, Encoding encoding = null)
            : this(new MemoryStream(data), encoding)
        {
        }

        private Packet(MemoryStream dataStream, Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            _memoryStream = dataStream;
            _reader = new BinaryReader(dataStream, encoding, false);
            _writer = new BinaryWriter(dataStream, encoding, false);
        }

        /// <summary>
        ///     Returns the byte[] representation of the current packet
        /// </summary>
        /// <returns>The byte[] representation of the current packet</returns>
        public virtual byte[] FinalizePacket()
        {
            return InternalBuffer;
        }

        /// <summary>
        ///     Seeks to the beginning of the packet
        /// </summary>
        public void SeekToBegin()
        {
            _memoryStream.Seek(0, SeekOrigin.Begin);
        }

        /// <summary>
        ///     Seeks to the end of the packet
        /// </summary>
        public void SeekToEnd()
        {
            _memoryStream.Seek(0, SeekOrigin.End);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~Packet()
        {
            Dispose(false);
        }

        public int Read()
        {
            return _reader.Read();
        }

        public bool ReadBoolean()
        {
            return _reader.ReadBoolean();
        }

        public byte ReadByte()
        {
            return _reader.ReadByte();
        }

        public sbyte ReadSByte()
        {
            return _reader.ReadSByte();
        }

        public char ReadChar()
        {
            return _reader.ReadChar();
        }

        public short ReadInt16()
        {
            return _reader.ReadInt16();
        }

        public ushort ReadUInt16()
        {
            return _reader.ReadUInt16();
        }

        public int ReadInt32()
        {
            return _reader.ReadInt32();
        }

        public uint ReadUInt32()
        {
            return _reader.ReadUInt32();
        }

        public long ReadInt64()
        {
            return _reader.ReadInt64();
        }

        public ulong ReadUInt64()
        {
            return _reader.ReadUInt64();
        }

        public float ReadSingle()
        {
            return _reader.ReadSingle();
        }

        public double ReadDouble()
        {
            return _reader.ReadDouble();
        }

        public decimal ReadDecimal()
        {
            return _reader.ReadDecimal();
        }

        public string ReadString()
        {
            return _reader.ReadString();
        }

        public int Read(char[] buffer, int index, int count)
        {
            return _reader.Read(buffer, index, count);
        }

        public char[] ReadChars(int count)
        {
            return _reader.ReadChars(count);
        }

        public int Read(byte[] buffer, int index, int count)
        {
            return _reader.Read(buffer, index, count);
        }

        public byte[] ReadBytes(int count)
        {
            return _reader.ReadBytes(count);
        }

        public byte[] ReadRemainingBytes()
        {
            int remainingBytes = (int) (_memoryStream.Length - _memoryStream.Position);

            if (remainingBytes < 0)
            {
                throw new InvalidOperationException(
                    $"Internal error in Packet->{nameof(ReadRemainingBytes)}: {nameof(remainingBytes)} was {remainingBytes}");
            }

            if (remainingBytes == 0)
            {
                return new byte[0];
            }

            return ReadBytes(remainingBytes);
        }

        public string ReadFixedString(int len)
        {
            char[] chars = ReadChars(len);
            return new string(chars).TrimEnd('\0');
        }

        public string ReadByteString()
        {
            return ReadString(StringType.ByteString);
        }

        public string ReadShortString()
        {
            return ReadString(StringType.ShortString);
        }

        public string ReadCString()
        {
            return ReadString(StringType.NullTerminatedString);
        }

        public Version ReadVersion()
        {
            return new Version(
                ReadByte(),
                ReadByte(),
                ReadByte(),
                ReadUInt16()
            );
        }

        // IPv4
        public IPAddress ReadIPAddress4()
        {
            return new IPAddress(ReadBytes(4));
        }

        public DateTime ReadDateTime()
        {
            long timestamp = ReadInt64();
            return DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
        }

        public Guid ReadGuid()
        {
            byte[] buffer = ReadBytes(16);
            return new Guid(buffer);
        }

        private string ReadString(StringType stringType)
        {
            switch (stringType)
            {
                case StringType.FixedString:
                    throw new NotSupportedException("This method does not support reading fixed strings");

                case StringType.ByteString:
                {
                    byte length = ReadByte();
                    char[] chars = ReadChars(length);
                    return new string(chars);
                }

                case StringType.ShortString:
                {
                    ushort length = ReadUInt16();
                    char[] chars = ReadChars(length);
                    return new string(chars);
                }

                case StringType.NullTerminatedString:
                {
                    StringBuilder builder = new StringBuilder();
                    char c;
                    while ((c = ReadChar()) != '\0')
                    {
                        builder.Append(c);
                    }

                    return builder.ToString();
                }

                default:
                    throw new NotSupportedException(Enum.GetName(typeof(StringType), stringType));
            }
        }

        public void WriteBoolean(bool value)
        {
            _writer.Write(value);
        }

        public void WriteByte(byte value)
        {
            _writer.Write(value);
        }

        public void WriteSByte(sbyte value)
        {
            _writer.Write(value);
        }

        public void WriteBytes(byte[] buffer)
        {
            _writer.Write(buffer);
        }

        public void WriteBytes(byte[] buffer, int index, int count)
        {
            _writer.Write(buffer, index, count);
        }

        public void WriteChar(char ch)
        {
            _writer.Write(ch);
        }

        public void WriteChars(char[] chars)
        {
            _writer.Write(chars);
        }

        public void WriteChars(char[] chars, int index, int count)
        {
            _writer.Write(chars, index, count);
        }

        public void WriteDouble(double value)
        {
            _writer.Write(value);
        }

        public void WriteDecimal(decimal value)
        {
            _writer.Write(value);
        }

        public void WriteInt16(short value)
        {
            _writer.Write(value);
        }

        public void WriteUInt16(ushort value)
        {
            _writer.Write(value);
        }

        public void WriteInt32(int value)
        {
            _writer.Write(value);
        }

        public void WriteUInt32(uint value)
        {
            _writer.Write(value);
        }

        public void WriteInt64(long value)
        {
            _writer.Write(value);
        }

        public void WriteUInt64(ulong value)
        {
            _writer.Write(value);
        }

        public void WriteSingle(float value)
        {
            _writer.Write(value);
        }

        public void WriteDateTime(DateTime value)
        {
            DateTimeOffset offset = value.Kind != DateTimeKind.Utc ? value.ToUniversalTime() : value;
            WriteInt64(offset.ToUnixTimeSeconds());
        }

        public void WriteGuid(Guid guid)
        {
            byte[] bytes = guid.ToByteArray();
            WriteBytes(bytes);
        }

        public void WriteFixedString(string value)
        {
            WriteString(value, StringType.FixedString);
        }

        public void WriteByteString(string value)
        {
            WriteString(value, StringType.ByteString);
        }

        public void WriteShortString(string value)
        {
            WriteString(value, StringType.ShortString);
        }

        public void WriteCString(string value)
        {
            WriteString(value, StringType.NullTerminatedString);
        }

        private void WriteString(string value, StringType type)
        {
            switch (type)
            {
                case StringType.FixedString:
                {
                    WriteChars(value.ToCharArray());
                    return;
                }
                case StringType.NullTerminatedString:
                {
                    WriteChars(value.ToCharArray());
                    WriteByte(0x0);
                    return;
                }
                case StringType.ByteString:
                {
                    ValidateStringLengthOrThrow(value.Length, byte.MaxValue);
                    WriteByte((byte) value.Length);
                    WriteChars(value.ToCharArray());
                    return;
                }
                case StringType.ShortString:
                {
                    ValidateStringLengthOrThrow(value.Length, ushort.MaxValue);
                    WriteUInt16((ushort) value.Length);
                    WriteChars(value.ToCharArray());
                    return;
                }
            }
        }

        private void WriteString(string value, StringPrefix prefix, StringTerminator terminator)
        {
            int maxLength = 0;
            switch (terminator)
            {
                case StringTerminator.None:
                    break;

                // We don't actually care about these when there's a prefix
                case StringTerminator.Null:
                case StringTerminator.Space:
                    maxLength -= 1;
                    break;

                default:
                    throw new NotSupportedException(Enum.GetName(typeof(StringTerminator), terminator));
            }

            switch (prefix)
            {
                case StringPrefix.None:
                    if (terminator == StringTerminator.None)
                    {
                        throw new InvalidOperationException(
                            "String terminator cannot be none when there is no prefix");
                    }
                    break;

                case StringPrefix.Byte:
                    maxLength = byte.MaxValue;
                    ValidateStringLengthOrThrow(value.Length, maxLength);
                    WriteByte((byte) value.Length);
                    break;

                case StringPrefix.Short:
                    maxLength = short.MinValue;
                    ValidateStringLengthOrThrow(value.Length, maxLength);
                    WriteInt16((short) value.Length);
                    break;

                case StringPrefix.Int:
                    maxLength = int.MaxValue;
                    ValidateStringLengthOrThrow(value.Length, maxLength);
                    WriteInt32(value.Length);
                    break;

                default:
                    throw new NotSupportedException(Enum.GetName(typeof(StringPrefix), prefix));
            }

            WriteChars(value.ToCharArray());
        }

        private void ValidateStringLengthOrThrow(int actualLength, int maxAllowedLength)
        {
            if (actualLength > maxAllowedLength)
            {
                throw new InvalidOperationException(
                    $"String length ({actualLength:#,#0}) exceeds maximum length of {maxAllowedLength:#,#0}");
            }
        }

        protected virtual void Dispose(bool disposeManagedResources)
        {
            if (Disposed)
            {
                return;
            }

            if (disposeManagedResources)
            {
                _memoryStream.Dispose();
                _reader.Dispose();
                _writer.Dispose();
            }

            Disposed = true;
        }
    }
}