// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class GuildData
    {
            [Column( "guildid" )]
            public int Guildid { get; set; }

            [Column( "playerid" )]
            public int Playerid { get; set; }

            [Column( "guildRank" )]
            public int Guildrank { get; set; }

            [Column( "publicNote" ), Required]
            public string Publicnote { get; set; }

            [Column( "officerNote" ), Required]
            public string Officernote { get; set; }

            [Column( "lastWithdrawReset" )]
            public int Lastwithdrawreset { get; set; }

            [Column( "withdrawlsSinceLastReset" )]
            public int Withdrawlssincelastreset { get; set; }

            [Column( "lastItemWithdrawReset0" )]
            public int Lastitemwithdrawreset0 { get; set; }

            [Column( "itemWithdrawlsSinceLastReset0" )]
            public int Itemwithdrawlssincelastreset0 { get; set; }

            [Column( "lastItemWithdrawReset1" )]
            public int Lastitemwithdrawreset1 { get; set; }

            [Column( "itemWithdrawlsSinceLastReset1" )]
            public int Itemwithdrawlssincelastreset1 { get; set; }

            [Column( "lastItemWithdrawReset2" )]
            public int Lastitemwithdrawreset2 { get; set; }

            [Column( "itemWithdrawlsSinceLastReset2" )]
            public int Itemwithdrawlssincelastreset2 { get; set; }

            [Column( "lastItemWithdrawReset3" )]
            public int Lastitemwithdrawreset3 { get; set; }

            [Column( "itemWithdrawlsSinceLastReset3" )]
            public int Itemwithdrawlssincelastreset3 { get; set; }

            [Column( "lastItemWithdrawReset4" )]
            public int Lastitemwithdrawreset4 { get; set; }

            [Column( "itemWithdrawlsSinceLastReset4" )]
            public int Itemwithdrawlssincelastreset4 { get; set; }

            [Column( "lastItemWithdrawReset5" )]
            public int Lastitemwithdrawreset5 { get; set; }

            [Column( "itemWithdrawlsSinceLastReset5" )]
            public int Itemwithdrawlssincelastreset5 { get; set; }

    }
}