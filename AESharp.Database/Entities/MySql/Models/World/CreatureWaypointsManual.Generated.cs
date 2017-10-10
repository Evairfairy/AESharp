// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class CreatureWaypointsManual
    {
            [Column( "group_id" )]
            public uint GroupId { get; set; }

            [Column( "waypoint_id" )]
            public uint WaypointId { get; set; }

            [Column( "position_x" )]
            public float PositionX { get; set; }

            [Column( "position_y" )]
            public float PositionY { get; set; }

            [Column( "position_z" )]
            public float PositionZ { get; set; }

            [Column( "wait_time" )]
            public uint WaitTime { get; set; }

            [Column( "flags" )]
            public uint Flags { get; set; }

            [Column( "forward_emote_oneshot" )]
            public byte ForwardEmoteOneshot { get; set; }

            [Column( "forward_emote_id" )]
            public uint ForwardEmoteId { get; set; }

            [Column( "backward_emote_oneshot" )]
            public byte BackwardEmoteOneshot { get; set; }

            [Column( "backward_emote_id" )]
            public uint BackwardEmoteId { get; set; }

            [Column( "forward_skin_id" )]
            public uint ForwardSkinId { get; set; }

            [Column( "backward_skin_id" )]
            public uint BackwardSkinId { get; set; }

    }
}