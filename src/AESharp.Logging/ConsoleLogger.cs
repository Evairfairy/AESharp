using System;
using AESharp.Core.Interfaces;

namespace AESharp.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void WriteLine( string line )
        {
            Console.WriteLine( line );
        }
    }
}