// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
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