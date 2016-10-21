// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class EventProperties
    {
            // Entry of the game event
            [Key, Column( "entry" )]
            public byte Entry { get; set; }

            // Absolute start date, the event will never start before
            [Column( "start_time" )]
            public DateTime StartTime { get; set; }

            // Absolute end date, the event will never start afler
            [Column( "end_time" )]
            public DateTime EndTime { get; set; }

            // Delay in minutes between occurences of the event
            [Column( "occurence" )]
            public ulong Occurence { get; set; }

            // Length in minutes of the event
            [Column( "length" )]
            public ulong Length { get; set; }

            // Client side holiday id
            [Column( "holiday" )]
            public uint Holiday { get; set; }

            // Description of the event displayed in console
            [Column( "description" )]
            public string Description { get; set; }

            // 0 if normal event, 1 if world event
            [Column( "world_event" )]
            public byte WorldEvent { get; set; }

            // 0 dont announce, 1 announce, 2 value from config
            [Column( "announce" )]
            public byte Announce { get; set; }

    }
}