using System;

namespace AESharp.Routing.Exceptions
{
    public class UnregisteredAEHandlerException : Exception
    {
        public UnregisteredAEHandlerException()
        {
        }

        public UnregisteredAEHandlerException(string message) : base(message)
        {
        }

        public UnregisteredAEHandlerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}