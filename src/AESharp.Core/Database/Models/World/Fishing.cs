// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class Fishing
    {
            [Key, Column( "zone" )]
            public ushort Zone { get; set; }

            [Column( "MinSkill" )]
            public ushort Minskill { get; set; }

            [Column( "MaxSkill" )]
            public ushort Maxskill { get; set; }

    }
}