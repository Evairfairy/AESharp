// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class AreaTriggers
    {
            [Key, Column( "entry" )]
            public ushort Entry { get; set; }

            [Column( "type" )]
            public byte Type { get; set; }

            [Column( "map" )]
            public ushort Map { get; set; }

            [Column( "screen" )]
            public ushort Screen { get; set; }

            [Column( "name" )]
            public string Name { get; set; }

            [Column( "position_x" )]
            public float PositionX { get; set; }

            [Column( "position_y" )]
            public float PositionY { get; set; }

            [Column( "position_z" )]
            public float PositionZ { get; set; }

            [Column( "orientation" )]
            public float Orientation { get; set; }

            [Column( "required_honor_rank" )]
            public byte RequiredHonorRank { get; set; }

            [Column( "required_level" )]
            public byte RequiredLevel { get; set; }

    }
}