// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class LocalesCreature
    {
            [Column( "id" )]
            public uint Id { get; set; }

            [Column( "language_code" ), Required]
            public string LanguageCode { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

            [Column( "subname" ), Required]
            public string Subname { get; set; }

    }
}