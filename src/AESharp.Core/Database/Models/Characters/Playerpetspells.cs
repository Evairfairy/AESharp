// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class PlayerPetSpells
    {
            [Column( "ownerguid" )]
            public long Ownerguid { get; set; }

            [Column( "petnumber" )]
            public int Petnumber { get; set; }

            [Column( "spellid" )]
            public int Spellid { get; set; }

            [Column( "flags" )]
            public int Flags { get; set; }

    }
}