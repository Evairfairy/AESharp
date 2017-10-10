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
using LiteDB;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using FileMode = System.IO.FileMode;

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
                if( logon != null ) Migrate<LogonDatabase, AccountsDatabase>( logon );
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

            void Migrate<TSource, TDestination>( MigrationSettings settings )
                where TDestination : Entities.Database
                where TSource : DbContext, IDatabaseMapper<TDestination>
            {
                Console.WriteLine( "Migrating {0} database to {1}", settings.MySqlDatabase, settings.LiteDatabase );

                using( var memory = new MemoryStream() )
                using( var service = new StreamDiskService( memory ) )
                using( var accounts = (TDestination)Activator.CreateInstance( typeof( TDestination ), service, settings.LitePassword, null as BsonMapper ) )
                using( var mysql = (TSource)Activator.CreateInstance( typeof( TSource ), settings ) )
                {
                    Mapper.Initialize( mysql.CreateMapping );
                    mysql.MigrateTo( accounts );

                    Console.WriteLine( "  - Flushing {0} to disk...", settings.LiteDatabase );

                    service.Flush();
                    memory.Flush();

                    var file = File.Open( settings.LiteDatabase, FileMode.Create, FileAccess.Write, FileShare.None );
                    using( file )
                    {
                        memory.Position = 0;
                        memory.CopyTo( file );
                        file.Flush();
                        accounts.Flush();
                    }
                }
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