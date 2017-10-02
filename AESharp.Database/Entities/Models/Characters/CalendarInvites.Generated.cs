// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class CalendarInvites
    {
            [Key, Column( "id" )]
            public ulong Id { get; set; }

            [Column( "event" )]
            public ulong Event { get; set; }

            [Column( "invitee" )]
            public uint Invitee { get; set; }

            [Column( "sender" )]
            public uint Sender { get; set; }

            [Column( "status" )]
            public byte Status { get; set; }

            [Column( "statustime" )]
            public uint Statustime { get; set; }

            [Column( "rank" )]
            public byte Rank { get; set; }

            [Column( "text" ), Required]
            public string Text { get; set; }

    }
}