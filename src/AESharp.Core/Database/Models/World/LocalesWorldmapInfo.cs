// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class LocalesWorldMapInfo
    {
            [Column( "entry" )]
            public int Entry { get; set; }

            [Column( "language_code" ), Required]
            public string LanguageCode { get; set; }

            [Column( "text" ), Required]
            public string Text { get; set; }

    }
}