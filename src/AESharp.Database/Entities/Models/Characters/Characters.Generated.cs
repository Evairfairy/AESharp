// This file was automatically generated

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AESharp.Database.Entities.Models.Characters
{
    public sealed class Characters
    {
            [Column( "guid" )]
            public uint Guid { get; set; }

            [Column( "acct" )]
            public uint Acct { get; set; }

            [Column( "name" ), Required]
            public string Name { get; set; }

            [Column( "race" )]
            public short Race { get; set; }

            [Column( "class" )]
            public short Class { get; set; }

            [Column( "gender" )]
            public sbyte Gender { get; set; }

            [Column( "custom_faction" )]
            public int CustomFaction { get; set; }

            [Column( "level" )]
            public int Level { get; set; }

            [Column( "xp" )]
            public int Xp { get; set; }

            [Column( "active_cheats" )]
            public uint ActiveCheats { get; set; }

            [Column( "exploration_data" ), Required]
            public string ExplorationData { get; set; }

            [Column( "watched_faction_index" )]
            public long WatchedFactionIndex { get; set; }

            [Column( "selected_pvp_title" )]
            public int SelectedPvpTitle { get; set; }

            [Column( "available_pvp_titles" )]
            public ulong AvailablePvpTitles { get; set; }

            [Column( "available_pvp_titles1" )]
            public long AvailablePvpTitles1 { get; set; }

            [Column( "available_pvp_titles2" )]
            public ulong AvailablePvpTitles2 { get; set; }

            [Column( "gold" )]
            public int Gold { get; set; }

            [Column( "ammo_id" )]
            public int AmmoId { get; set; }

            [Column( "available_prof_points" )]
            public int AvailableProfPoints { get; set; }

            [Column( "current_hp" )]
            public int CurrentHp { get; set; }

            [Column( "current_power" )]
            public int CurrentPower { get; set; }

            [Column( "pvprank" )]
            public int Pvprank { get; set; }

            [Column( "bytes" )]
            public int Bytes { get; set; }

            [Column( "bytes2" )]
            public int Bytes2 { get; set; }

            [Column( "player_flags" )]
            public int PlayerFlags { get; set; }

            [Column( "player_bytes" )]
            public int PlayerBytes { get; set; }

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
            public uint Banned { get; set; }

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
            public int Isresting { get; set; }

            [Column( "restState" )]
            public int Reststate { get; set; }

            [Column( "restTime" )]
            public int Resttime { get; set; }

            [Column( "playedtime" ), Required]
            public string Playedtime { get; set; }

            [Column( "deathstate" )]
            public int Deathstate { get; set; }

            [Column( "TalentResetTimes" )]
            public int Talentresettimes { get; set; }

            [Column( "first_login" )]
            public sbyte FirstLogin { get; set; }

            [Column( "login_flags" )]
            public uint LoginFlags { get; set; }

            [Column( "arenaPoints" )]
            public int Arenapoints { get; set; }

            [Column( "totalstableslots" )]
            public uint Totalstableslots { get; set; }

            [Column( "instance_id" )]
            public int InstanceId { get; set; }

            [Column( "entrypointmap" )]
            public int Entrypointmap { get; set; }

            [Column( "entrypointx" )]
            public float Entrypointx { get; set; }

            [Column( "entrypointy" )]
            public float Entrypointy { get; set; }

            [Column( "entrypointz" )]
            public float Entrypointz { get; set; }

            [Column( "entrypointo" )]
            public float Entrypointo { get; set; }

            [Column( "entrypointinstance" )]
            public int Entrypointinstance { get; set; }

            [Column( "taxi_path" )]
            public int TaxiPath { get; set; }

            [Column( "taxi_lastnode" )]
            public int TaxiLastnode { get; set; }

            [Column( "taxi_mountid" )]
            public int TaxiMountid { get; set; }

            [Column( "transporter" )]
            public int Transporter { get; set; }

            [Column( "transporter_xdiff" )]
            public float TransporterXdiff { get; set; }

            [Column( "transporter_ydiff" )]
            public float TransporterYdiff { get; set; }

            [Column( "transporter_zdiff" )]
            public float TransporterZdiff { get; set; }

            [Column( "transporter_odiff" )]
            public float TransporterOdiff { get; set; }

            [Column( "actions1" ), Required]
            public string Actions1 { get; set; }

            [Column( "actions2" ), Required]
            public string Actions2 { get; set; }

            [Column( "auras" ), Required]
            public string Auras { get; set; }

            [Column( "finished_quests" ), Required]
            public string FinishedQuests { get; set; }

            [Column( "finisheddailies" ), Required]
            public string Finisheddailies { get; set; }

            [Column( "honorRolloverTime" )]
            public int Honorrollovertime { get; set; }

            [Column( "killsToday" )]
            public int Killstoday { get; set; }

            [Column( "killsYesterday" )]
            public int Killsyesterday { get; set; }

            [Column( "killsLifeTime" )]
            public int Killslifetime { get; set; }

            [Column( "honorToday" )]
            public int Honortoday { get; set; }

            [Column( "honorYesterday" )]
            public int Honoryesterday { get; set; }

            [Column( "honorPoints" )]
            public int Honorpoints { get; set; }

            [Column( "drunkValue" )]
            public int Drunkvalue { get; set; }

            [Column( "glyphs1" ), Required]
            public string Glyphs1 { get; set; }

            [Column( "talents1" ), Required]
            public string Talents1 { get; set; }

            [Column( "glyphs2" ), Required]
            public string Glyphs2 { get; set; }

            [Column( "talents2" ), Required]
            public string Talents2 { get; set; }

            [Column( "numspecs" )]
            public int Numspecs { get; set; }

            [Column( "currentspec" )]
            public int Currentspec { get; set; }

            [Column( "talentpoints" ), Required]
            public string Talentpoints { get; set; }

            [Column( "phase" )]
            public uint Phase { get; set; }

            [Column( "CanGainXp" )]
            public uint Cangainxp { get; set; }

            [Column( "data" )]
            public string Data { get; set; }

            [Column( "resettalents" )]
            public uint Resettalents { get; set; }

            // Boolean already done a daily rbg?
            [Column( "rbg_daily" )]
            public sbyte RbgDaily { get; set; }

            [Column( "dungeon_difficulty" )]
            public ushort DungeonDifficulty { get; set; }

            [Column( "raid_difficulty" )]
            public ushort RaidDifficulty { get; set; }

    }
}