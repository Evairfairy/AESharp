// This file was automatically generated

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Core.Database.Models.World
{
    public sealed class ItemProperties
    {
            [Key, Column( "entry" )]
            public uint Entry { get; set; }

            [Column( "class" )]
            public byte Class { get; set; }

            [Column( "subclass" )]
            public byte Subclass { get; set; }

            [Column( "field4" )]
            public int Field4 { get; set; }

            [Column( "name1" ), Required]
            public string Name1 { get; set; }

            [Column( "displayid" )]
            public uint Displayid { get; set; }

            [Column( "quality" )]
            public byte Quality { get; set; }

            [Column( "flags" )]
            public uint Flags { get; set; }

            [Column( "flags2" )]
            public uint Flags2 { get; set; }

            [Column( "buyprice" )]
            public uint Buyprice { get; set; }

            [Column( "sellprice" )]
            public uint Sellprice { get; set; }

            [Column( "inventorytype" )]
            public byte Inventorytype { get; set; }

            [Column( "allowableclass" )]
            public int Allowableclass { get; set; }

            [Column( "allowablerace" )]
            public int Allowablerace { get; set; }

            [Column( "itemlevel" )]
            public ushort Itemlevel { get; set; }

            [Column( "requiredlevel" )]
            public byte Requiredlevel { get; set; }

            [Column( "RequiredSkill" )]
            public ushort Requiredskill { get; set; }

            [Column( "RequiredSkillRank" )]
            public ushort Requiredskillrank { get; set; }

            [Column( "RequiredSpell" )]
            public uint Requiredspell { get; set; }

            [Column( "RequiredPlayerRank1" )]
            public uint Requiredplayerrank1 { get; set; }

            [Column( "RequiredPlayerRank2" )]
            public uint Requiredplayerrank2 { get; set; }

            [Column( "RequiredFaction" )]
            public ushort Requiredfaction { get; set; }

            [Column( "RequiredFactionStanding" )]
            public ushort Requiredfactionstanding { get; set; }

            [Column( "Unique" )]
            public int Unique { get; set; }

            [Column( "maxcount" )]
            public int Maxcount { get; set; }

            [Column( "ContainerSlots" )]
            public byte Containerslots { get; set; }

            [Column( "itemstatscount" )]
            public byte Itemstatscount { get; set; }

            [Column( "stat_type1" )]
            public byte StatType1 { get; set; }

            [Column( "stat_value1" )]
            public short StatValue1 { get; set; }

            [Column( "stat_type2" )]
            public byte StatType2 { get; set; }

            [Column( "stat_value2" )]
            public short StatValue2 { get; set; }

            [Column( "stat_type3" )]
            public byte StatType3 { get; set; }

            [Column( "stat_value3" )]
            public short StatValue3 { get; set; }

            [Column( "stat_type4" )]
            public byte StatType4 { get; set; }

            [Column( "stat_value4" )]
            public short StatValue4 { get; set; }

            [Column( "stat_type5" )]
            public byte StatType5 { get; set; }

            [Column( "stat_value5" )]
            public short StatValue5 { get; set; }

            [Column( "stat_type6" )]
            public byte StatType6 { get; set; }

            [Column( "stat_value6" )]
            public short StatValue6 { get; set; }

            [Column( "stat_type7" )]
            public byte StatType7 { get; set; }

            [Column( "stat_value7" )]
            public short StatValue7 { get; set; }

            [Column( "stat_type8" )]
            public byte StatType8 { get; set; }

            [Column( "stat_value8" )]
            public short StatValue8 { get; set; }

            [Column( "stat_type9" )]
            public byte StatType9 { get; set; }

            [Column( "stat_value9" )]
            public short StatValue9 { get; set; }

            [Column( "stat_type10" )]
            public byte StatType10 { get; set; }

            [Column( "stat_value10" )]
            public short StatValue10 { get; set; }

            [Column( "ScaledStatsDistributionId" )]
            public short Scaledstatsdistributionid { get; set; }

            [Column( "ScaledStatsDistributionFlags" )]
            public uint Scaledstatsdistributionflags { get; set; }

            [Column( "dmg_min1" )]
            public float DmgMin1 { get; set; }

            [Column( "dmg_max1" )]
            public float DmgMax1 { get; set; }

            [Column( "dmg_type1" )]
            public byte DmgType1 { get; set; }

            [Column( "dmg_min2" )]
            public float DmgMin2 { get; set; }

            [Column( "dmg_max2" )]
            public float DmgMax2 { get; set; }

            [Column( "dmg_type2" )]
            public byte DmgType2 { get; set; }

            [Column( "armor" )]
            public ushort Armor { get; set; }

            [Column( "holy_res" )]
            public byte HolyRes { get; set; }

            [Column( "fire_res" )]
            public byte FireRes { get; set; }

            [Column( "nature_res" )]
            public byte NatureRes { get; set; }

            [Column( "frost_res" )]
            public byte FrostRes { get; set; }

            [Column( "shadow_res" )]
            public byte ShadowRes { get; set; }

            [Column( "arcane_res" )]
            public byte ArcaneRes { get; set; }

            [Column( "delay" )]
            public ushort Delay { get; set; }

            [Column( "ammo_type" )]
            public byte AmmoType { get; set; }

            [Column( "range" )]
            public float Range { get; set; }

            [Column( "spellid_1" )]
            public int Spellid1 { get; set; }

            [Column( "spelltrigger_1" )]
            public byte Spelltrigger1 { get; set; }

            [Column( "spellcharges_1" )]
            public short Spellcharges1 { get; set; }

            [Column( "spellcooldown_1" )]
            public int Spellcooldown1 { get; set; }

            [Column( "spellcategory_1" )]
            public ushort Spellcategory1 { get; set; }

            [Column( "spellcategorycooldown_1" )]
            public int Spellcategorycooldown1 { get; set; }

            [Column( "spellid_2" )]
            public int Spellid2 { get; set; }

            [Column( "spelltrigger_2" )]
            public byte Spelltrigger2 { get; set; }

            [Column( "spellcharges_2" )]
            public short Spellcharges2 { get; set; }

            [Column( "spellcooldown_2" )]
            public int Spellcooldown2 { get; set; }

            [Column( "spellcategory_2" )]
            public ushort Spellcategory2 { get; set; }

            [Column( "spellcategorycooldown_2" )]
            public int Spellcategorycooldown2 { get; set; }

            [Column( "spellid_3" )]
            public int Spellid3 { get; set; }

            [Column( "spelltrigger_3" )]
            public byte Spelltrigger3 { get; set; }

            [Column( "spellcharges_3" )]
            public short Spellcharges3 { get; set; }

            [Column( "spellcooldown_3" )]
            public int Spellcooldown3 { get; set; }

            [Column( "spellcategory_3" )]
            public ushort Spellcategory3 { get; set; }

            [Column( "spellcategorycooldown_3" )]
            public int Spellcategorycooldown3 { get; set; }

            [Column( "spellid_4" )]
            public int Spellid4 { get; set; }

            [Column( "spelltrigger_4" )]
            public byte Spelltrigger4 { get; set; }

            [Column( "spellcharges_4" )]
            public short Spellcharges4 { get; set; }

            [Column( "spellcooldown_4" )]
            public int Spellcooldown4 { get; set; }

            [Column( "spellcategory_4" )]
            public ushort Spellcategory4 { get; set; }

            [Column( "spellcategorycooldown_4" )]
            public int Spellcategorycooldown4 { get; set; }

            [Column( "spellid_5" )]
            public int Spellid5 { get; set; }

            [Column( "spelltrigger_5" )]
            public byte Spelltrigger5 { get; set; }

            [Column( "spellcharges_5" )]
            public short Spellcharges5 { get; set; }

            [Column( "spellcooldown_5" )]
            public int Spellcooldown5 { get; set; }

            [Column( "spellcategory_5" )]
            public ushort Spellcategory5 { get; set; }

            [Column( "spellcategorycooldown_5" )]
            public int Spellcategorycooldown5 { get; set; }

            [Column( "bonding" )]
            public byte Bonding { get; set; }

            [Column( "description" ), Required]
            public string Description { get; set; }

            [Column( "page_id" )]
            public uint PageId { get; set; }

            [Column( "page_language" )]
            public byte PageLanguage { get; set; }

            [Column( "page_material" )]
            public byte PageMaterial { get; set; }

            [Column( "quest_id" )]
            public uint QuestId { get; set; }

            [Column( "lock_id" )]
            public uint LockId { get; set; }

            [Column( "lock_material" )]
            public sbyte LockMaterial { get; set; }

            [Column( "sheathID" )]
            public byte Sheathid { get; set; }

            [Column( "randomprop" )]
            public int Randomprop { get; set; }

            [Column( "randomsuffix" )]
            public uint Randomsuffix { get; set; }

            [Column( "block" )]
            public uint Block { get; set; }

            [Column( "itemset" )]
            public int Itemset { get; set; }

            [Column( "MaxDurability" )]
            public ushort Maxdurability { get; set; }

            [Column( "ZoneNameID" )]
            public uint Zonenameid { get; set; }

            [Column( "mapid" )]
            public short Mapid { get; set; }

            [Column( "bagfamily" )]
            public int Bagfamily { get; set; }

            [Column( "TotemCategory" )]
            public int Totemcategory { get; set; }

            [Column( "socket_color_1" )]
            public sbyte SocketColor1 { get; set; }

            [Column( "unk201_3" )]
            public int Unk2013 { get; set; }

            [Column( "socket_color_2" )]
            public sbyte SocketColor2 { get; set; }

            [Column( "unk201_5" )]
            public int Unk2015 { get; set; }

            [Column( "socket_color_3" )]
            public sbyte SocketColor3 { get; set; }

            [Column( "unk201_7" )]
            public int Unk2017 { get; set; }

            [Column( "socket_bonus" )]
            public int SocketBonus { get; set; }

            [Column( "GemProperties" )]
            public int Gemproperties { get; set; }

            [Column( "ReqDisenchantSkill" )]
            public short Reqdisenchantskill { get; set; }

            [Column( "ArmorDamageModifier" )]
            public float Armordamagemodifier { get; set; }

            [Column( "existingduration" )]
            public int Existingduration { get; set; }

            [Column( "ItemLimitCategoryId" )]
            public short Itemlimitcategoryid { get; set; }

            [Column( "HolidayId" )]
            public uint Holidayid { get; set; }

            [Column( "food_type" )]
            public ushort FoodType { get; set; }

    }
}