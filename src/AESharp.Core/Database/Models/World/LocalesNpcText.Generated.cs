// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class LocalesNpcText
    {
            [Column( "entry" )]
            public int Entry { get; set; }

            [Column( "language_code" ), Required]
            public string LanguageCode { get; set; }

            [Column( "text0" ), Required]
            public string Text0 { get; set; }

            [Column( "text0_1" ), Required]
            public string Text01 { get; set; }

            [Column( "text1" ), Required]
            public string Text1 { get; set; }

            [Column( "text1_1" ), Required]
            public string Text11 { get; set; }

            [Column( "text2" ), Required]
            public string Text2 { get; set; }

            [Column( "text2_1" ), Required]
            public string Text21 { get; set; }

            [Column( "text3" ), Required]
            public string Text3 { get; set; }

            [Column( "text3_1" ), Required]
            public string Text31 { get; set; }

            [Column( "text4" ), Required]
            public string Text4 { get; set; }

            [Column( "text4_1" ), Required]
            public string Text41 { get; set; }

            [Column( "text5" ), Required]
            public string Text5 { get; set; }

            [Column( "text5_1" ), Required]
            public string Text51 { get; set; }

            [Column( "text6" ), Required]
            public string Text6 { get; set; }

            [Column( "text6_1" ), Required]
            public string Text61 { get; set; }

            [Column( "text7" ), Required]
            public string Text7 { get; set; }

            [Column( "text7_1" ), Required]
            public string Text71 { get; set; }

    }
}