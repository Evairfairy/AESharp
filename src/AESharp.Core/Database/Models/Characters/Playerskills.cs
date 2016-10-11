// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class Playerskills
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