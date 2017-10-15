// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class NpcScriptText
    {
            [Key, Column( "entry" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public int Entry { get; set; }

            [Column( "text" )]
            public string Text { get; set; }

            // entry from creature_names
            [Column( "creature_entry" )]
            public uint CreatureEntry { get; set; }

            // creature_entry and id (unique)
            [Column( "id" )]
            public byte Id { get; set; }

            [Column( "type" )]
            public byte Type { get; set; }

            [Column( "language" )]
            public byte Language { get; set; }

            [Column( "probability" )]
            public float Probability { get; set; }

            [Column( "emote" )]
            public uint Emote { get; set; }

            [Column( "duration" )]
            public uint Duration { get; set; }

            [Column( "sound" )]
            public uint Sound { get; set; }

            [Column( "broadcast_id" )]
            public int BroadcastId { get; set; }

    }
}