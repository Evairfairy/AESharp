// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.MySql.Models.Characters
{
    public sealed class CharactersInsertQueue
    {
            [Column( "insert_temp_guid" )]
            public uint InsertTempGuid { get; set; }

            [Column( "acct" )]
            public uint Acct { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

            [Column( "race" )]
            public byte Race { get; set; }

            [Column( "class" )]
            public byte Class { get; set; }

            [Column( "gender" )]
            public byte Gender { get; set; }

            [Column( "custom_faction" )]
            public int CustomFaction { get; set; }

            [Column( "level" )]
            public uint Level { get; set; }

            [Column( "xp" )]
            public uint Xp { get; set; }

            [Column( "exploration_data" ), Required]
            public string ExplorationData { get; set; }

            [Column( "skills" ), Required]
            public string Skills { get; set; }

            [Column( "watched_faction_index" )]
            public uint WatchedFactionIndex { get; set; }

            [Column( "selected_pvp_title" )]
            public uint SelectedPvpTitle { get; set; }

            [Column( "available_pvp_titles" )]
            public uint AvailablePvpTitles { get; set; }

            [Column( "gold" )]
            public uint Gold { get; set; }

            [Column( "ammo_id" )]
            public uint AmmoId { get; set; }

            [Column( "available_prof_points" )]
            public uint AvailableProfPoints { get; set; }

            [Column( "available_talent_points" )]
            public uint AvailableTalentPoints { get; set; }

            [Column( "current_hp" )]
            public uint CurrentHp { get; set; }

            [Column( "current_power" )]
            public uint CurrentPower { get; set; }

            [Column( "pvprank" )]
            public byte Pvprank { get; set; }

            [Column( "bytes" )]
            public uint Bytes { get; set; }

            [Column( "bytes2" )]
            public uint Bytes2 { get; set; }

            [Column( "player_flags" )]
            public uint PlayerFlags { get; set; }

            [Column( "player_bytes" )]
            public uint PlayerBytes { get; set; }

            [Column( "positionX" )]
            public float Positionx { get; set; }

            [Column( "positionY" )]
            public float Positiony { get; set; }

            [Column( "positionZ" )]
            public float Positionz { get; set; }

            [Column( "orientation" )]
            public float Orientation { get; set; }

            [Column( "mapId" )]
            public uint Mapid { get; set; }

            [Column( "zoneId" )]
            public uint Zoneid { get; set; }

            [Column( "taximask" ), Required]
            public string Taximask { get; set; }

            [Column( "banned" )]
            public int Banned { get; set; }

            [Column( "banReason" ), Required]
            public string Banreason { get; set; }

            [Column( "timestamp" )]
            public int Timestamp { get; set; }

            [Column( "online" )]
            public int Online { get; set; }

            [Column( "bindpositionX" )]
            public float Bindpositionx { get; set; }

            [Column( "bindpositionY" )]
            public float Bindpositiony { get; set; }

            [Column( "bindpositionZ" )]
            public float Bindpositionz { get; set; }

            [Column( "bindmapId" )]
            public uint Bindmapid { get; set; }

            [Column( "bindzoneId" )]
            public uint Bindzoneid { get; set; }

            [Column( "isResting" )]
            public byte Isresting { get; set; }

            [Column( "restState" )]
            public byte Reststate { get; set; }

            [Column( "restTime" )]
            public uint Resttime { get; set; }

            [Column( "playedtime" ), Required]
            public string Playedtime { get; set; }

            [Column( "deathstate" )]
            public uint Deathstate { get; set; }

            [Column( "TalentResetTimes" )]
            public uint Talentresettimes { get; set; }

            [Column( "first_login" )]
            public byte FirstLogin { get; set; }

            [Column( "forced_rename_pending" )]
            public byte ForcedRenamePending { get; set; }

            [Column( "publicNote" ), Required]
            public string Publicnote { get; set; }

            [Column( "officerNote" ), Required]
            public string Officernote { get; set; }

            [Column( "guildid" )]
            public uint Guildid { get; set; }

            [Column( "guildRank" )]
            public uint Guildrank { get; set; }

            [Column( "arenaPoints" )]
            public int Arenapoints { get; set; }

            [Column( "totalstableslots" )]
            public uint Totalstableslots { get; set; }

            [Column( "instance_id" )]
            public uint InstanceId { get; set; }

            [Column( "entrypointmap" )]
            public uint Entrypointmap { get; set; }

            [Column( "entrypointx" )]
            public float Entrypointx { get; set; }

            [Column( "entrypointy" )]
            public float Entrypointy { get; set; }

            [Column( "entrypointz" )]
            public float Entrypointz { get; set; }

            [Column( "entrypointo" )]
            public float Entrypointo { get; set; }

            [Column( "entrypointinstance" )]
            public uint Entrypointinstance { get; set; }

            [Column( "taxi_path" )]
            public uint TaxiPath { get; set; }

            [Column( "taxi_lastnode" )]
            public uint TaxiLastnode { get; set; }

            [Column( "taxi_mountid" )]
            public uint TaxiMountid { get; set; }

            [Column( "transporter" )]
            public uint Transporter { get; set; }

            [Column( "transporter_xdiff" )]
            public float TransporterXdiff { get; set; }

            [Column( "transporter_ydiff" )]
            public float TransporterYdiff { get; set; }

            [Column( "transporter_zdiff" )]
            public float TransporterZdiff { get; set; }

            [Column( "spells" ), Required]
            public string Spells { get; set; }

            [Column( "deleted_spells" ), Required]
            public string DeletedSpells { get; set; }

            [Column( "reputation" ), Required]
            public string Reputation { get; set; }

            [Column( "actions" ), Required]
            public string Actions { get; set; }

            [Column( "auras" ), Required]
            public string Auras { get; set; }

            [Column( "finished_quests" ), Required]
            public string FinishedQuests { get; set; }

            [Column( "honorPointsToAdd" )]
            public int Honorpointstoadd { get; set; }

            [Column( "killsToday" )]
            public uint Killstoday { get; set; }

            [Column( "killsYesterday" )]
            public uint Killsyesterday { get; set; }

            [Column( "killsLifeTime" )]
            public uint Killslifetime { get; set; }

            [Column( "honorToday" )]
            public uint Honortoday { get; set; }

            [Column( "honorYesterday" )]
            public uint Honoryesterday { get; set; }

            [Column( "honorPoints" )]
            public uint Honorpoints { get; set; }

            [Column( "difficulty" )]
            public uint Difficulty { get; set; }

    }
}