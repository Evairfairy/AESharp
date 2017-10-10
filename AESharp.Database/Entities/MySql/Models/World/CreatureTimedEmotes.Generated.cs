// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class CreatureTimedEmotes
    {
            [Column( "spawnid" )]
            public uint Spawnid { get; set; }

            [Column( "rowid" )]
            public uint Rowid { get; set; }

            [Column( "type" )]
            public byte Type { get; set; }

            [Column( "value" )]
            public uint Value { get; set; }

            [Column( "msg" )]
            public string Msg { get; set; }

            [Column( "msg_type" )]
            public uint MsgType { get; set; }

            [Column( "msg_lang" )]
            public uint MsgLang { get; set; }

            [Column( "expire_after" )]
            public uint ExpireAfter { get; set; }

    }
}