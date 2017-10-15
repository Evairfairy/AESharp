// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class CreatureFormations
    {
            [Key, Column( "spawn_id" )]
            public uint SpawnId { get; set; }

            [Column( "target_spawn_id" )]
            public uint TargetSpawnId { get; set; }

            [Column( "follow_angle" )]
            public float FollowAngle { get; set; }

            [Column( "follow_dist" )]
            public float FollowDist { get; set; }

    }
}