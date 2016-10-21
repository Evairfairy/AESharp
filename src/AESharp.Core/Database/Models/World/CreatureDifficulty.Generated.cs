// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class CreatureDifficulty
    {
            [Key, Column( "entry" )]
            public uint Entry { get; set; }

            // Dungeon heroic / Raid 25 man
            [Column( "difficulty_1" )]
            public uint Difficulty1 { get; set; }

            // Raid heroic 10 man
            [Column( "difficulty_2" )]
            public uint Difficulty2 { get; set; }

            // Raid heroic 25 man
            [Column( "difficulty_3" )]
            public uint Difficulty3 { get; set; }

    }
}