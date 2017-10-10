// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class EventCreatureSpawns
    {
            [Column( "event_entry" )]
            public uint EventEntry { get; set; }

            [Column( "id" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public uint Id { get; set; }

            [Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "map" )]
            public ushort Map { get; set; }

            [Column( "position_x" )]
            public float PositionX { get; set; }

            [Column( "position_y" )]
            public float PositionY { get; set; }

            [Column( "position_z" )]
            public float PositionZ { get; set; }

            [Column( "orientation" )]
            public float Orientation { get; set; }

            [Column( "movetype" )]
            public byte Movetype { get; set; }

            [Column( "displayid" )]
            public uint Displayid { get; set; }

            [Column( "faction" )]
            public uint Faction { get; set; }

            [Column( "flags" )]
            public uint Flags { get; set; }

            [Column( "bytes0" )]
            public uint Bytes0 { get; set; }

            [Column( "bytes1" )]
            public uint Bytes1 { get; set; }

            [Column( "bytes2" )]
            public uint Bytes2 { get; set; }

            [Column( "emote_state" )]
            public ushort EmoteState { get; set; }

            [Column( "npc_respawn_link" )]
            public uint NpcRespawnLink { get; set; }

            [Column( "channel_spell" )]
            public uint ChannelSpell { get; set; }

            [Column( "channel_target_sqlid" )]
            public uint ChannelTargetSqlid { get; set; }

            [Column( "channel_target_sqlid_creature" )]
            public uint ChannelTargetSqlidCreature { get; set; }

            [Column( "standstate" )]
            public byte Standstate { get; set; }

            [Column( "death_state" )]
            public byte DeathState { get; set; }

            [Column( "mountdisplayid" )]
            public uint Mountdisplayid { get; set; }

            [Column( "slot1item" )]
            public uint Slot1item { get; set; }

            [Column( "slot2item" )]
            public uint Slot2item { get; set; }

            [Column( "slot3item" )]
            public uint Slot3item { get; set; }

            [Column( "CanFly" )]
            public ushort Canfly { get; set; }

            // Phase mask
            [Column( "phase" )]
            public uint Phase { get; set; }

            // waypoint group in table creature_waypoints_manual
            [Column( "waypoint_group" )]
            public uint WaypointGroup { get; set; }

    }
}