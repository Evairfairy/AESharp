// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.World
{
    public sealed class CreatureProperties
    {
            [Key, Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "killcredit1" )]
            public int Killcredit1 { get; set; }

            [Column( "killcredit2" )]
            public int Killcredit2 { get; set; }

            [Column( "male_displayid" )]
            public int MaleDisplayid { get; set; }

            [Column( "female_displayid" )]
            public int FemaleDisplayid { get; set; }

            [Column( "male_displayid2" )]
            public int MaleDisplayid2 { get; set; }

            [Column( "female_displayid2" )]
            public int FemaleDisplayid2 { get; set; }

            [Column( "name" )]
            public string Name { get; set; }

            [Column( "subname" )]
            public string Subname { get; set; }

            [Column( "info_str" )]
            public string InfoStr { get; set; }

            [Column( "flags1" )]
            public int Flags1 { get; set; }

            [Column( "type" )]
            public int Type { get; set; }

            [Column( "family" )]
            public int Family { get; set; }

            [Column( "rank" )]
            public int Rank { get; set; }

            [Column( "encounter" )]
            public int Encounter { get; set; }

            [Column( "unknown_float1" )]
            public float UnknownFloat1 { get; set; }

            [Column( "unknown_float2" )]
            public float UnknownFloat2 { get; set; }

            [Column( "leader" )]
            public sbyte Leader { get; set; }

            [Column( "minlevel" )]
            public uint Minlevel { get; set; }

            [Column( "maxlevel" )]
            public uint Maxlevel { get; set; }

            [Column( "faction" )]
            public uint Faction { get; set; }

            [Column( "minhealth" )]
            public uint Minhealth { get; set; }

            [Column( "maxhealth" )]
            public uint Maxhealth { get; set; }

            [Column( "mana" )]
            public uint Mana { get; set; }

            [Column( "scale" )]
            public float Scale { get; set; }

            [Column( "npcflags" )]
            public uint Npcflags { get; set; }

            [Column( "attacktime" )]
            public uint Attacktime { get; set; }

            [Column( "attacktype" )]
            public sbyte Attacktype { get; set; }

            [Column( "mindamage" )]
            public float Mindamage { get; set; }

            [Column( "maxdamage" )]
            public float Maxdamage { get; set; }

            [Column( "can_ranged" )]
            public uint CanRanged { get; set; }

            [Column( "rangedattacktime" )]
            public uint Rangedattacktime { get; set; }

            [Column( "rangedmindamage" )]
            public float Rangedmindamage { get; set; }

            [Column( "rangedmaxdamage" )]
            public float Rangedmaxdamage { get; set; }

            [Column( "respawntime" )]
            public uint Respawntime { get; set; }

            [Column( "armor" )]
            public uint Armor { get; set; }

            // Holy
            [Column( "resistance1" )]
            public ushort Resistance1 { get; set; }

            // Fire
            [Column( "resistance2" )]
            public ushort Resistance2 { get; set; }

            // Nature
            [Column( "resistance3" )]
            public ushort Resistance3 { get; set; }

            // Frost
            [Column( "resistance4" )]
            public ushort Resistance4 { get; set; }

            // Shadow
            [Column( "resistance5" )]
            public ushort Resistance5 { get; set; }

            // Arcane
            [Column( "resistance6" )]
            public ushort Resistance6 { get; set; }

            [Column( "combat_reach" )]
            public float CombatReach { get; set; }

            [Column( "bounding_radius" )]
            public float BoundingRadius { get; set; }

            [Column( "auras" ), Required]
            public string Auras { get; set; }

            [Column( "boss" )]
            public uint Boss { get; set; }

            [Column( "money" )]
            public int Money { get; set; }

            [Column( "invisibility_type" )]
            public uint InvisibilityType { get; set; }

            [Column( "walk_speed" )]
            public float WalkSpeed { get; set; }

            [Column( "run_speed" )]
            public float RunSpeed { get; set; }

            [Column( "fly_speed" )]
            public float FlySpeed { get; set; }

            [Column( "extra_a9_flags" )]
            public int ExtraA9Flags { get; set; }

            [Column( "spell1" )]
            public uint Spell1 { get; set; }

            [Column( "spell2" )]
            public uint Spell2 { get; set; }

            [Column( "spell3" )]
            public uint Spell3 { get; set; }

            [Column( "spell4" )]
            public uint Spell4 { get; set; }

            [Column( "spell5" )]
            public uint Spell5 { get; set; }

            [Column( "spell6" )]
            public uint Spell6 { get; set; }

            [Column( "spell7" )]
            public uint Spell7 { get; set; }

            [Column( "spell8" )]
            public uint Spell8 { get; set; }

            [Column( "spell_flags" )]
            public int SpellFlags { get; set; }

            [Column( "modImmunities" )]
            public uint Modimmunities { get; set; }

            [Column( "isTrainingDummy" )]
            public uint Istrainingdummy { get; set; }

            [Column( "guardtype" )]
            public uint Guardtype { get; set; }

            [Column( "summonguard" )]
            public uint Summonguard { get; set; }

            [Column( "spelldataid" )]
            public uint Spelldataid { get; set; }

            [Column( "vehicleid" )]
            public uint Vehicleid { get; set; }

            [Column( "rooted" )]
            public uint Rooted { get; set; }

            [Column( "questitem1" )]
            public int Questitem1 { get; set; }

            [Column( "questitem2" )]
            public int Questitem2 { get; set; }

            [Column( "questitem3" )]
            public int Questitem3 { get; set; }

            [Column( "questitem4" )]
            public int Questitem4 { get; set; }

            [Column( "questitem5" )]
            public int Questitem5 { get; set; }

            [Column( "questitem6" )]
            public int Questitem6 { get; set; }

            [Column( "waypointid" )]
            public int Waypointid { get; set; }

    }
}