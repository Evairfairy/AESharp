// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class Guilds
    {
            [Key, Column( "guildId" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public long Guildid { get; set; }

            [Column( "guildName" ), Required]
            public string Guildname { get; set; }

            [Column( "leaderGuid" )]
            public long Leaderguid { get; set; }

            [Column( "emblemStyle" )]
            public int Emblemstyle { get; set; }

            [Column( "emblemColor" )]
            public int Emblemcolor { get; set; }

            [Column( "borderStyle" )]
            public int Borderstyle { get; set; }

            [Column( "borderColor" )]
            public int Bordercolor { get; set; }

            [Column( "backgroundColor" )]
            public int Backgroundcolor { get; set; }

            [Column( "guildInfo" ), Required]
            public string Guildinfo { get; set; }

            [Column( "motd" ), Required]
            public string Motd { get; set; }

            [Column( "createdate" )]
            public int Createdate { get; set; }

            [Column( "bankBalance" )]
            public ulong Bankbalance { get; set; }

    }
}