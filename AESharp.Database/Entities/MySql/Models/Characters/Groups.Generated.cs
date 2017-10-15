// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class Groups
    {
            [Key, Column( "group_id" )]
            public int GroupId { get; set; }

            [Column( "group_type" )]
            public sbyte GroupType { get; set; }

            [Column( "subgroup_count" )]
            public sbyte SubgroupCount { get; set; }

            [Column( "loot_method" )]
            public sbyte LootMethod { get; set; }

            [Column( "loot_threshold" )]
            public sbyte LootThreshold { get; set; }

            [Column( "difficulty" )]
            public int Difficulty { get; set; }

            [Column( "raiddifficulty" )]
            public int Raiddifficulty { get; set; }

            [Column( "assistant_leader" )]
            public int AssistantLeader { get; set; }

            [Column( "main_tank" )]
            public int MainTank { get; set; }

            [Column( "main_assist" )]
            public int MainAssist { get; set; }

            [Column( "group1member1" )]
            public int Group1member1 { get; set; }

            [Column( "group1member2" )]
            public int Group1member2 { get; set; }

            [Column( "group1member3" )]
            public int Group1member3 { get; set; }

            [Column( "group1member4" )]
            public int Group1member4 { get; set; }

            [Column( "group1member5" )]
            public int Group1member5 { get; set; }

            [Column( "group2member1" )]
            public int Group2member1 { get; set; }

            [Column( "group2member2" )]
            public int Group2member2 { get; set; }

            [Column( "group2member3" )]
            public int Group2member3 { get; set; }

            [Column( "group2member4" )]
            public int Group2member4 { get; set; }

            [Column( "group2member5" )]
            public int Group2member5 { get; set; }

            [Column( "group3member1" )]
            public int Group3member1 { get; set; }

            [Column( "group3member2" )]
            public int Group3member2 { get; set; }

            [Column( "group3member3" )]
            public int Group3member3 { get; set; }

            [Column( "group3member4" )]
            public int Group3member4 { get; set; }

            [Column( "group3member5" )]
            public int Group3member5 { get; set; }

            [Column( "group4member1" )]
            public int Group4member1 { get; set; }

            [Column( "group4member2" )]
            public int Group4member2 { get; set; }

            [Column( "group4member3" )]
            public int Group4member3 { get; set; }

            [Column( "group4member4" )]
            public int Group4member4 { get; set; }

            [Column( "group4member5" )]
            public int Group4member5 { get; set; }

            [Column( "group5member1" )]
            public int Group5member1 { get; set; }

            [Column( "group5member2" )]
            public int Group5member2 { get; set; }

            [Column( "group5member3" )]
            public int Group5member3 { get; set; }

            [Column( "group5member4" )]
            public int Group5member4 { get; set; }

            [Column( "group5member5" )]
            public int Group5member5 { get; set; }

            [Column( "group6member1" )]
            public int Group6member1 { get; set; }

            [Column( "group6member2" )]
            public int Group6member2 { get; set; }

            [Column( "group6member3" )]
            public int Group6member3 { get; set; }

            [Column( "group6member4" )]
            public int Group6member4 { get; set; }

            [Column( "group6member5" )]
            public int Group6member5 { get; set; }

            [Column( "group7member1" )]
            public int Group7member1 { get; set; }

            [Column( "group7member2" )]
            public int Group7member2 { get; set; }

            [Column( "group7member3" )]
            public int Group7member3 { get; set; }

            [Column( "group7member4" )]
            public int Group7member4 { get; set; }

            [Column( "group7member5" )]
            public int Group7member5 { get; set; }

            [Column( "group8member1" )]
            public int Group8member1 { get; set; }

            [Column( "group8member2" )]
            public int Group8member2 { get; set; }

            [Column( "group8member3" )]
            public int Group8member3 { get; set; }

            [Column( "group8member4" )]
            public int Group8member4 { get; set; }

            [Column( "group8member5" )]
            public int Group8member5 { get; set; }

            [Column( "timestamp" )]
            public int Timestamp { get; set; }

            [Column( "instanceids" ), Required]
            public string Instanceids { get; set; }

    }
}