// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class CommandOverrides
    {
            [Key, Column( "command_name" ), Required]
            public string CommandName { get; set; }

            [Column( "access_level" ), Required]
            public string AccessLevel { get; set; }

    }
}