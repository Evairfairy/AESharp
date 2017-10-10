// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class Tutorials
    {
            [Key, Column( "playerId" )]
            public ulong Playerid { get; set; }

            [Column( "tut0" )]
            public ulong Tut0 { get; set; }

            [Column( "tut1" )]
            public ulong Tut1 { get; set; }

            [Column( "tut2" )]
            public ulong Tut2 { get; set; }

            [Column( "tut3" )]
            public ulong Tut3 { get; set; }

            [Column( "tut4" )]
            public ulong Tut4 { get; set; }

            [Column( "tut5" )]
            public ulong Tut5 { get; set; }

            [Column( "tut6" )]
            public ulong Tut6 { get; set; }

            [Column( "tut7" )]
            public ulong Tut7 { get; set; }

    }
}