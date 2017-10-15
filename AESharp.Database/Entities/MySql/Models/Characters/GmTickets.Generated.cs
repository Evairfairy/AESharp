// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class GmTickets
    {
            [Key, Column( "ticketid" )]
            public int Ticketid { get; set; }

            [Column( "playerGuid" )]
            public int Playerguid { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

            [Column( "level" )]
            public int Level { get; set; }

            [Column( "map" )]
            public int Map { get; set; }

            [Column( "posX" )]
            public float Posx { get; set; }

            [Column( "posY" )]
            public float Posy { get; set; }

            [Column( "posZ" )]
            public float Posz { get; set; }

            [Column( "message" ), Required]
            public string Message { get; set; }

            [Column( "timestamp" )]
            public string Timestamp { get; set; }

            [Column( "deleted" )]
            public uint Deleted { get; set; }

            [Column( "assignedto" )]
            public int Assignedto { get; set; }

            [Column( "comment" ), Required]
            public string Comment { get; set; }

    }
}