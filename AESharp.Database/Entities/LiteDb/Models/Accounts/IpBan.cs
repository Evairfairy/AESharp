using System;
using System.Net;
using LiteDB;

namespace AESharp.Database.Entities.LiteDb.Models.Accounts
{
    internal sealed class IpBan
    {
        [BsonId( false )]
        public IPAddress Ip { get; set; }

        public DateTime BannedUntil { get; set; }

        [BsonIgnore]
        public TimeSpan BanDuration => this.BannedUntil - DateTime.UtcNow;

        public string Reason { get; set; }
    }
}
