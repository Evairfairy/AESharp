using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using LiteDB;

namespace AESharp.Database.Entities.Models.Accounts
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
