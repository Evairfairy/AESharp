using System;
using LiteDB;

namespace AESharp.Database.Entities.LiteDb.Models
{
    internal sealed class Migration
    {
        [BsonId( false )]
        public long Id { get; set; }
        public string Description { get; set; }
        public DateTime UpgradedAt { get; set; }
    }
}
