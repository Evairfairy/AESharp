// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class Instanceids
    {
            [Column( "playerguid" )]
            public uint Playerguid { get; set; }

            [Column( "mapid" )]
            public uint Mapid { get; set; }

            [Column( "mode" )]
            public uint Mode { get; set; }

            [Column( "instanceid" )]
            public uint Instanceid { get; set; }

    }
}