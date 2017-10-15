// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class CreatureWaypoints
    {
            [Column( "spawnid" )]
            public uint Spawnid { get; set; }

            [Column( "waypointid" )]
            public uint Waypointid { get; set; }

            [Column( "position_x" )]
            public float PositionX { get; set; }

            [Column( "position_y" )]
            public float PositionY { get; set; }

            [Column( "position_z" )]
            public float PositionZ { get; set; }

            [Column( "waittime" )]
            public uint Waittime { get; set; }

            [Column( "flags" )]
            public uint Flags { get; set; }

            [Column( "forwardemoteoneshot" )]
            public byte Forwardemoteoneshot { get; set; }

            [Column( "forwardemoteid" )]
            public uint Forwardemoteid { get; set; }

            [Column( "backwardemoteoneshot" )]
            public byte Backwardemoteoneshot { get; set; }

            [Column( "backwardemoteid" )]
            public uint Backwardemoteid { get; set; }

            [Column( "forwardskinid" )]
            public uint Forwardskinid { get; set; }

            [Column( "backwardskinid" )]
            public uint Backwardskinid { get; set; }

    }
}