// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class AiThreattospellid
    {
            [Key, Column( "spell" )]
            public uint Spell { get; set; }

            [Column( "mod" )]
            public int Mod { get; set; }

            [Column( "modcoef" )]
            public float Modcoef { get; set; }

    }
}