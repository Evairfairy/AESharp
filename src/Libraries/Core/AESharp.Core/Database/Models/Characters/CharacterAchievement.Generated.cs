// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class CharacterAchievement
    {
            [Column( "guid" )]
            public uint Guid { get; set; }

            [Column( "achievement" )]
            public uint Achievement { get; set; }

            [Column( "date" )]
            public uint Date { get; set; }

    }
}