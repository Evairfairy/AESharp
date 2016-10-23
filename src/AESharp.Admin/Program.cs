using System;
using AESharp.Core.Interfaces;
using AESharp.Logging;
using SimpleInjector;

namespace AESharp.Admin
{
    public class Program
    {
        public static void Main( string[] args )
        {
            Container container = new Container();

            container.Register<ILogger, ConsoleLogger>( Lifestyle.Singleton );

            container.Verify();

            Console.ReadLine();
        }
    }
}
