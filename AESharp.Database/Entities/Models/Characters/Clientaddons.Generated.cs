// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class ClientAddons
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