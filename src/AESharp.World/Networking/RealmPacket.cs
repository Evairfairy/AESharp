using System;
using AESharp.Networking.Data;
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
        protected int HeaderSize => this.SendingToRemoteClient ? 4 : 6;

        /// <summary>
        ///     Returns the byte[] representation of the packet header
        /// </summary>
        protected byte[] Header
        {
            get
            {
                if ( this.SendingToRemoteClient )
                {
                    byte[] header = new byte[4];

                    byte[] sizeBytes = BitConverter.GetBytes( (ushort) this.InternalBuffer.Length );
                    Array.Reverse( sizeBytes );


                    byte[] opcodeBytes = BitConverter.GetBytes( (ushort) this.Opcode );

                    Array.Copy( sizeBytes, 0, header, 0, 2 );
                    Array.Copy( opcodeBytes, 0, header, 2, 2 );

                    return header;
                }
                else
                {
                    byte[] header = new byte[6];

                    byte[] sizeBytes = BitConverter.GetBytes( (ushort) this.InternalBuffer.Length );
                    Array.Reverse( sizeBytes );

                    byte[] opcodeBytes = BitConverter.GetBytes( (uint) this.Opcode );

                    Array.Copy( sizeBytes, 0, header, 0, 2 );
                    Array.Copy( opcodeBytes, 0, header, 2, 4 );

                    return header;
                }
            }
        }

        public RealmPacket( bool sendingToRemoteClient )
        {
            this.SendingToRemoteClient = sendingToRemoteClient;
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
        public RealmPacket( byte[] data, bool sendingToRemoteClient ) : base()
        {
            this.SendingToRemoteClient = sendingToRemoteClient;

            if ( data.Length < this.HeaderSize )
            {
                throw new InvalidPacketException(
                    $"{nameof( data )} must be at least {this.HeaderSize} bytes (packet header)" );
            }

            byte[] headerBytes = new byte[this.HeaderSize];
            Array.Copy( data, headerBytes, this.HeaderSize );

            if ( data.Length != this.HeaderSize )
            {
                // We also have a payload
                this.WriteBytes( data, this.HeaderSize, data.Length - this.HeaderSize );
                this.SeekToBegin();
            }

            this.Size = BitConverter.ToUInt16( headerBytes, 0 );

            if ( this.SendingToRemoteClient )
            {
                this.Opcode = BitConverter.ToUInt16( headerBytes, 2 );
            }
            else
            {
                this.Opcode = BitConverter.ToInt32( headerBytes, 2 );
            }
        }

        /// <summary>
        ///     Constructs the packet header and returns the final byte[] representation of the packet
        /// </summary>
        /// <returns>The byte[] representation of the packet before crypto operations</returns>
        public override byte[] BuildPacket()
        {
            byte[] buffer = new byte[this.HeaderSize + this.InternalBuffer.Length];

            Array.Copy( this.Header, 0, buffer, 0, this.HeaderSize );
            Array.Copy( this.InternalBuffer, 0, buffer, this.HeaderSize, this.InternalBuffer.Length );

            return buffer;
        }
    }
}