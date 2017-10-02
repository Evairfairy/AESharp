// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class GossipMenuOption
    {
            [Key, Column( "entry" )]
            [DatabaseGenerated( DatabaseGeneratedOption.Identity )]
            public int Entry { get; set; }

            [Column( "option_text" ), Required]
            public string OptionText { get; set; }

    }
}