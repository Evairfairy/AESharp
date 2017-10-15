// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class LocalesGameobject
    {
            [Column( "entry" )]
            public int Entry { get; set; }

            [Column( "language_code" ), Required]
            public string LanguageCode { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

    }
}