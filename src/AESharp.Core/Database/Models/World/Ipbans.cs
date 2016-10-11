// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class Ipbans
    {
            [Key, Column( "ip" ), Required]
            public string Ip { get; set; }

            // Expiry time (s)
            [Column( "expire" )]
            public int Expire { get; set; }

            [Column( "banreason" )]
            public string Banreason { get; set; }

    }
}