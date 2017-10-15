// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class Mailbox
    {
            [Column( "message_id" )]
            public int MessageId { get; set; }

            [Column( "message_type" )]
            public int MessageType { get; set; }

            [Column( "player_guid" )]
            public int PlayerGuid { get; set; }

            [Column( "sender_guid" )]
            public ulong SenderGuid { get; set; }

            [Column( "subject" ), Required]
            public string Subject { get; set; }

            [Column( "body" ), Required]
            public string Body { get; set; }

            [Column( "money" )]
            public int Money { get; set; }

            [Column( "attached_item_guids" ), Required]
            public string AttachedItemGuids { get; set; }

            [Column( "cod" )]
            public int Cod { get; set; }

            [Column( "stationary" )]
            public int Stationary { get; set; }

            [Column( "expiry_time" )]
            public int ExpiryTime { get; set; }

            [Column( "delivery_time" )]
            public int DeliveryTime { get; set; }

            [Column( "checked_flag" )]
            public uint CheckedFlag { get; set; }

            [Column( "deleted_flag" )]
            public int DeletedFlag { get; set; }

    }
}