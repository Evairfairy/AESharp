// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class GuildRanks
    {
            [Column( "guildId" )]
            public uint Guildid { get; set; }

            [Column( "rankId" )]
            public int Rankid { get; set; }

            [Column( "rankName" ), Required]
            public string Rankname { get; set; }

            [Column( "rankRights" )]
            public uint Rankrights { get; set; }

            [Column( "goldLimitPerDay" )]
            public int Goldlimitperday { get; set; }

            [Column( "bankTabFlags0" )]
            public int Banktabflags0 { get; set; }

            [Column( "itemStacksPerDay0" )]
            public int Itemstacksperday0 { get; set; }

            [Column( "bankTabFlags1" )]
            public int Banktabflags1 { get; set; }

            [Column( "itemStacksPerDay1" )]
            public int Itemstacksperday1 { get; set; }

            [Column( "bankTabFlags2" )]
            public int Banktabflags2 { get; set; }

            [Column( "itemStacksPerDay2" )]
            public int Itemstacksperday2 { get; set; }

            [Column( "bankTabFlags3" )]
            public int Banktabflags3 { get; set; }

            [Column( "itemStacksPerDay3" )]
            public int Itemstacksperday3 { get; set; }

            [Column( "bankTabFlags4" )]
            public int Banktabflags4 { get; set; }

            [Column( "itemStacksPerDay4" )]
            public int Itemstacksperday4 { get; set; }

            [Column( "bankTabFlags5" )]
            public int Banktabflags5 { get; set; }

            [Column( "itemStacksPerDay5" )]
            public int Itemstacksperday5 { get; set; }

    }
}