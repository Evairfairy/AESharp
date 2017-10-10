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
using AutoMapper;
using CommandLine;
using MySql.Data.MySqlClient;

namespace AESharp.Database
{
    internal static class Program
    {
        private static ConfigLoader ConfigLoader { get; }

        static Program()
        {
            Program.ConfigLoader = new JsonConfigLoader();

            // This must be second (after decryption)
            DatabaseServices.IncomingRoutingMiddlewareHandler.RegisterMiddleware(new AEPacketReaderMiddleware());

            // This must be second-to-last (before encryption)
            DatabaseServices.OutgoingRoutingMiddlewareHandler.RegisterMiddleware(new AEPacketBuilderMiddleware());
        }

        private static void Main( string[] args )
            => Parser.Default
                     .ParseArguments<MigrateOptions>( args )
                     .WithParsed( Program.MigrateMain );

        private static void MigrateMain( MigrateOptions opt )
        {
            try
            {
                var (logon, chars, world) = Program.ConfigLoader.Load<MigrationConfig>( "migrate" ).MergeAll();

                // TODO: only logon db migration implemented right now
                if( logon != null )
                {
                    if( File.Exists( logon.LiteDatabase ) )
                        File.Delete( logon.LiteDatabase );

                    Console.WriteLine( "Migrating {0} database to {1}", logon.MySqlDatabase, logon.LiteDatabase );

                    var mysql = new LogonDatabase( logon );
                    var accounts = new AccountsDatabase( logon );

                    Mapper.Initialize( mysql.CreateMapping );
                    mysql.MigrateTo( accounts );

                    accounts.Flush();
                }
            }
            catch( ArgumentException ex )
            {
                Console.Error.WriteLine( ex.Message );
                return;
            }
            catch (MySqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return;
            }
        }

        // TODO
        private static void DefaultMain()
        {
            var loader = new JsonConfigLoader();
            var config = new DatabasesConfig
            {
                Accounts = new DatabaseSettings
                {
                    FileName = "accounts.db",
                    Password = "change_me"
                },

                Characters = new DatabaseSettings
                {
                    FileName = "characters.db",
                    Password = null
                },

                World = new DatabaseSettings
                {
                    FileName = "world.db",
                    Password = null
                }
            };

            var accounts = new AccountsDatabase(config.Accounts);

            try
            {
                config = loader.Load<DatabasesConfig>("database");
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