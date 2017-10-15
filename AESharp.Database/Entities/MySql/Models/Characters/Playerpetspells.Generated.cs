// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
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