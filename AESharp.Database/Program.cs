using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Configuration;
using AESharp.Core.Extensions;
using AESharp.Database.Configuration;
using AESharp.Database.Entities;
using AESharp.Routing.Core;
using AESharp.Routing.Middleware;
using AESharp.Routing.Networking;
using AESharp.Routing.Networking.Packets.Handshaking;

namespace AESharp.Database
{
    internal static class Program
    {
        static Program()
        {
            // This must be second (after decryption)
            DatabaseServices.IncomingRoutingMiddlewareHandler.RegisterMiddleware(new AEPacketReaderMiddleware());

            // This must be second-to-last (before encryption)
            DatabaseServices.OutgoingRoutingMiddlewareHandler.RegisterMiddleware(new AEPacketBuilderMiddleware());
        }

        private static void Main(string[] args)
        {
            var loader = new JsonConfigLoader();
            var config = new DatabasesConfig
            {
                Accounts = new DatabaseSettings
                {
                    FileName = "accounts.db",
                    Password = null
                },

                World = new DatabaseSettings
                {
                    FileName = "world.db",
                    Password = null
                }
            };

            // NOTE: this has to be disposed before the program terminates or changes will not be flushed to disk
            var accounts = new AccountsDatabase( config.Accounts );

            try
            {
                config = loader.Load<DatabasesConfig>( "database" );
                ConnectToMasterRouterAsync( IPAddress.Loopback, 12000 ).RunAsync();
                Console.ReadLine();
            }
            catch( DirectoryNotFoundException ex )
            {
                Console.Error.WriteLine( "Config directory not found, attempting to create default file..." );
                Directory.CreateDirectory( loader.RootDirectory );
                loader.CreateDefault( "database", config );
            }
            catch( FileNotFoundException ex )
            {
                Console.Error.WriteLine( "Config file not found, attempting to create default file..." );
                loader.CreateDefault( "database", config );
            }
            finally
            {
                accounts.Dispose();
            }
        }

        private static async Task ConnectToMasterRouterAsync(IPAddress address, int port)
        {
            var client = new TcpClient();
            await client.ConnectAsync(address, port);

            var routingClient = new AERoutingClient(client, DatabaseServices.InteropPacketHandler,
                DatabaseServices.IncomingRoutingMiddlewareHandler,
                DatabaseServices.OutgoingRoutingMiddlewareHandler,
                DatabaseServices.ObjectRepository);

            var chbp = new ClientHandshakeBeginPacket
            {
                Protocol = Constants.LatestAEProtocolVersion,
                Password = "aesharp",
                Component = new RoutingComponent
                {
                    Type = ComponentType.DatabaseComponent
                }
            };

            await routingClient.SendDataAsync(chbp.FinalizePacket());
            await routingClient.ListenForDataTask();

            DatabaseServices.ObjectRepository.RemoveObject(routingClient.ClientGuid);
        }
    }
}