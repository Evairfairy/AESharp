// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class GameobjectSpawns
    {
            // Unique Spawn Identifier
            [Column( "id" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public uint Id { get; set; }

            // Gameobject Identifier
            [Column( "entry" )]
            public uint Entry { get; set; }

            // Map Identifier
            [Column( "map" )]
            public uint Map { get; set; }

            [Column( "position_x" )]
            public float PositionX { get; set; }

            [Column( "position_y" )]
            public float PositionY { get; set; }

            [Column( "position_z" )]
            public float PositionZ { get; set; }

            [Column( "facing" )]
            public float Facing { get; set; }

            [Column( "orientation1" )]
            public float Orientation1 { get; set; }

            [Column( "orientation2" )]
            public float Orientation2 { get; set; }

            [Column( "orientation3" )]
            public float Orientation3 { get; set; }

            [Column( "orientation4" )]
            public float Orientation4 { get; set; }

            [Column( "state" )]
            public uint State { get; set; }

            [Column( "flags" )]
            public uint Flags { get; set; }

            [Column( "faction" )]
            public uint Faction { get; set; }

            [Column( "scale" )]
            public float Scale { get; set; }

            [Column( "respawnNpcLink" )]
            public uint Respawnnpclink { get; set; }

            // Phase mask
            [Column( "phase" )]
            public uint Phase { get; set; }

            [Column( "overrides" )]
            public uint Overrides { get; set; }

    }
}