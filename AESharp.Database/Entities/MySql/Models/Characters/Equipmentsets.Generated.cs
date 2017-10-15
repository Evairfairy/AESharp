// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class EquipmentSets
    {
            [Column( "ownerguid" )]
            public uint Ownerguid { get; set; }

            [Column( "setGUID" )]
            public uint Setguid { get; set; }

            [Column( "setid" )]
            public uint Setid { get; set; }

            [Column( "setname" ), Required]
            public string Setname { get; set; }

            [Column( "iconname" ), Required]
            public string Iconname { get; set; }

            [Column( "head" )]
            public uint Head { get; set; }

            [Column( "neck" )]
            public uint Neck { get; set; }

            [Column( "shoulders" )]
            public uint Shoulders { get; set; }

            [Column( "body" )]
            public uint Body { get; set; }

            [Column( "chest" )]
            public uint Chest { get; set; }

            [Column( "waist" )]
            public uint Waist { get; set; }

            [Column( "legs" )]
            public uint Legs { get; set; }

            [Column( "feet" )]
            public uint Feet { get; set; }

            [Column( "wrists" )]
            public uint Wrists { get; set; }

            [Column( "hands" )]
            public uint Hands { get; set; }

            [Column( "finger1" )]
            public uint Finger1 { get; set; }

            [Column( "finger2" )]
            public uint Finger2 { get; set; }

            [Column( "trinket1" )]
            public uint Trinket1 { get; set; }

            [Column( "trinket2" )]
            public uint Trinket2 { get; set; }

            [Column( "back" )]
            public uint Back { get; set; }

            [Column( "mainhand" )]
            public uint Mainhand { get; set; }

            [Column( "offhand" )]
            public uint Offhand { get; set; }

            [Column( "ranged" )]
            public uint Ranged { get; set; }

            [Column( "tabard" )]
            public uint Tabard { get; set; }

    }
}