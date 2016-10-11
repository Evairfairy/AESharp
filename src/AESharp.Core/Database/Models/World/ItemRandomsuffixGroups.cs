// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class ItemRandomsuffixGroups
    {
            [Column( "entry_id" )]
            public ushort EntryId { get; set; }

            [Column( "randomsuffix_entryid" )]
            public byte RandomsuffixEntryid { get; set; }

            [Column( "chance" )]
            public float Chance { get; set; }

    }
}