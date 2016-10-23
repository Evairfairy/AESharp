using System;

namespace AESharp.Networking.Exceptions
{
    public class InvalidPacketException : Exception
    {
        public InvalidPacketException() { }

        public InvalidPacketException( string message ) : base( message ) { }

        public InvalidPacketException( string message, Exception inner ) : base( message, inner ) { }
    }
}
