// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class SocialIgnores
    {
            [Column( "character_guid" )]
            public int CharacterGuid { get; set; }

            [Column( "ignore_guid" )]
            public int IgnoreGuid { get; set; }

    }
}