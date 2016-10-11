// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class Clientaddons
    {
            [Column( "id" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public int Id { get; set; }

            [Column( "name" )]
            public string Name { get; set; }

            [Column( "crc" )]
            public long Crc { get; set; }

            [Column( "banned" )]
            public int Banned { get; set; }

            [Column( "showinlist" )]
            public int Showinlist { get; set; }

    }
}