// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class PlayerSpells
    {
            [Column( "GUID" )]
            public uint Guid { get; set; }

            [Column( "SpellID" )]
            public uint Spellid { get; set; }

    }
}