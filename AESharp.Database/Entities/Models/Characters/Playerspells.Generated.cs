// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class PlayerSpells
    {
            [Column( "GUID" )]
            public uint Guid { get; set; }

            [Column( "SpellID" )]
            public uint Spellid { get; set; }

    }
}