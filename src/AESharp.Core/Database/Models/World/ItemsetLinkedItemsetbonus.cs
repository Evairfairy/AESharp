// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class ItemsetLinkedItemsetbonus
    {
            [Key, Column( "itemset" )]
            public int Itemset { get; set; }

            // linked itemset for itemset bonus
            [Column( "itemset_bonus" )]
            public int ItemsetBonus { get; set; }

    }
}