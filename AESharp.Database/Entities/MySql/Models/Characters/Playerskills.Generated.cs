// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class PlayerSkills
    {
            [Column( "GUID" )]
            public uint Guid { get; set; }

            [Column( "SkillID" )]
            public uint Skillid { get; set; }

            [Column( "CurrentValue" )]
            public uint Currentvalue { get; set; }

            [Column( "MaximumValue" )]
            public uint Maximumvalue { get; set; }

    }
}