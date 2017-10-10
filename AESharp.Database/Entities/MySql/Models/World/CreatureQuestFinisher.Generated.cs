// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class CreatureQuestFinisher
    {
            [Column( "id" )]
            public uint Id { get; set; }

            [Column( "quest" )]
            public uint Quest { get; set; }

    }
}