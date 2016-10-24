using System;

namespace AESharp.Routing.Exceptions
{
    public class UnhandledAEPacketException : Exception
    {
        public UnhandledAEPacketException()
        {
        }

        public UnhandledAEPacketException( string message ) : base( message )
        {
        }

        public UnhandledAEPacketException( string message, Exception inner ) : base( message, inner )
        {
        }

        public UnhandledAEPacketException( int opcode ) : base( $"Unhandled AEPacketId: {opcode:x}" )
        {
        }
    }
}