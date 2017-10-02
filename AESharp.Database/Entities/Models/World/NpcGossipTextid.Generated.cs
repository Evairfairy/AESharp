// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class NpcGossipTextId
    {
            [Key, Column( "creatureid" )]
            public uint Creatureid { get; set; }

            [Column( "textid" )]
            public uint Textid { get; set; }

    }
}