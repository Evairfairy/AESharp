// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class LocalesItemPages
    {
            [Column( "entry" )]
            public int Entry { get; set; }

            [Column( "language_code" ), Required]
            public string LanguageCode { get; set; }

            [Column( "text" ), Required]
            public string Text { get; set; }

    }
}