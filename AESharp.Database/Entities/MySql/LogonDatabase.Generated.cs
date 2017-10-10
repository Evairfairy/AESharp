using System;
using System.Linq;
using System.Net;
using AESharp.Database.Configuration;
using AESharp.Database.Entities.Models.Logon;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.MySqlClient;
using AESharp.Database.Entities.Models.Accounts;

namespace AESharp.Database.Entities
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

        public void CreateMapping( IMapperConfigurationExpression config )
        {
            config.CreateMap<Accounts, Account>()
                  .ForMember( dest => dest.Username, obj => obj.MapFrom( src => src.Login ) )
                  .ForMember(
                      dest => dest.ExpansionLevel,
                      obj => obj.ResolveUsing<ExpansionLevel>(
                          src =>
                          {
                              switch( src.Flags )
                              {
                                  case AccountFlags.Classic: return ExpansionLevel.Classic;
                                  case AccountFlags.TheBurningCrusade: return ExpansionLevel.TheBurningCrusade;
                                  case AccountFlags.WrathOfTheLichKing:
                                  case AccountFlags.WrathAndBurningCrusade: return ExpansionLevel.WrathOfTheLichKing;
                                  default: throw new NotImplementedException();
                              }
                          } )
                  )
                  .ForMember( dest => dest.Persmissions, obj => obj.Ignore() )
                  .ForMember( dest => dest.ForceLanguage, obj => obj.MapFrom( src => src.Language ) )
                  .ForMember( dest => dest.CreatedAt, obj => obj.MapFrom( src => src.JoinDate ) )
                  .ForMember( dest => dest.BannedUntil, obj => obj.MapFrom( src => src.BanTime ) )
                  .ForMember( dest => dest.MutedUntil, obj => obj.MapFrom( src => src.MutedTime ) )
                  .ForMember(
                      dest => dest.LastKnownIp,
                      obj => obj.ResolveUsing( src => IPAddress.Parse( src.LastIPAddress ) )
                  );

            config.CreateMap<IpBans, IpBan>()
                  .ForMember( dest => dest.Ip, obj => obj.ResolveUsing( src => IPAddress.Parse( src.IPAddress ) ) )
                  .ForMember( dest => dest.BannedUntil, obj => obj.MapFrom( src => src.ExpiresAt ) )
                  .ForMember( dest => dest.Reason, obj => obj.MapFrom( src => src.BanReason ) );
        }

        public void MigrateTo( AccountsDatabase db )
        {
            var c = 0;
            var numAccounts = this.Accounts.Count();
            foreach( var account in this.Accounts )
            {
                //break;
                WriteProgress( "accounts", ++c, numAccounts );
                var mapped = Mapper.Map<Account>( account );
                db.Accounts.Insert( mapped );
            }

            Console.WriteLine();

            c = 0;
            var numBans = this.IPBans.Count();
            foreach( var ban in this.IPBans )
            {
                WriteProgress( "IP bans", ++c, numBans );
                var mapped = Mapper.Map<IpBan>( ban );
                db.IpBans.Insert( mapped );
            }

            void WriteProgress( string what, int current, int total )
            {
                Console.Write(
                    "\r  - Migrating {0} {1:0}% ({2}/{3})",
                    what,
                    ( (double)current / (double)total ) * 100d,
                    current,
                    total
                );
            }
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
