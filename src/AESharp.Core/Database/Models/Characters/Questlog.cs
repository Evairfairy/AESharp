// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class QuestLog
    {
            [Column( "player_guid" )]
            public ulong PlayerGuid { get; set; }

            [Column( "quest_id" )]
            public ulong QuestId { get; set; }

            [Column( "slot" )]
            public uint Slot { get; set; }

            [Column( "expirytime" )]
            public uint Expirytime { get; set; }

            [Column( "explored_area1" )]
            public ulong ExploredArea1 { get; set; }

            [Column( "explored_area2" )]
            public ulong ExploredArea2 { get; set; }

            [Column( "explored_area3" )]
            public ulong ExploredArea3 { get; set; }

            [Column( "explored_area4" )]
            public ulong ExploredArea4 { get; set; }

            [Column( "mob_kill1" )]
            public long MobKill1 { get; set; }

            [Column( "mob_kill2" )]
            public long MobKill2 { get; set; }

            [Column( "mob_kill3" )]
            public long MobKill3 { get; set; }

            [Column( "mob_kill4" )]
            public long MobKill4 { get; set; }

            [Column( "completed" )]
            public uint Completed { get; set; }

    }
}