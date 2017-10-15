// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class AiThreatToSpellId
    {
            [Key, Column( "spell" )]
            public uint Spell { get; set; }

            [Column( "mod" )]
            public int Mod { get; set; }

            [Column( "modcoef" )]
            public float Modcoef { get; set; }

    }
}