using System;
using AESharp.Networking.Data.Packets;
using AESharp.Networking.Exceptions;

namespace AESharp.World.Networking
{
    public class RealmPacket : Packet
    {
        public bool SendingToRemoteClient { get; set; }

        /// <summary>
        ///     Packet opcode
        /// </summary>
        public int Opcode { get; set; }

        /// <summary>
        ///     Packet size, as sent by the client
        /// </summary>
        public ushort Size { get; }

        /// <summary>
        ///     4 bytes if we are sending the packet, 6 if we are receiving it
        /// </summary>
        protected int HeaderSize => SendingToRemoteClient ? 4 : 6;

        /// <summary>
        ///     Returns the byte[] representation of the packet header
        /// </summary>
        protected byte[] Header
        {
            get
            {
                if (SendingToRemoteClient)
                {
                    var header = new byte[4];

                    var sizeBytes = BitConverter.GetBytes((ushort) InternalBuffer.Length);
                    Array.Reverse(sizeBytes);


                    var opcodeBytes = BitConverter.GetBytes((ushort) Opcode);

                    Array.Copy(sizeBytes, 0, header, 0, 2);
                    Array.Copy(opcodeBytes, 0, header, 2, 2);

                    return header;
                }
                else
                {
                    var header = new byte[6];

                    var sizeBytes = BitConverter.GetBytes((ushort) InternalBuffer.Length);
                    Array.Reverse(sizeBytes);

                    var opcodeBytes = BitConverter.GetBytes((uint) Opcode);

                    Array.Copy(sizeBytes, 0, header, 0, 2);
                    Array.Copy(opcodeBytes, 0, header, 2, 4);

                    return header;
                }
            }
        }

        public RealmPacket(bool sendingToRemoteClient)
        {
            SendingToRemoteClient = sendingToRemoteClient;
        }

        // We deliberately avoid passing in the data param to separate header and payload
        // ReSharper disable once RedundantBaseConstructorCall
        /// <summary>
        ///     Constructs a RealmPacket from a copy of the byte[] given.
        ///     Does not retain reader position, so if additional data should be
        ///     appended then SeekToEnd() must be called
        /// </summary>
        /// <param name="data">
        ///     The unencrypted data to construct the packet with. Must include the packet header (4 or 6 bytes),
        ///     however a payload is not required
        /// </param>
        /// <param name="sendingToRemoteClient">
        ///     True if we are sending the packet to a remote client, false if we received the
        ///     packet
        /// </param>
        public RealmPacket(byte[] data, bool sendingToRemoteClient) : base()
        {
            SendingToRemoteClient = sendingToRemoteClient;

            if (data.Length < HeaderSize)
                throw new InvalidPacketException(
                    $"{nameof(data)} must be at least {HeaderSize} bytes (packet header)");

            var headerBytes = new byte[HeaderSize];
            Array.Copy(data, headerBytes, HeaderSize);

            if (data.Length != HeaderSize)
            {
                // We also have a payload
                WriteBytes(data, HeaderSize, data.Length - HeaderSize);
                SeekToBegin();
            }

            Size = BitConverter.ToUInt16(headerBytes, 0);

            if (SendingToRemoteClient)
                Opcode = BitConverter.ToUInt16(headerBytes, 2);
            else
                Opcode = BitConverter.ToInt32(headerBytes, 2);
        }

        /// <summary>
        ///     Constructs the packet header and returns the final byte[] representation of the packet
        /// </summary>
        /// <returns>The byte[] representation of the packet before crypto operations</returns>
        public override byte[] FinalizePacket()
        {
            var buffer = new byte[HeaderSize + InternalBuffer.Length];

            Array.Copy(Header, 0, buffer, 0, HeaderSize);
            Array.Copy(InternalBuffer, 0, buffer, HeaderSize, InternalBuffer.Length);

            return buffer;
        }
    }
}