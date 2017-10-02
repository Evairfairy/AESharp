// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class PlayerReputations
    {
            [Column( "guid" )]
            public uint Guid { get; set; }

            [Column( "faction" )]
            public uint Faction { get; set; }

            [Column( "flag" )]
            public uint Flag { get; set; }

            [Column( "basestanding" )]
            public int Basestanding { get; set; }

            [Column( "standing" )]
            public int Standing { get; set; }

    }
}