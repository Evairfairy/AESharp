// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class AiAgents
    {
            [Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "instance_mode" )]
            public byte InstanceMode { get; set; }

            [Column( "type" )]
            public byte Type { get; set; }

            [Column( "event" )]
            public byte Event { get; set; }

            [Column( "chance" )]
            public byte Chance { get; set; }

            [Column( "maxcount" )]
            public byte Maxcount { get; set; }

            [Column( "spell" )]
            public uint Spell { get; set; }

            [Column( "spelltype" )]
            public byte Spelltype { get; set; }

            [Column( "targettype_overwrite" )]
            public sbyte TargettypeOverwrite { get; set; }

            [Column( "cooldown_overwrite" )]
            public int CooldownOverwrite { get; set; }

            [Column( "floatMisc1" )]
            public float Floatmisc1 { get; set; }

            [Column( "Misc2" )]
            public uint Misc2 { get; set; }

    }
}