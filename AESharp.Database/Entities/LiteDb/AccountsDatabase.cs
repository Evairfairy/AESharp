using System.Net;
using System.Reflection;
using AESharp.Database.Configuration;
using AESharp.Database.Entities.LiteDb.Models.Accounts;
using AESharp.Database.Migrations;
using LiteDB;

namespace AESharp.Database.Entities.LiteDb
{
    internal sealed class AccountsDatabase : Database
    {
        public LiteCollection<Account> Accounts
            => this.LiteDatabase.GetCollection<Account>("accounts");

        public LiteCollection<IpBan> IpBans
            => this.LiteDatabase.GetCollection<IpBan>("ip_bans");

        public AccountsDatabase( MigrationSettings config )
            : this( new DatabaseSettings { FileName = config.LiteDatabase, Password = config.LitePassword } ) { }

        public AccountsDatabase( DatabaseSettings config )
            : base( config ) { }

        public AccountsDatabase( IDiskService service, string password = null, BsonMapper mapper = null )
            : base( service, password, mapper ) { }

        /// <inheritdoc />
        protected override void Initialize()
        {
            // IPAddress
            this.Mapper.RegisterType(
                serialize: ip => ip.ToString(),
                deserialize: bson => IPAddress.Parse(bson.AsString)
            );

            // setup
            this.Accounts.EnsureIndex(x => x.Username, unique: true);
            this.IpBans.EnsureIndex(x => x.Ip, unique: true);

            // automatically run migrations
            Migrator<AccountsDatabase>.GetMigrationsFrom(Assembly.GetExecutingAssembly(), this)
                                      .UpgradeAll();
        }
    }
}
