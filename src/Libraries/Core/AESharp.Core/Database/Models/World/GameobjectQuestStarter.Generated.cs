// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class GameobjectQuestStarter
    {
            [Column( "id" )]
            public uint Id { get; set; }

            [Column( "quest" )]
            public uint Quest { get; set; }

    }
}