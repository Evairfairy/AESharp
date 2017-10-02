// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class ItemSetLinkedItemSetBonus
    {
            [Key, Column( "itemset" )]
            public int Itemset { get; set; }

            // linked itemset for itemset bonus
            [Column( "itemset_bonus" )]
            public int ItemsetBonus { get; set; }

    }
}