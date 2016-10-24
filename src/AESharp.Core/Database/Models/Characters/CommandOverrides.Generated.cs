// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class CommandOverrides
    {
            [Key, Column( "command_name" ), Required]
            public string CommandName { get; set; }

            [Column( "access_level" ), Required]
            public string AccessLevel { get; set; }

    }
}