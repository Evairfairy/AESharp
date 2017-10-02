// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class LootItems
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
            public uint Mincount { get; set; }

            [Column( "maxcount" )]
            public uint Maxcount { get; set; }

    }
}