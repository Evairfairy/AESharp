using System;
using System.Net;
using LiteDB;

namespace AESharp.Database.Entities.LiteDb.Models.Accounts
{
    internal sealed class Account
    {
        [BsonId( false )]
        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ExpansionLevel ExpansionLevel { get; set; }

        // TODO: actually implement perms
        public uint Persmissions { get; set; }

        public string ForceLanguage { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? BannedUntil { get; set; }

        [BsonIgnore]
        public TimeSpan BanDuration
            => this.BannedUntil.HasValue ? this.BannedUntil.Value - DateTime.UtcNow : TimeSpan.Zero;

        public string BanReason { get; set; }

        public DateTime? MutedUntil { get; set; }

        [BsonIgnore]
        public TimeSpan MuteDuration
            => this.MutedUntil.HasValue ? this.MutedUntil.Value - DateTime.UtcNow : TimeSpan.Zero;

        public DateTime LastLogin { get; set; }

        public IPAddress LastKnownIp { get; set; }
    }
}
