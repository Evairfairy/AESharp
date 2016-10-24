using System;
using System.Net;
using AESharp.Routing.Routing;

namespace AESharp.Routing
{
    public class Program
    {
        public static void Main( string[] args )
        {
            // Construct the router in server mode.
            MasterRouter router = new MasterRouter( IPAddress.Any );
            router.Start();
            Console.WriteLine( $"Master router listening on {IPAddress.Any}:{RoutingRemoteClient.RoutingPort}" );
            // TODO: put some kind of command loop here in future
            Console.ReadLine();
        }
    }
}