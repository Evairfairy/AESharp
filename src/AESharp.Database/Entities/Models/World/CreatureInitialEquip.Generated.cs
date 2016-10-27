// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class CreatureInitialEquip
    {
            [Key, Column( "creature_entry" )]
            public uint CreatureEntry { get; set; }

            [Column( "itemslot_1" )]
            public uint Itemslot1 { get; set; }

            [Column( "itemslot_2" )]
            public uint Itemslot2 { get; set; }

            [Column( "itemslot_3" )]
            public uint Itemslot3 { get; set; }

    }
}