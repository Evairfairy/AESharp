// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
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