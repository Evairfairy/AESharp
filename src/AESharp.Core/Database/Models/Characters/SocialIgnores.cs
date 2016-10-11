// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class SocialIgnores
    {
            [Column( "character_guid" )]
            public int CharacterGuid { get; set; }

            [Column( "ignore_guid" )]
            public int IgnoreGuid { get; set; }

    }
}