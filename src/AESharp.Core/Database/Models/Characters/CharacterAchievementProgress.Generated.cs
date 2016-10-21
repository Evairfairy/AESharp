// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class CharacterAchievementProgress
    {
            [Column( "guid" )]
            public uint Guid { get; set; }

            [Column( "criteria" )]
            public uint Criteria { get; set; }

            [Column( "counter" )]
            public int Counter { get; set; }

            [Column( "date" )]
            public uint Date { get; set; }

    }
}