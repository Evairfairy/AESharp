using System;
using AESharp.Database.Configuration;
using AESharp.Database.Entities.MySql.Models.Logon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.MySqlClient;

namespace AESharp.Database.Entities.MySql
{
    internal sealed class LogonDatabase : DbContext
    {
        private readonly MigrationSettings Settings;

        public DbSet<Accounts> Accounts { get; set; }
        public DbSet<IpBans> IPBans { get; set; }

        public LogonDatabase( MigrationSettings settings )
        {
            if( settings == null )
                throw new ArgumentNullException( nameof( settings ) );

            this.Settings = settings;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            var builder = new MySqlConnectionStringBuilder
            {
                Server = this.Settings.Server,
                Database = this.Settings.MySqlDatabase,
                Port = this.Settings.Port.Value,
                UserID = this.Settings.Username,
                Password = this.Settings.MySqlPassword,
                ConvertZeroDateTime = true,
            };

            optionsBuilder.UseMySql(builder.ToString());
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            EntityTypeBuilder<Accounts> accounts = modelBuilder.Entity<Accounts>();

            accounts.HasIndex( a => a.Login ).IsUnique();

            // TODO: for some reason the [Column] attribute isnt working, so we're doing it here instead
            accounts.Property( a => a.AccountId ).HasColumnName( "id" );
            accounts.Property( a => a.Login ).HasColumnName( "acc_name" );
            accounts.Property( a => a.Password ).HasColumnName( "encrypted_password" );
            accounts.Property( a => a.Banned ).HasColumnName( "banned" );
            accounts.Property( a => a.LastLogin ).HasColumnName( "lastlogin" );
            accounts.Property( a => a.LastIPAddress ).HasColumnName( "lastip" );
            accounts.Property( a => a.Email ).HasColumnName( "email" );
            accounts.Property( a => a.Flags ).HasColumnName( "flags" );
            accounts.Property( a => a.Language ).HasColumnName( "forceLanguage" );
            accounts.Property( a => a.Muted ).HasColumnName( "muted" );
            accounts.Property( a => a.BanReason ).HasColumnName( "banreason" );
            accounts.Property( a => a.JoinDate ).HasColumnName( "joindate" );

            EntityTypeBuilder<IpBans> ipBans = modelBuilder.Entity<IpBans>();

            ipBans.HasIndex( i => i.IPAddress ).IsUnique();

            // TODO: [Column]
            ipBans.Property( i => i.IPAddress ).HasColumnName( "ip" );
            ipBans.Property( i => i.Expires ).HasColumnName( "expire" );
            ipBans.Property( i => i.BanReason ).HasColumnName( "banreason" );
        }
    }
}
