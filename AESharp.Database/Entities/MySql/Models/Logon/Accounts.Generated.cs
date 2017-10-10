using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Logon
{
    public sealed class Accounts
    {
        [Key, Column( "id" )]
        [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
        public uint AccountId { get; set; }

        [MaxLength( 32 ), Column( "acc_name" )]
        public string Login { get; set; }

        [MaxLength( 42 ), Column( "encrypted_password" )]
        public string Password { get; set; }

        [Column( "banned" )]
        public long Banned { get; set; }

        [NotMapped]
        public DateTime? BanTime
                => this.Banned == 0
                 ? null
                 : (DateTime?)DateTimeOffset.FromUnixTimeSeconds( this.Banned ).UtcDateTime;

        [Timestamp, Column( "lastlogin" )]
        public DateTime LastLogin { get; set; }

        [MaxLength( 16 ), Column( "lastip" )]
        public string LastIPAddress { get; set; }

        [MaxLength( 64 ), Column( "email" )]
        public string Email { get; set; }

        [Column( "flags" )]
        public AccountFlags Flags { get; set; }

        [MaxLength( 5 ), Column( "forceLanguage" )]
        public string Language { get; set; }

        [Column( "muted" )]
        public long Muted { get; set; }

        [NotMapped]
        public DateTime? MutedTime
                => this.Muted == 0
                 ? null
                 : (DateTime?)DateTimeOffset.FromUnixTimeSeconds( this.Muted ).UtcDateTime;

        [MaxLength( 255 ), Column( "banreason" )]
        public string BanReason { get; set; }

        [Timestamp, DatabaseGenerated( DatabaseGeneratedOption.Identity ), Column( "joindate" )]
        public DateTime JoinDate { get; set; }
    }
}
