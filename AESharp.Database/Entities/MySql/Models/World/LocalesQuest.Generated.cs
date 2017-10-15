// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class LocalesQuest
    {
            [Column( "entry" )]
            public int Entry { get; set; }

            [Column( "language_code" ), Required]
            public string LanguageCode { get; set; }

            [Column( "Title" ), Required]
            public string Title { get; set; }

            [Column( "Details" ), Required]
            public string Details { get; set; }

            [Column( "Objectives" ), Required]
            public string Objectives { get; set; }

            [Column( "CompletionText" ), Required]
            public string Completiontext { get; set; }

            [Column( "IncompleteText" ), Required]
            public string Incompletetext { get; set; }

            [Column( "EndText" ), Required]
            public string Endtext { get; set; }

            [Column( "ObjectiveText1" ), Required]
            public string Objectivetext1 { get; set; }

            [Column( "ObjectiveText2" ), Required]
            public string Objectivetext2 { get; set; }

            [Column( "ObjectiveText3" ), Required]
            public string Objectivetext3 { get; set; }

            [Column( "ObjectiveText4" ), Required]
            public string Objectivetext4 { get; set; }

    }
}