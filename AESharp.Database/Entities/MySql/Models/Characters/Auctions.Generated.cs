// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class Auctions
    {
            [Column( "auctionId" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public int Auctionid { get; set; }

            [Column( "auctionhouse" )]
            public int Auctionhouse { get; set; }

            [Column( "item" )]
            public long Item { get; set; }

            [Column( "owner" )]
            public long Owner { get; set; }

            [Column( "startbid" )]
            public int Startbid { get; set; }

            [Column( "buyout" )]
            public int Buyout { get; set; }

            [Column( "time" )]
            public int Time { get; set; }

            [Column( "bidder" )]
            public long Bidder { get; set; }

            [Column( "bid" )]
            public int Bid { get; set; }

            [Column( "deposit" )]
            public int Deposit { get; set; }

    }
}