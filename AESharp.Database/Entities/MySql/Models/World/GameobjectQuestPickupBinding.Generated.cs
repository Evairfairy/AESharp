// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class GameobjectQuestPickupBinding
    {
            [Column( "entry" )]
            public int Entry { get; set; }

            [Column( "quest" )]
            public int Quest { get; set; }

            [Column( "required_count" )]
            public int RequiredCount { get; set; }

    }
}