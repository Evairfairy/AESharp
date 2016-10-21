// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class EventScripts
    {
            [Key, Column( "event_id" )]
            public int EventId { get; set; }

            [Column( "function" )]
            public int Function { get; set; }

            [Column( "script_type" )]
            public int ScriptType { get; set; }

            [Column( "data_1" )]
            public int Data1 { get; set; }

            [Column( "data_2" )]
            public int Data2 { get; set; }

            [Column( "data_3" )]
            public int Data3 { get; set; }

            [Column( "data_4" )]
            public int Data4 { get; set; }

            [Column( "data_5" )]
            public int Data5 { get; set; }

            [Column( "x" )]
            public float X { get; set; }

            [Column( "y" )]
            public float Y { get; set; }

            [Column( "z" )]
            public float Z { get; set; }

            [Column( "o" )]
            public float O { get; set; }

            [Column( "delay" )]
            public int Delay { get; set; }

            [Column( "next_event" )]
            public sbyte NextEvent { get; set; }

    }
}