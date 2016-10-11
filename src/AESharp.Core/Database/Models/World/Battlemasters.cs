// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class Battlemasters
    {
            [Key, Column( "creature_entry" )]
            public ushort CreatureEntry { get; set; }

            [Column( "battleground_id" )]
            public byte BattlegroundId { get; set; }

    }
}