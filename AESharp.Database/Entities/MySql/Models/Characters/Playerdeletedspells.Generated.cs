// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class PlayerDeletedSpells
    {
            [Column( "GUID" )]
            public uint Guid { get; set; }

            [Column( "SpellID" )]
            public uint Spellid { get; set; }

    }
}