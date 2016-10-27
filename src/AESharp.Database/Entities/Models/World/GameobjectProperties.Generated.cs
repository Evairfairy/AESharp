// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class GameobjectProperties
    {
            [Key, Column( "entry" )]
            public uint Entry { get; set; }

            // Type of this go. Fill in all necessary parameters
            [Column( "type" )]
            public byte Type { get; set; }

            // Go visible display id
            [Column( "display_id" )]
            public uint DisplayId { get; set; }

            [Column( "name" )]
            public string Name { get; set; }

            [Column( "category_name" )]
            public string CategoryName { get; set; }

            [Column( "cast_bar_text" )]
            public string CastBarText { get; set; }

            [Column( "UnkStr" )]
            public string Unkstr { get; set; }

            [Column( "parameter_0" )]
            public uint Parameter0 { get; set; }

            // Parameter for type
            [Column( "parameter_1" )]
            public uint Parameter1 { get; set; }

            // Parameter for type
            [Column( "parameter_2" )]
            public uint Parameter2 { get; set; }

            // Parameter for type
            [Column( "parameter_3" )]
            public uint Parameter3 { get; set; }

            // Parameter for type
            [Column( "parameter_4" )]
            public uint Parameter4 { get; set; }

            // Parameter for type
            [Column( "parameter_5" )]
            public uint Parameter5 { get; set; }

            // Parameter for type
            [Column( "parameter_6" )]
            public uint Parameter6 { get; set; }

            // Parameter for type
            [Column( "parameter_7" )]
            public uint Parameter7 { get; set; }

            // Parameter for type
            [Column( "parameter_8" )]
            public uint Parameter8 { get; set; }

            // Parameter for type
            [Column( "parameter_9" )]
            public uint Parameter9 { get; set; }

            // Parameter for type
            [Column( "parameter_10" )]
            public uint Parameter10 { get; set; }

            // Parameter for type
            [Column( "parameter_11" )]
            public uint Parameter11 { get; set; }

            // Parameter for type
            [Column( "parameter_12" )]
            public uint Parameter12 { get; set; }

            // Parameter for type
            [Column( "parameter_13" )]
            public uint Parameter13 { get; set; }

            // Parameter for type
            [Column( "parameter_14" )]
            public uint Parameter14 { get; set; }

            // Parameter for type
            [Column( "parameter_15" )]
            public uint Parameter15 { get; set; }

            // Parameter for type
            [Column( "parameter_16" )]
            public uint Parameter16 { get; set; }

            // Parameter for type
            [Column( "parameter_17" )]
            public uint Parameter17 { get; set; }

            // Parameter for type
            [Column( "parameter_18" )]
            public uint Parameter18 { get; set; }

            // Parameter for type
            [Column( "parameter_19" )]
            public uint Parameter19 { get; set; }

            // Parameter for type
            [Column( "parameter_20" )]
            public uint Parameter20 { get; set; }

            // Parameter for type
            [Column( "parameter_21" )]
            public uint Parameter21 { get; set; }

            // Parameter for type
            [Column( "parameter_22" )]
            public uint Parameter22 { get; set; }

            // Parameter for type
            [Column( "parameter_23" )]
            public uint Parameter23 { get; set; }

            // Default size for this gameobject
            [Column( "size" )]
            public float Size { get; set; }

            [Column( "QuestItem1" )]
            public uint Questitem1 { get; set; }

            [Column( "QuestItem2" )]
            public uint Questitem2 { get; set; }

            [Column( "QuestItem3" )]
            public uint Questitem3 { get; set; }

            [Column( "QuestItem4" )]
            public uint Questitem4 { get; set; }

            [Column( "QuestItem5" )]
            public uint Questitem5 { get; set; }

            [Column( "QuestItem6" )]
            public uint Questitem6 { get; set; }

    }
}