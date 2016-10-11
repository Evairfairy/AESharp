// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class GuildBankTabs
    {
            [Column( "guildId" )]
            public int Guildid { get; set; }

            [Column( "tabId" )]
            public int Tabid { get; set; }

            [Column( "tabName" ), Required]
            public string Tabname { get; set; }

            [Column( "tabIcon" ), Required]
            public string Tabicon { get; set; }

            [Column( "tabInfo" ), Required]
            public string Tabinfo { get; set; }

    }
}