// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class GuildBankItems
    {
            [Column( "guildId" )]
            public int Guildid { get; set; }

            [Column( "tabId" )]
            public int Tabid { get; set; }

            [Column( "slotId" )]
            public int Slotid { get; set; }

            [Column( "itemGuid" )]
            public int Itemguid { get; set; }

    }
}