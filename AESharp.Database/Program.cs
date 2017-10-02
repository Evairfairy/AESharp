using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using AESharp.Core.Configuration;
using AESharp.Core.Extensions;
using AESharp.Database.Configuration;
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
            JsonConfigLoader loader = new JsonConfigLoader();
            DatabaseSettings config = new DatabaseSettings
            {
                Driver = DatabaseDriver.MySql,
                Hostname = IPAddress.Loopback.ToString(),
                Port = 3306,
                Username = "ascemu",
                Password = string.Empty,
                Databases = new DatabasesSection
                {
                    LogonDatabase = "logon",
                    CharactersDatabase = "chars",
                    WorldDatabase = "world"
                }
            };

            try
            {
                config = loader.Load<DatabaseSettings>("database");
                ConnectToMasterRouterAsync(IPAddress.Loopback, 12000).RunAsync();
                Console.ReadLine();
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.Error.WriteLine("Config directory not found, attempting to create default file...");
                Directory.CreateDirectory(loader.RootDirectory);
                loader.CreateDefault("database", config);
            }
            catch (FileNotFoundException ex)
            {
                Console.Error.WriteLine("Config file not found, attempting to create default file...");
                loader.CreateDefault("database", config);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private static async Task ConnectToMasterRouterAsync(IPAddress address, int port)
        {
            TcpClient client = new TcpClient();
            await client.ConnectAsync(address, port);

            AERoutingClient routingClient = new AERoutingClient(client, DatabaseServices.InteropPacketHandler,
                DatabaseServices.IncomingRoutingMiddlewareHandler,
                DatabaseServices.OutgoingRoutingMiddlewareHandler,
                DatabaseServices.ObjectRepository);

            ClientHandshakeBeginPacket chbp = new ClientHandshakeBeginPacket
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