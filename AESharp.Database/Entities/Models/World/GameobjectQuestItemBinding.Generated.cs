// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class GameobjectQuestItemBinding
    {
            [Column( "entry" )]
            public int Entry { get; set; }

            [Column( "quest" )]
            public int Quest { get; set; }

            [Column( "item" )]
            public int Item { get; set; }

            [Column( "item_count" )]
            public int ItemCount { get; set; }

    }
}