// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class LfgData
    {
            [Key, Column( "guid" )]
            public long Guid { get; set; }

            [Column( "dungeon" )]
            public int Dungeon { get; set; }

            [Column( "state" )]
            public int State { get; set; }

    }
}