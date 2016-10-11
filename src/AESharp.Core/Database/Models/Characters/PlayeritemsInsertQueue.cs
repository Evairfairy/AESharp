// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class PlayeritemsInsertQueue
    {
            [Key, Column( "ownerguid" )]
            public uint Ownerguid { get; set; }

            [Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "wrapped_item_id" )]
            public int WrappedItemId { get; set; }

            [Column( "wrapped_creator" )]
            public int WrappedCreator { get; set; }

            [Column( "creator" )]
            public uint Creator { get; set; }

            [Column( "count" )]
            public uint Count { get; set; }

            [Column( "charges" )]
            public uint Charges { get; set; }

            [Column( "flags" )]
            public uint Flags { get; set; }

            [Column( "randomprop" )]
            public uint Randomprop { get; set; }

            [Column( "randomsuffix" )]
            public int Randomsuffix { get; set; }

            [Column( "itemtext" )]
            public uint Itemtext { get; set; }

            [Column( "durability" )]
            public uint Durability { get; set; }

            // couldnt find this being used in source
            [Column( "containerslot" )]
            public int Containerslot { get; set; }

            [Column( "slot" )]
            public sbyte Slot { get; set; }

            [Column( "enchantments" ), Required]
            public string Enchantments { get; set; }

    }
}