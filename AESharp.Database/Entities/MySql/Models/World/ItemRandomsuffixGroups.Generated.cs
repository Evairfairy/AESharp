// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class ItemRandomSuffixGroups
    {
            [Column( "entry_id" )]
            public ushort EntryId { get; set; }

            [Column( "randomsuffix_entryid" )]
            public byte RandomsuffixEntryid { get; set; }

            [Column( "chance" )]
            public float Chance { get; set; }

    }
}