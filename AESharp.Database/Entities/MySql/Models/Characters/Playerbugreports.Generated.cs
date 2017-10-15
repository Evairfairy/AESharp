// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class PlayerBugReports
    {
            [Key, Column( "UID" )]
            public uint Uid { get; set; }

            [Column( "AccountID" )]
            public uint Accountid { get; set; }

            [Column( "TimeStamp" )]
            public uint Timestamp { get; set; }

            [Column( "Suggestion" )]
            public uint Suggestion { get; set; }

            [Column( "Type" ), Required]
            public string Type { get; set; }

            [Column( "Content" ), Required]
            public string Content { get; set; }

    }
}