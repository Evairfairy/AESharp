using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Logon
{
    public sealed class IpBans
    {
        [Key, Column( "ip" ), MaxLength( 20 )]
        public string IPAddress { get; set; }

        [Column( "expire" )]
        public long Expires { get; set; }

        [NotMapped]
        public DateTime ExpiresAt
        {
            get { return DateTimeOffset.FromUnixTimeSeconds( this.Expires ).UtcDateTime; }
            set { this.Expires = new DateTimeOffset( value ).ToUniversalTime().ToUnixTimeSeconds(); }
        }

        [Column( "banreason" ), MaxLength( 255 )]
        public string BanReason { get; set; }
    }
}
