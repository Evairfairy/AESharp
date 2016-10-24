// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class LagReports
    {
            [Key, Column( "lag_id" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public uint LagId { get; set; }

            [Column( "player" )]
            public uint Player { get; set; }

            [Column( "account" )]
            public uint Account { get; set; }

            [Column( "lag_type" )]
            public ushort LagType { get; set; }

            [Column( "map_id" )]
            public uint MapId { get; set; }

            [Column( "position_x" )]
            public float PositionX { get; set; }

            [Column( "position_y" )]
            public float PositionY { get; set; }

            [Column( "position_z" )]
            public float PositionZ { get; set; }

            [Column( "timestamp" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public DateTime Timestamp { get; set; }

    }
}