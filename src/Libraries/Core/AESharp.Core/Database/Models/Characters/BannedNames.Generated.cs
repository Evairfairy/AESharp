// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.Characters
{
    public sealed class BannedNames
    {
            [Column( "name" ), Required]
            public string Name { get; set; }

    }
}