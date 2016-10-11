// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class ItemPages
    {
            [Key, Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "text" ), Required]
            public string Text { get; set; }

            [Column( "next_page" )]
            public uint NextPage { get; set; }

    }
}