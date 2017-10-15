// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class Charters
    {
            [Column( "charterId" )]
            public int Charterid { get; set; }

            [Column( "charterType" )]
            public int Chartertype { get; set; }

            [Column( "leaderGuid" )]
            public uint Leaderguid { get; set; }

            [Column( "guildName" ), Required]
            public string Guildname { get; set; }

            [Column( "itemGuid" )]
            public ulong Itemguid { get; set; }

            [Column( "signer1" )]
            public uint Signer1 { get; set; }

            [Column( "signer2" )]
            public uint Signer2 { get; set; }

            [Column( "signer3" )]
            public uint Signer3 { get; set; }

            [Column( "signer4" )]
            public uint Signer4 { get; set; }

            [Column( "signer5" )]
            public uint Signer5 { get; set; }

            [Column( "signer6" )]
            public uint Signer6 { get; set; }

            [Column( "signer7" )]
            public uint Signer7 { get; set; }

            [Column( "signer8" )]
            public uint Signer8 { get; set; }

            [Column( "signer9" )]
            public uint Signer9 { get; set; }

    }
}