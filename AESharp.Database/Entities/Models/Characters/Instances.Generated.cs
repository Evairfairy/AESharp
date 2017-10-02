// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class Instances
    {
            [Column( "id" )]
            public int Id { get; set; }

            [Column( "mapid" )]
            public int Mapid { get; set; }

            [Column( "creation" )]
            public int Creation { get; set; }

            [Column( "expiration" )]
            public int Expiration { get; set; }

            [Column( "killed_npc_guids" ), Required]
            public string KilledNpcGuids { get; set; }

            [Column( "difficulty" )]
            public int Difficulty { get; set; }

            [Column( "creator_group" )]
            public int CreatorGroup { get; set; }

            [Column( "creator_guid" )]
            public int CreatorGuid { get; set; }

            [Column( "persistent" )]
            public sbyte Persistent { get; set; }

    }
}