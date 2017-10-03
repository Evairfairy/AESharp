using System;
using System.Net;
using System.Reflection;
using AESharp.Database.Configuration;
using AESharp.Database.Entities.Models.Accounts;
using AESharp.Database.Migrations;
using LiteDB;

namespace AESharp.Database.Entities
{
    internal sealed class AccountsDatabase : IDisposable, IDatabase
    {
        private readonly IDiskService _diskService;

        public LiteDatabase Database { get; }

        public LiteCollection<Accounts> Accounts
            => this.Database.GetCollection<Accounts>("accounts");

        public AccountsDatabase( DatabaseSettings config )
        {
            var mapper = new BsonMapper( Activator.CreateInstance ) { SerializeNullValues = true };
            mapper.UseCamelCase();

            // IPAddress
            mapper.RegisterType(
                serialize: ip => ip.ToString(),
                deserialize: bson => IPAddress.Parse( bson.AsString )
            );

            this._diskService = new FileDiskService( config.FileName );
            this.Database = new LiteDatabase( this._diskService, mapper, config.Password );

            // setup
            this.Accounts.EnsureIndex( _ => _.Username, unique: true );

            // automatically run migrations
            Migrator<AccountsDatabase>.GetMigrationsFrom( Assembly.GetExecutingAssembly(), this )
                                      .UpgradeAll();
        }

        /// <inheritdoc />
        public void Dispose() => this.Database.Dispose();

        public void Flush() => this._diskService.Flush();
    }
}
