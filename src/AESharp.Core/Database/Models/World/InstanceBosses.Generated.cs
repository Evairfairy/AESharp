// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class InstanceBosses
    {
            [Column( "mapid" )]
            public uint Mapid { get; set; }

            [Column( "creatureid" )]
            public uint Creatureid { get; set; }

            [Column( "trash" ), Required]
            public string Trash { get; set; }

            [Column( "trash_respawn_override" )]
            public uint TrashRespawnOverride { get; set; }

    }
}