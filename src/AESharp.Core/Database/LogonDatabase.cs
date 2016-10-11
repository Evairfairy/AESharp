using System;
using AESharp.Core.Configuration;
using AESharp.Core.Database.Models.Logon;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace AESharp.Core.Database
{
    public sealed class LogonDatabase : DbContext
    {
        private readonly DatabaseSettings Settings;

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<IpBans> IPBans { get; set; }

        public LogonDatabase( DatabaseSettings settings )
        {
            if( settings == null )
                throw new ArgumentNullException( nameof( settings ) );

            this.Settings = settings;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            switch( this.Settings.Driver )
            {
                case DatabaseDriver.MySql:
                {
                    var builder = new MySqlConnectionStringBuilder
                    {
                        Server = this.Settings.Hostname,
                        Database = this.Settings.Database,
                        Port = this.Settings.Port,
                        UserID = this.Settings.Username,
                        Password = this.Settings.Password
                    };

                    optionsBuilder.UseMySQL( builder.ToString() );
                    break;
                }

                default:
                    throw new NotImplementedException( this.Settings.Driver.ToString() );
            }
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            var accounts = modelBuilder.Entity<Accounts>();

            accounts.HasIndex( a => a.Login ).IsUnique();

            // TODO: for some reason the [Column] attribute isnt working, so we're doing it here instead
            accounts.Property( a => a.AccountId ).HasColumnName( "acct" );
            accounts.Property( a => a.Login ).HasColumnName( "login" );
            accounts.Property( a => a.Password ).HasColumnName( "encrypted_password" );
            accounts.Property( a => a.Permissions ).HasColumnName( "gm" );
            accounts.Property( a => a.Banned ).HasColumnName( "banned" );
            accounts.Property( a => a.LastLogin ).HasColumnName( "lastlogin" );
            accounts.Property( a => a.LastIPAddress ).HasColumnName( "lastip" );
            accounts.Property( a => a.Email ).HasColumnName( "email" );
            accounts.Property( a => a.Flags ).HasColumnName( "flags" );
            accounts.Property( a => a.Language ).HasColumnName( "forceLanguage" );
            accounts.Property( a => a.Muted ).HasColumnName( "muted" );
            accounts.Property( a => a.BanReason ).HasColumnName( "banreason" );
            accounts.Property( a => a.JoinDate ).HasColumnName( "joindate" );

            var ipBans = modelBuilder.Entity<IpBans>();

            ipBans.HasIndex( i => i.IPAddress ).IsUnique();

            // TODO: [Column]
            ipBans.Property( i => i.IPAddress ).HasColumnName( "ip" );
            ipBans.Property( i => i.Expires ).HasColumnName( "expire" );
            ipBans.Property( i => i.BanReason ).HasColumnName( "banreason" );
        }
    }
}
