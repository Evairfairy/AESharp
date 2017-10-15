// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class PlayerSummons
    {
            [Key, Column( "ownerguid" )]
            public uint Ownerguid { get; set; }

            [Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

    }
}