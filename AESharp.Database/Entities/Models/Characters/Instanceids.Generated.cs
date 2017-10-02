// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class InstanceIds
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