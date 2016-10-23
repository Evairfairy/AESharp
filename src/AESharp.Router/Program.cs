using System;
using System.Net;
using System.Threading.Tasks;
using AESharp.Interop;
using AESharp.Router.Routing;

namespace AESharp.Router
{
    public class Program
    {
        public static void Main( string[] args )
        {
            // Construct the router in server mode.
            MasterRouter router = new MasterRouter( IPAddress.Any );
            router.Start();
            Console.WriteLine( $"Master router listening on {IPAddress.Any}:{RoutingRemoteClient.RoutingPort}" );
            var client = Task.Run( async () => await RoutingRemoteClient.ConnectToMasterRouter() );
            // TODO: put some kind of command loop here in future
            Console.ReadLine();
        }
    }
}