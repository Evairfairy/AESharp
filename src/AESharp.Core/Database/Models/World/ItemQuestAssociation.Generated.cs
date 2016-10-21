// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class ItemQuestAssociation
    {
            [Column( "item" )]
            public int Item { get; set; }

            [Column( "quest" )]
            public int Quest { get; set; }

            [Column( "item_count" )]
            public int ItemCount { get; set; }

    }
}