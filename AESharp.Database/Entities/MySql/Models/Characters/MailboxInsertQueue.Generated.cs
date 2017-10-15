// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class MailboxInsertQueue
    {
            [Column( "sender_guid" )]
            public long SenderGuid { get; set; }

            [Column( "receiver_guid" )]
            public int ReceiverGuid { get; set; }

            [Column( "subject" ), Required]
            public string Subject { get; set; }

            [Column( "body" ), Required]
            public string Body { get; set; }

            [Column( "stationary" )]
            public int Stationary { get; set; }

            [Column( "money" )]
            public int Money { get; set; }

            [Column( "item_id" )]
            public int ItemId { get; set; }

            [Column( "item_stack" )]
            public int ItemStack { get; set; }

            [Column( "item_id2" )]
            public int ItemId2 { get; set; }

            [Column( "item_stack2" )]
            public int ItemStack2 { get; set; }

            [Column( "item_id3" )]
            public int ItemId3 { get; set; }

            [Column( "item_stack3" )]
            public int ItemStack3 { get; set; }

            [Column( "item_id4" )]
            public int ItemId4 { get; set; }

            [Column( "item_stack4" )]
            public int ItemStack4 { get; set; }

            [Column( "item_id5" )]
            public int ItemId5 { get; set; }

            [Column( "item_stack5" )]
            public int ItemStack5 { get; set; }

            [Column( "item_id6" )]
            public int ItemId6 { get; set; }

            [Column( "item_stack6" )]
            public int ItemStack6 { get; set; }

            [Column( "item_id7" )]
            public int ItemId7 { get; set; }

            [Column( "item_stack7" )]
            public int ItemStack7 { get; set; }

            [Column( "item_id8" )]
            public int ItemId8 { get; set; }

            [Column( "item_stack8" )]
            public int ItemStack8 { get; set; }

            [Column( "item_id9" )]
            public int ItemId9 { get; set; }

            [Column( "item_stack9" )]
            public int ItemStack9 { get; set; }

            [Column( "item_id10" )]
            public int ItemId10 { get; set; }

            [Column( "item_stack10" )]
            public int ItemStack10 { get; set; }

            [Column( "item_id11" )]
            public int ItemId11 { get; set; }

            [Column( "item_stack11" )]
            public int ItemStack11 { get; set; }

            [Column( "item_id12" )]
            public int ItemId12 { get; set; }

            [Column( "item_stack12" )]
            public int ItemStack12 { get; set; }

    }
}