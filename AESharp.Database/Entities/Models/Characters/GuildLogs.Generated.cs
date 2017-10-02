// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class GuildLogs
    {
            [Column( "log_id" )]
            public int LogId { get; set; }

            [Column( "guildid" )]
            public int Guildid { get; set; }

            [Column( "timestamp" )]
            public int Timestamp { get; set; }

            [Column( "event_type" )]
            public int EventType { get; set; }

            [Column( "misc1" )]
            public int Misc1 { get; set; }

            [Column( "misc2" )]
            public int Misc2 { get; set; }

            [Column( "misc3" )]
            public int Misc3 { get; set; }

    }
}