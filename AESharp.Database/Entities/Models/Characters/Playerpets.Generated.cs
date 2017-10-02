// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class PlayerPets
    {
            [Column( "ownerguid" )]
            public long Ownerguid { get; set; }

            [Column( "petnumber" )]
            public int Petnumber { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

            [Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "xp" )]
            public int Xp { get; set; }

            [Column( "active" )]
            public sbyte Active { get; set; }

            [Column( "level" )]
            public int Level { get; set; }

            [Column( "actionbar" ), Required]
            public string Actionbar { get; set; }

            [Column( "happinessupdate" )]
            public int Happinessupdate { get; set; }

            [Column( "reset_time" )]
            public uint ResetTime { get; set; }

            [Column( "reset_cost" )]
            public int ResetCost { get; set; }

            [Column( "spellid" )]
            public uint Spellid { get; set; }

            [Column( "petstate" )]
            public uint Petstate { get; set; }

            [Column( "alive" )]
            public sbyte Alive { get; set; }

            [Column( "talentpoints" )]
            public uint Talentpoints { get; set; }

            [Column( "current_power" )]
            public uint CurrentPower { get; set; }

            [Column( "current_hp" )]
            public uint CurrentHp { get; set; }

            [Column( "current_happiness" )]
            public uint CurrentHappiness { get; set; }

            [Column( "renamable" )]
            public uint Renamable { get; set; }

            [Column( "type" )]
            public uint Type { get; set; }

    }
}