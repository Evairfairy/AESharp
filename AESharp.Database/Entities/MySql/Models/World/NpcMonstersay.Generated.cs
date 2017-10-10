// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class NpcMonsterSay
    {
            [Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "event" )]
            public uint Event { get; set; }

            [Column( "chance" )]
            public float Chance { get; set; }

            [Column( "language" )]
            public uint Language { get; set; }

            [Column( "type" )]
            public uint Type { get; set; }

            [Column( "monstername" )]
            public string Monstername { get; set; }

            [Column( "text0" )]
            public string Text0 { get; set; }

            [Column( "text1" )]
            public string Text1 { get; set; }

            [Column( "text2" )]
            public string Text2 { get; set; }

            [Column( "text3" )]
            public string Text3 { get; set; }

            [Column( "text4" )]
            public string Text4 { get; set; }

    }
}