// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class Playersummonspells
    {
            [Key, Column( "ownerguid" )]
            public long Ownerguid { get; set; }

            [Column( "entryid" )]
            public int Entryid { get; set; }

            [Column( "spellid" )]
            public int Spellid { get; set; }

    }
}