// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
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