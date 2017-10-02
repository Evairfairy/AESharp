// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class AccountData
    {
            [Key, Column( "acct" )]
            public int Acct { get; set; }

            [Column( "uiconfig0" )]
            public byte[] Uiconfig0 { get; set; }

            [Column( "uiconfig1" )]
            public byte[] Uiconfig1 { get; set; }

            [Column( "uiconfig2" )]
            public byte[] Uiconfig2 { get; set; }

            [Column( "uiconfig3" )]
            public byte[] Uiconfig3 { get; set; }

            [Column( "uiconfig4" )]
            public byte[] Uiconfig4 { get; set; }

            [Column( "uiconfig5" )]
            public byte[] Uiconfig5 { get; set; }

            [Column( "uiconfig6" )]
            public byte[] Uiconfig6 { get; set; }

            [Column( "uiconfig7" )]
            public byte[] Uiconfig7 { get; set; }

            [Column( "uiconfig8" )]
            public byte[] Uiconfig8 { get; set; }

    }
}