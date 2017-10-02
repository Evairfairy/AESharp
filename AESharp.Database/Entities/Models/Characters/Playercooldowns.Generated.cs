// This file was automatically generated

using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class PlayerCooldowns
    {
            [Column( "player_guid" )]
            public int PlayerGuid { get; set; }

            // 0 is spell, 1 is item, 2 is spell category
            [Column( "cooldown_type" )]
            public int CooldownType { get; set; }

            // spellid/itemid/category
            [Column( "cooldown_misc" )]
            public int CooldownMisc { get; set; }

            // expiring time in unix epoch format
            [Column( "cooldown_expire_time" )]
            public int CooldownExpireTime { get; set; }

            // spell that cast it
            [Column( "cooldown_spellid" )]
            public int CooldownSpellid { get; set; }

            // item that cast it
            [Column( "cooldown_itemid" )]
            public int CooldownItemid { get; set; }

    }
}