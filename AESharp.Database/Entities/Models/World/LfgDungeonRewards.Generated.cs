// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class LfgDungeonRewards
    {
            // Dungeon entry from dbc
            [Column( "dungeon_id" )]
            public uint DungeonId { get; set; }

            // Max level at which this reward is rewarded
            [Column( "max_level" )]
            public byte MaxLevel { get; set; }

            // Quest id with rewards for first dungeon this day
            [Column( "quest_id_1" )]
            public uint QuestId1 { get; set; }

            // Money multiplier for completing the dungeon first time in a day with less players than max
            [Column( "money_var_1" )]
            public uint MoneyVar1 { get; set; }

            // Experience multiplier for completing the dungeon first time in a day with less players than max
            [Column( "xp_var_1" )]
            public uint XpVar1 { get; set; }

            // Quest id with rewards for Nth dungeon this day
            [Column( "quest_id_2" )]
            public uint QuestId2 { get; set; }

            // Money multiplier for completing the dungeon Nth time in a day with less players than max
            [Column( "money_var_2" )]
            public uint MoneyVar2 { get; set; }

            // Experience multiplier for completing the dungeon Nth time in a day with less players than max
            [Column( "xp_var_2" )]
            public uint XpVar2 { get; set; }

    }
}