using System;

namespace AESharp.Networking.Exceptions
{
    public class UnhandledPacketException : Exception
    {
        public UnhandledPacketException() { }

        public UnhandledPacketException( string message ) : base( message ) { }

        public UnhandledPacketException( string message, Exception inner ) : base( message, inner ) { }

        public UnhandledPacketException( int opcode ) : this( $"Unhandled packet: 0x{opcode:x}" ) { }
    }
}