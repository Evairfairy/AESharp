// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class BannedPhrases
    {
            [Key, Column( "phrase" ), Required]
            public string Phrase { get; set; }

    }
}