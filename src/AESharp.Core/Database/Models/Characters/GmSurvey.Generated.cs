// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class GmSurvey
    {
            [Key, Column( "survey_id" )]
            public uint SurveyId { get; set; }

            [Column( "guid" )]
            public uint Guid { get; set; }

            [Column( "main_survey" )]
            public uint MainSurvey { get; set; }

            [Column( "comment" ), Required]
            public string Comment { get; set; }

            [Column( "create_time" )]
            public uint CreateTime { get; set; }

    }
}