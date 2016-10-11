// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class GuildBankitems
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