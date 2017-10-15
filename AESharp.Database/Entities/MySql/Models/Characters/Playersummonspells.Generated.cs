// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class PlayerSummonSpells
    {
            [Key, Column( "ownerguid" )]
            public long Ownerguid { get; set; }

            [Column( "entryid" )]
            public int Entryid { get; set; }

            [Column( "spellid" )]
            public int Spellid { get; set; }

    }
}