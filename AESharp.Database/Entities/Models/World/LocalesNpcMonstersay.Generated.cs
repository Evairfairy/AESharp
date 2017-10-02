// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class LocalesNpcMonstersay
    {
            [Column( "entry" )]
            public int Entry { get; set; }

            [Column( "language_code" ), Required]
            public string LanguageCode { get; set; }

            [Column( "monstername" ), Required]
            public string Monstername { get; set; }

            [Column( "text0" ), Required]
            public string Text0 { get; set; }

            [Column( "text1" ), Required]
            public string Text1 { get; set; }

            [Column( "text2" ), Required]
            public string Text2 { get; set; }

            [Column( "text3" ), Required]
            public string Text3 { get; set; }

            [Column( "text4" ), Required]
            public string Text4 { get; set; }

    }
}