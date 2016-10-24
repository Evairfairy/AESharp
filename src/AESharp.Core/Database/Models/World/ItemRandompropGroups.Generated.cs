// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class ItemRandomPropGroups
    {
            [Column( "entry_id" )]
            public ushort EntryId { get; set; }

            [Column( "randomprops_entryid" )]
            public ushort RandompropsEntryid { get; set; }

            [Column( "chance" )]
            public float Chance { get; set; }

    }
}