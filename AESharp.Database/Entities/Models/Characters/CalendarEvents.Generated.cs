// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class CalendarEvents
    {
            [Key, Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "creator" )]
            public uint Creator { get; set; }

            [Column( "title" ), Required]
            public string Title { get; set; }

            [Column( "description" ), Required]
            public string Description { get; set; }

            [Column( "type" )]
            public byte Type { get; set; }

            [Column( "dungeon" )]
            public int Dungeon { get; set; }

            [Column( "date" )]
            public uint Date { get; set; }

            [Column( "flags" )]
            public uint Flags { get; set; }

    }
}