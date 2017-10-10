// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class BattleMasters
    {
            [Key, Column( "creature_entry" )]
            public ushort CreatureEntry { get; set; }

            [Column( "battleground_id" )]
            public byte BattlegroundId { get; set; }

    }
}