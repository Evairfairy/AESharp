// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.World
{
    public sealed class GameobjectTeleports
    {
            [Key, Column( "entry" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public uint Entry { get; set; }

            [Column( "mapid" )]
            public uint Mapid { get; set; }

            [Column( "x_pos" )]
            public float XPos { get; set; }

            [Column( "y_pos" )]
            public float YPos { get; set; }

            [Column( "z_pos" )]
            public float ZPos { get; set; }

            [Column( "orientation" )]
            public float Orientation { get; set; }

            [Column( "required_level" )]
            public uint RequiredLevel { get; set; }

            [Column( "required_class" )]
            public sbyte RequiredClass { get; set; }

            [Column( "required_achievement" )]
            public int RequiredAchievement { get; set; }

    }
}