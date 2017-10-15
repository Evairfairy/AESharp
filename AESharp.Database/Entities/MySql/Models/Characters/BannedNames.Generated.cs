// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class BannedNames
    {
            [Column( "name" ), Required]
            public string Name { get; set; }

    }
}