// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class PlayerItems
    {
            [Column( "ownerguid" )]
            public uint Ownerguid { get; set; }

            [Column( "guid" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public long Guid { get; set; }

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
            public int Charges { get; set; }

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

            [Column( "containerslot" )]
            public int Containerslot { get; set; }

            [Column( "slot" )]
            public int Slot { get; set; }

            [Column( "enchantments" ), Required]
            public string Enchantments { get; set; }

            [Column( "duration_expireson" )]
            public uint DurationExpireson { get; set; }

            [Column( "refund_purchasedon" )]
            public uint RefundPurchasedon { get; set; }

            [Column( "refund_costid" )]
            public uint RefundCostid { get; set; }

            [Column( "text" ), Required]
            public string Text { get; set; }

    }
}