// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class LootFishing
    {
            [Column( "entryid" )]
            public uint Entryid { get; set; }

            [Column( "itemid" )]
            public uint Itemid { get; set; }

            [Column( "normal10percentchance" )]
            public float Normal10percentchance { get; set; }

            [Column( "normal25percentchance" )]
            public float Normal25percentchance { get; set; }

            [Column( "heroic10percentchance" )]
            public float Heroic10percentchance { get; set; }

            [Column( "heroic25percentchance" )]
            public float Heroic25percentchance { get; set; }

            [Column( "mincount" )]
            public byte Mincount { get; set; }

            [Column( "maxcount" )]
            public byte Maxcount { get; set; }

    }
}