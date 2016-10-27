// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class Graveyards
    {
            [Key, Column( "id" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public ushort Id { get; set; }

            [Column( "position_x" )]
            public float PositionX { get; set; }

            [Column( "position_y" )]
            public float PositionY { get; set; }

            [Column( "position_z" )]
            public float PositionZ { get; set; }

            [Column( "orientation" )]
            public float Orientation { get; set; }

            [Column( "zoneid" )]
            public byte Zoneid { get; set; }

            [Column( "adjacentzoneid" )]
            public byte Adjacentzoneid { get; set; }

            [Column( "mapid" )]
            public ushort Mapid { get; set; }

            // TODO: this is an enum field, human intervention required
            [Column( "faction" ), Required]
            public string Faction { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

    }
}