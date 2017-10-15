// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class EventSave
    {
            [Key, Column( "event_entry" )]
            public uint EventEntry { get; set; }

            [Column( "state" )]
            public byte State { get; set; }

            [Column( "next_start" )]
            public uint NextStart { get; set; }

    }
}