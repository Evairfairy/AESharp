using System;
using System.Net;
using System.Reflection;
using AESharp.Database.Configuration;
using AESharp.Database.Entities.Models.Accounts;
using AESharp.Database.Migrations;
using LiteDB;

namespace AESharp.Database.Entities
{
    internal sealed class AccountsDatabase : IDisposable
    {
        public LiteDatabase Database { get; }

        public LiteCollection<Accounts> Accounts
            => this.Database.GetCollection<Accounts>("accounts");

        public AccountsDatabase( DatabaseSettings config )
        {
            var builder = new LiteDbConnectionStringBuilder
            {
                FileName = config.FileName,
                Password = config.Password
            };

            var mapper = new BsonMapper( Activator.CreateInstance ) { SerializeNullValues = true };
            mapper.UseCamelCase();

            // IPAddress
            mapper.RegisterType(
                serialize: ip => ip.ToString(),
                deserialize: bson => IPAddress.Parse( bson.AsString )
            );

            this.Database = new LiteDatabase( builder.ToString(), mapper );

            // setup
            this.Accounts.EnsureIndex( _ => _.Username, unique: true );

            // automatically run migrations
            var migrator = Migrator<AccountsDatabase>.GetMigrationsFrom(
                Assembly.GetExecutingAssembly(),
                this,
                this.Database
            );
            
            migrator.DowngradeAll();
        }

        /// <inheritdoc />
        public void Dispose() => this.Database.Dispose();
    }
}
