// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
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