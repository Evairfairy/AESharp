// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class GmSurveyAnswers
    {
            [Column( "survey_id" )]
            public uint SurveyId { get; set; }

            [Column( "question_id" )]
            public uint QuestionId { get; set; }

            [Column( "answer_id" )]
            public uint AnswerId { get; set; }

    }
}