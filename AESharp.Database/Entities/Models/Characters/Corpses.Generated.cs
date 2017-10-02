// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class Corpses
    {
            [Column( "guid" )]
            public ulong Guid { get; set; }

            [Column( "positionX" )]
            public float Positionx { get; set; }

            [Column( "positionY" )]
            public float Positiony { get; set; }

            [Column( "positionZ" )]
            public float Positionz { get; set; }

            [Column( "orientation" )]
            public float Orientation { get; set; }

            [Column( "zoneId" )]
            public int Zoneid { get; set; }

            [Column( "mapId" )]
            public int Mapid { get; set; }

            [Column( "instanceId" )]
            public int Instanceid { get; set; }

            [Column( "data" ), Required]
            public string Data { get; set; }

    }
}