// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class DisplayBoundingBoxes
    {
            [Key, Column( "displayid" )]
            public ushort Displayid { get; set; }

            [Column( "lowx" )]
            public float Lowx { get; set; }

            [Column( "lowy" )]
            public float Lowy { get; set; }

            [Column( "lowz" )]
            public float Lowz { get; set; }

            [Column( "highx" )]
            public float Highx { get; set; }

            [Column( "highy" )]
            public float Highy { get; set; }

            [Column( "highz" )]
            public float Highz { get; set; }

            [Column( "boundradius" )]
            public float Boundradius { get; set; }

    }
}