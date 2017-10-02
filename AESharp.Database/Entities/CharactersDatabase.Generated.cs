// This file was automatically generated

using System;
using AESharp.Database.Configuration;
using AESharp.Database.Entities.Models.Characters;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace AESharp.Database.Entities
{
    internal sealed class CharactersDatabase : DbContext
    {
        private readonly DatabaseSettings Settings;

        public DbSet<AccountData> AccountData { get; set; }
        public DbSet<AccountForcedPermissions> AccountForcedPermissions { get; set; }
        public DbSet<ArenaTeams> Arenateams { get; set; }
        public DbSet<Auctions> Auctions { get; set; }
        public DbSet<BannedNames> BannedNames { get; set; }
        public DbSet<CalendarEvents> CalendarEvents { get; set; }
        public DbSet<CalendarInvites> CalendarInvites { get; set; }
        public DbSet<CharacterAchievement> CharacterAchievement { get; set; }
        public DbSet<CharacterAchievementProgress> CharacterAchievementProgress { get; set; }
        public DbSet<CharacterDbVersion> CharacterDbVersion { get; set; }
        public DbSet<Characters> Characters { get; set; }
        public DbSet<CharactersInsertQueue> CharactersInsertQueue { get; set; }
        public DbSet<Charters> Charters { get; set; }
        public DbSet<ClientAddons> Clientaddons { get; set; }
        public DbSet<CommandOverrides> CommandOverrides { get; set; }
        public DbSet<Corpses> Corpses { get; set; }
        public DbSet<EquipmentSets> Equipmentsets { get; set; }
        public DbSet<EventSave> EventSave { get; set; }
        public DbSet<GmSurvey> GmSurvey { get; set; }
        public DbSet<GmSurveyAnswers> GmSurveyAnswers { get; set; }
        public DbSet<GmTickets> GmTickets { get; set; }
        public DbSet<Groups> Groups { get; set; }
        public DbSet<GuildBankItems> GuildBankitems { get; set; }
        public DbSet<GuildBankLogs> GuildBanklogs { get; set; }
        public DbSet<GuildBankTabs> GuildBanktabs { get; set; }
        public DbSet<GuildData> GuildData { get; set; }
        public DbSet<GuildLogs> GuildLogs { get; set; }
        public DbSet<GuildRanks> GuildRanks { get; set; }
        public DbSet<Guilds> Guilds { get; set; }
        public DbSet<InstanceIds> Instanceids { get; set; }
        public DbSet<Instances> Instances { get; set; }
        public DbSet<LagReports> LagReports { get; set; }
        public DbSet<LfgData> LfgData { get; set; }
        public DbSet<Mailbox> Mailbox { get; set; }
        public DbSet<MailboxInsertQueue> MailboxInsertQueue { get; set; }
        public DbSet<PlayerBugReports> Playerbugreports { get; set; }
        public DbSet<PlayerCooldowns> Playercooldowns { get; set; }
        public DbSet<PlayerDeletedSpells> Playerdeletedspells { get; set; }
        public DbSet<PlayerItems> Playeritems { get; set; }
        public DbSet<PlayerItemsInsertQueue> PlayeritemsInsertQueue { get; set; }
        public DbSet<PlayerPets> Playerpets { get; set; }
        public DbSet<PlayerPetSpells> Playerpetspells { get; set; }
        public DbSet<PlayerReputations> Playerreputations { get; set; }
        public DbSet<PlayerSkills> Playerskills { get; set; }
        public DbSet<PlayerSpells> Playerspells { get; set; }
        public DbSet<PlayerSummons> Playersummons { get; set; }
        public DbSet<PlayerSummonSpells> Playersummonspells { get; set; }
        public DbSet<QuestLog> Questlog { get; set; }
        public DbSet<ServerSettings> ServerSettings { get; set; }
        public DbSet<SocialFriends> SocialFriends { get; set; }
        public DbSet<SocialIgnores> SocialIgnores { get; set; }
        public DbSet<Tutorials> Tutorials { get; set; }

        public CharactersDatabase( DatabaseSettings settings )
        {
            if( settings == null )
                throw new ArgumentNullException( nameof( settings ) );

            this.Settings = settings;
        }

        protected override void OnConfiguring( DbContextOptionsBuilder optionsBuilder )
        {
            switch( this.Settings.Driver )
            {
                case DatabaseDriver.MySql:
                {
                    MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
                    {
                        Server = this.Settings.Hostname,
                        Database = this.Settings.Databases.CharactersDatabase,
                        Port = this.Settings.Port,
                        UserID = this.Settings.Username,
                        Password = this.Settings.Password
                    };

                    optionsBuilder.UseMySQL( builder.ToString() );
                    break;
                }

                default:
                    throw new NotImplementedException( this.Settings.Driver.ToString() );
            }
        }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            modelBuilder.Entity<AccountData>().ToTable( "account_data" );
            modelBuilder.Entity<AccountData>().Property( p => p.Acct ).HasColumnName( "acct" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig0 ).HasColumnName( "uiconfig0" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig1 ).HasColumnName( "uiconfig1" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig2 ).HasColumnName( "uiconfig2" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig3 ).HasColumnName( "uiconfig3" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig4 ).HasColumnName( "uiconfig4" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig5 ).HasColumnName( "uiconfig5" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig6 ).HasColumnName( "uiconfig6" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig7 ).HasColumnName( "uiconfig7" );
            modelBuilder.Entity<AccountData>().Property( p => p.Uiconfig8 ).HasColumnName( "uiconfig8" );

            modelBuilder.Entity<AccountForcedPermissions>().ToTable( "account_forced_permissions" );
            modelBuilder.Entity<AccountForcedPermissions>().Property( p => p.Login ).HasColumnName( "login" );
            modelBuilder.Entity<AccountForcedPermissions>().Property( p => p.Permissions ).HasColumnName( "permissions" );

            modelBuilder.Entity<ArenaTeams>().ToTable( "arenateams" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Leader ).HasColumnName( "leader" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Emblemstyle ).HasColumnName( "emblemstyle" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Emblemcolour ).HasColumnName( "emblemcolour" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Borderstyle ).HasColumnName( "borderstyle" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Bordercolour ).HasColumnName( "bordercolour" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Backgroundcolour ).HasColumnName( "backgroundcolour" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Rating ).HasColumnName( "rating" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Data ).HasColumnName( "data" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.Ranking ).HasColumnName( "ranking" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData1 ).HasColumnName( "player_data1" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData2 ).HasColumnName( "player_data2" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData3 ).HasColumnName( "player_data3" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData4 ).HasColumnName( "player_data4" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData5 ).HasColumnName( "player_data5" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData6 ).HasColumnName( "player_data6" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData7 ).HasColumnName( "player_data7" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData8 ).HasColumnName( "player_data8" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData9 ).HasColumnName( "player_data9" );
            modelBuilder.Entity<ArenaTeams>().Property( p => p.PlayerData10 ).HasColumnName( "player_data10" );

            modelBuilder.Entity<Auctions>().ToTable( "auctions" );
            modelBuilder.Entity<Auctions>().HasKey( e => new { e.Auctionid } );
            modelBuilder.Entity<Auctions>().Property( p => p.Auctionid ).HasColumnName( "auctionId" );
            modelBuilder.Entity<Auctions>().Property( p => p.Auctionhouse ).HasColumnName( "auctionhouse" );
            modelBuilder.Entity<Auctions>().HasIndex( e => e.Auctionhouse );
            modelBuilder.Entity<Auctions>().Property( p => p.Item ).HasColumnName( "item" );
            modelBuilder.Entity<Auctions>().Property( p => p.Owner ).HasColumnName( "owner" );
            modelBuilder.Entity<Auctions>().Property( p => p.Startbid ).HasColumnName( "startbid" );
            modelBuilder.Entity<Auctions>().Property( p => p.Buyout ).HasColumnName( "buyout" );
            modelBuilder.Entity<Auctions>().Property( p => p.Time ).HasColumnName( "time" );
            modelBuilder.Entity<Auctions>().Property( p => p.Bidder ).HasColumnName( "bidder" );
            modelBuilder.Entity<Auctions>().Property( p => p.Bid ).HasColumnName( "bid" );
            modelBuilder.Entity<Auctions>().Property( p => p.Deposit ).HasColumnName( "deposit" );

            modelBuilder.Entity<BannedNames>().ToTable( "banned_names" );
            modelBuilder.Entity<BannedNames>().Property( p => p.Name ).HasColumnName( "name" );

            modelBuilder.Entity<CalendarEvents>().ToTable( "calendar_events" );
            modelBuilder.Entity<CalendarEvents>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<CalendarEvents>().Property( p => p.Creator ).HasColumnName( "creator" );
            modelBuilder.Entity<CalendarEvents>().Property( p => p.Title ).HasColumnName( "title" );
            modelBuilder.Entity<CalendarEvents>().Property( p => p.Description ).HasColumnName( "description" );
            modelBuilder.Entity<CalendarEvents>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<CalendarEvents>().Property( p => p.Dungeon ).HasColumnName( "dungeon" );
            modelBuilder.Entity<CalendarEvents>().Property( p => p.Date ).HasColumnName( "date" );
            modelBuilder.Entity<CalendarEvents>().Property( p => p.Flags ).HasColumnName( "flags" );

            modelBuilder.Entity<CalendarInvites>().ToTable( "calendar_invites" );
            modelBuilder.Entity<CalendarInvites>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<CalendarInvites>().Property( p => p.Event ).HasColumnName( "event" );
            modelBuilder.Entity<CalendarInvites>().Property( p => p.Invitee ).HasColumnName( "invitee" );
            modelBuilder.Entity<CalendarInvites>().Property( p => p.Sender ).HasColumnName( "sender" );
            modelBuilder.Entity<CalendarInvites>().Property( p => p.Status ).HasColumnName( "status" );
            modelBuilder.Entity<CalendarInvites>().Property( p => p.Statustime ).HasColumnName( "statustime" );
            modelBuilder.Entity<CalendarInvites>().Property( p => p.Rank ).HasColumnName( "rank" );
            modelBuilder.Entity<CalendarInvites>().Property( p => p.Text ).HasColumnName( "text" );

            modelBuilder.Entity<CharacterAchievement>().ToTable( "character_achievement" );
            modelBuilder.Entity<CharacterAchievement>().HasKey( e => new { e.Guid, e.Achievement } );
            modelBuilder.Entity<CharacterAchievement>().Property( p => p.Guid ).HasColumnName( "guid" );
            modelBuilder.Entity<CharacterAchievement>().Property( p => p.Achievement ).HasColumnName( "achievement" );
            modelBuilder.Entity<CharacterAchievement>().Property( p => p.Date ).HasColumnName( "date" );

            modelBuilder.Entity<CharacterAchievementProgress>().ToTable( "character_achievement_progress" );
            modelBuilder.Entity<CharacterAchievementProgress>().HasKey( e => new { e.Guid, e.Criteria } );
            modelBuilder.Entity<CharacterAchievementProgress>().Property( p => p.Guid ).HasColumnName( "guid" );
            modelBuilder.Entity<CharacterAchievementProgress>().Property( p => p.Criteria ).HasColumnName( "criteria" );
            modelBuilder.Entity<CharacterAchievementProgress>().Property( p => p.Counter ).HasColumnName( "counter" );
            modelBuilder.Entity<CharacterAchievementProgress>().Property( p => p.Date ).HasColumnName( "date" );

            modelBuilder.Entity<CharacterDbVersion>().ToTable( "character_db_version" );
            modelBuilder.Entity<CharacterDbVersion>().Property( p => p.Lastupdate ).HasColumnName( "LastUpdate" );

            modelBuilder.Entity<Characters>().ToTable( "characters" );
            modelBuilder.Entity<Characters>().HasKey( e => new { e.Guid } );
            modelBuilder.Entity<Characters>().Property( p => p.Guid ).HasColumnName( "guid" );
            modelBuilder.Entity<Characters>().Property( p => p.Acct ).HasColumnName( "acct" );
            modelBuilder.Entity<Characters>().HasIndex( e => e.Acct );
            modelBuilder.Entity<Characters>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<Characters>().HasIndex( e => e.Name );
            modelBuilder.Entity<Characters>().Property( p => p.Race ).HasColumnName( "race" );
            modelBuilder.Entity<Characters>().Property( p => p.Class ).HasColumnName( "class" );
            modelBuilder.Entity<Characters>().Property( p => p.Gender ).HasColumnName( "gender" );
            modelBuilder.Entity<Characters>().Property( p => p.CustomFaction ).HasColumnName( "custom_faction" );
            modelBuilder.Entity<Characters>().Property( p => p.Level ).HasColumnName( "level" );
            modelBuilder.Entity<Characters>().Property( p => p.Xp ).HasColumnName( "xp" );
            modelBuilder.Entity<Characters>().Property( p => p.ActiveCheats ).HasColumnName( "active_cheats" );
            modelBuilder.Entity<Characters>().Property( p => p.ExplorationData ).HasColumnName( "exploration_data" );
            modelBuilder.Entity<Characters>().Property( p => p.WatchedFactionIndex ).HasColumnName( "watched_faction_index" );
            modelBuilder.Entity<Characters>().Property( p => p.SelectedPvpTitle ).HasColumnName( "selected_pvp_title" );
            modelBuilder.Entity<Characters>().Property( p => p.AvailablePvpTitles ).HasColumnName( "available_pvp_titles" );
            modelBuilder.Entity<Characters>().Property( p => p.AvailablePvpTitles1 ).HasColumnName( "available_pvp_titles1" );
            modelBuilder.Entity<Characters>().Property( p => p.AvailablePvpTitles2 ).HasColumnName( "available_pvp_titles2" );
            modelBuilder.Entity<Characters>().Property( p => p.Gold ).HasColumnName( "gold" );
            modelBuilder.Entity<Characters>().Property( p => p.AmmoId ).HasColumnName( "ammo_id" );
            modelBuilder.Entity<Characters>().Property( p => p.AvailableProfPoints ).HasColumnName( "available_prof_points" );
            modelBuilder.Entity<Characters>().Property( p => p.CurrentHp ).HasColumnName( "current_hp" );
            modelBuilder.Entity<Characters>().Property( p => p.CurrentPower ).HasColumnName( "current_power" );
            modelBuilder.Entity<Characters>().Property( p => p.Pvprank ).HasColumnName( "pvprank" );
            modelBuilder.Entity<Characters>().Property( p => p.Bytes ).HasColumnName( "bytes" );
            modelBuilder.Entity<Characters>().Property( p => p.Bytes2 ).HasColumnName( "bytes2" );
            modelBuilder.Entity<Characters>().Property( p => p.PlayerFlags ).HasColumnName( "player_flags" );
            modelBuilder.Entity<Characters>().Property( p => p.PlayerBytes ).HasColumnName( "player_bytes" );
            modelBuilder.Entity<Characters>().Property( p => p.Positionx ).HasColumnName( "positionX" );
            modelBuilder.Entity<Characters>().Property( p => p.Positiony ).HasColumnName( "positionY" );
            modelBuilder.Entity<Characters>().Property( p => p.Positionz ).HasColumnName( "positionZ" );
            modelBuilder.Entity<Characters>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<Characters>().Property( p => p.Mapid ).HasColumnName( "mapId" );
            modelBuilder.Entity<Characters>().Property( p => p.Zoneid ).HasColumnName( "zoneId" );
            modelBuilder.Entity<Characters>().Property( p => p.Taximask ).HasColumnName( "taximask" );
            modelBuilder.Entity<Characters>().Property( p => p.Banned ).HasColumnName( "banned" );
            modelBuilder.Entity<Characters>().HasIndex( e => e.Banned );
            modelBuilder.Entity<Characters>().Property( p => p.Banreason ).HasColumnName( "banReason" );
            modelBuilder.Entity<Characters>().Property( p => p.Timestamp ).HasColumnName( "timestamp" );
            modelBuilder.Entity<Characters>().Property( p => p.Online ).HasColumnName( "online" );
            modelBuilder.Entity<Characters>().HasIndex( e => e.Online );
            modelBuilder.Entity<Characters>().Property( p => p.Bindpositionx ).HasColumnName( "bindpositionX" );
            modelBuilder.Entity<Characters>().Property( p => p.Bindpositiony ).HasColumnName( "bindpositionY" );
            modelBuilder.Entity<Characters>().Property( p => p.Bindpositionz ).HasColumnName( "bindpositionZ" );
            modelBuilder.Entity<Characters>().Property( p => p.Bindmapid ).HasColumnName( "bindmapId" );
            modelBuilder.Entity<Characters>().Property( p => p.Bindzoneid ).HasColumnName( "bindzoneId" );
            modelBuilder.Entity<Characters>().Property( p => p.Isresting ).HasColumnName( "isResting" );
            modelBuilder.Entity<Characters>().Property( p => p.Reststate ).HasColumnName( "restState" );
            modelBuilder.Entity<Characters>().Property( p => p.Resttime ).HasColumnName( "restTime" );
            modelBuilder.Entity<Characters>().Property( p => p.Playedtime ).HasColumnName( "playedtime" );
            modelBuilder.Entity<Characters>().Property( p => p.Deathstate ).HasColumnName( "deathstate" );
            modelBuilder.Entity<Characters>().Property( p => p.Talentresettimes ).HasColumnName( "TalentResetTimes" );
            modelBuilder.Entity<Characters>().Property( p => p.FirstLogin ).HasColumnName( "first_login" );
            modelBuilder.Entity<Characters>().Property( p => p.LoginFlags ).HasColumnName( "login_flags" );
            modelBuilder.Entity<Characters>().Property( p => p.Arenapoints ).HasColumnName( "arenaPoints" );
            modelBuilder.Entity<Characters>().Property( p => p.Totalstableslots ).HasColumnName( "totalstableslots" );
            modelBuilder.Entity<Characters>().Property( p => p.InstanceId ).HasColumnName( "instance_id" );
            modelBuilder.Entity<Characters>().Property( p => p.Entrypointmap ).HasColumnName( "entrypointmap" );
            modelBuilder.Entity<Characters>().Property( p => p.Entrypointx ).HasColumnName( "entrypointx" );
            modelBuilder.Entity<Characters>().Property( p => p.Entrypointy ).HasColumnName( "entrypointy" );
            modelBuilder.Entity<Characters>().Property( p => p.Entrypointz ).HasColumnName( "entrypointz" );
            modelBuilder.Entity<Characters>().Property( p => p.Entrypointo ).HasColumnName( "entrypointo" );
            modelBuilder.Entity<Characters>().Property( p => p.Entrypointinstance ).HasColumnName( "entrypointinstance" );
            modelBuilder.Entity<Characters>().Property( p => p.TaxiPath ).HasColumnName( "taxi_path" );
            modelBuilder.Entity<Characters>().Property( p => p.TaxiLastnode ).HasColumnName( "taxi_lastnode" );
            modelBuilder.Entity<Characters>().Property( p => p.TaxiMountid ).HasColumnName( "taxi_mountid" );
            modelBuilder.Entity<Characters>().Property( p => p.Transporter ).HasColumnName( "transporter" );
            modelBuilder.Entity<Characters>().Property( p => p.TransporterXdiff ).HasColumnName( "transporter_xdiff" );
            modelBuilder.Entity<Characters>().Property( p => p.TransporterYdiff ).HasColumnName( "transporter_ydiff" );
            modelBuilder.Entity<Characters>().Property( p => p.TransporterZdiff ).HasColumnName( "transporter_zdiff" );
            modelBuilder.Entity<Characters>().Property( p => p.TransporterOdiff ).HasColumnName( "transporter_odiff" );
            modelBuilder.Entity<Characters>().Property( p => p.Actions1 ).HasColumnName( "actions1" );
            modelBuilder.Entity<Characters>().Property( p => p.Actions2 ).HasColumnName( "actions2" );
            modelBuilder.Entity<Characters>().Property( p => p.Auras ).HasColumnName( "auras" );
            modelBuilder.Entity<Characters>().Property( p => p.FinishedQuests ).HasColumnName( "finished_quests" );
            modelBuilder.Entity<Characters>().Property( p => p.Finisheddailies ).HasColumnName( "finisheddailies" );
            modelBuilder.Entity<Characters>().Property( p => p.Honorrollovertime ).HasColumnName( "honorRolloverTime" );
            modelBuilder.Entity<Characters>().Property( p => p.Killstoday ).HasColumnName( "killsToday" );
            modelBuilder.Entity<Characters>().Property( p => p.Killsyesterday ).HasColumnName( "killsYesterday" );
            modelBuilder.Entity<Characters>().Property( p => p.Killslifetime ).HasColumnName( "killsLifeTime" );
            modelBuilder.Entity<Characters>().Property( p => p.Honortoday ).HasColumnName( "honorToday" );
            modelBuilder.Entity<Characters>().Property( p => p.Honoryesterday ).HasColumnName( "honorYesterday" );
            modelBuilder.Entity<Characters>().Property( p => p.Honorpoints ).HasColumnName( "honorPoints" );
            modelBuilder.Entity<Characters>().Property( p => p.Drunkvalue ).HasColumnName( "drunkValue" );
            modelBuilder.Entity<Characters>().Property( p => p.Glyphs1 ).HasColumnName( "glyphs1" );
            modelBuilder.Entity<Characters>().Property( p => p.Talents1 ).HasColumnName( "talents1" );
            modelBuilder.Entity<Characters>().Property( p => p.Glyphs2 ).HasColumnName( "glyphs2" );
            modelBuilder.Entity<Characters>().Property( p => p.Talents2 ).HasColumnName( "talents2" );
            modelBuilder.Entity<Characters>().Property( p => p.Numspecs ).HasColumnName( "numspecs" );
            modelBuilder.Entity<Characters>().Property( p => p.Currentspec ).HasColumnName( "currentspec" );
            modelBuilder.Entity<Characters>().Property( p => p.Talentpoints ).HasColumnName( "talentpoints" );
            modelBuilder.Entity<Characters>().Property( p => p.Phase ).HasColumnName( "phase" );
            modelBuilder.Entity<Characters>().Property( p => p.Cangainxp ).HasColumnName( "CanGainXp" );
            modelBuilder.Entity<Characters>().Property( p => p.Data ).HasColumnName( "data" );
            modelBuilder.Entity<Characters>().Property( p => p.Resettalents ).HasColumnName( "resettalents" );
            modelBuilder.Entity<Characters>().Property( p => p.RbgDaily ).HasColumnName( "rbg_daily" );
            modelBuilder.Entity<Characters>().Property( p => p.DungeonDifficulty ).HasColumnName( "dungeon_difficulty" );
            modelBuilder.Entity<Characters>().Property( p => p.RaidDifficulty ).HasColumnName( "raid_difficulty" );

            modelBuilder.Entity<CharactersInsertQueue>().ToTable( "characters_insert_queue" );
            modelBuilder.Entity<CharactersInsertQueue>().HasKey( e => new { e.InsertTempGuid } );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.InsertTempGuid ).HasColumnName( "insert_temp_guid" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Acct ).HasColumnName( "acct" );
            modelBuilder.Entity<CharactersInsertQueue>().HasIndex( e => e.Acct );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Race ).HasColumnName( "race" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Class ).HasColumnName( "class" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Gender ).HasColumnName( "gender" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.CustomFaction ).HasColumnName( "custom_faction" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Level ).HasColumnName( "level" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Xp ).HasColumnName( "xp" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.ExplorationData ).HasColumnName( "exploration_data" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Skills ).HasColumnName( "skills" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.WatchedFactionIndex ).HasColumnName( "watched_faction_index" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.SelectedPvpTitle ).HasColumnName( "selected_pvp_title" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.AvailablePvpTitles ).HasColumnName( "available_pvp_titles" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Gold ).HasColumnName( "gold" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.AmmoId ).HasColumnName( "ammo_id" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.AvailableProfPoints ).HasColumnName( "available_prof_points" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.AvailableTalentPoints ).HasColumnName( "available_talent_points" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.CurrentHp ).HasColumnName( "current_hp" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.CurrentPower ).HasColumnName( "current_power" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Pvprank ).HasColumnName( "pvprank" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Bytes ).HasColumnName( "bytes" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Bytes2 ).HasColumnName( "bytes2" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.PlayerFlags ).HasColumnName( "player_flags" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.PlayerBytes ).HasColumnName( "player_bytes" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Positionx ).HasColumnName( "positionX" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Positiony ).HasColumnName( "positionY" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Positionz ).HasColumnName( "positionZ" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Mapid ).HasColumnName( "mapId" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Zoneid ).HasColumnName( "zoneId" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Taximask ).HasColumnName( "taximask" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Banned ).HasColumnName( "banned" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Banreason ).HasColumnName( "banReason" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Timestamp ).HasColumnName( "timestamp" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Online ).HasColumnName( "online" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Bindpositionx ).HasColumnName( "bindpositionX" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Bindpositiony ).HasColumnName( "bindpositionY" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Bindpositionz ).HasColumnName( "bindpositionZ" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Bindmapid ).HasColumnName( "bindmapId" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Bindzoneid ).HasColumnName( "bindzoneId" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Isresting ).HasColumnName( "isResting" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Reststate ).HasColumnName( "restState" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Resttime ).HasColumnName( "restTime" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Playedtime ).HasColumnName( "playedtime" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Deathstate ).HasColumnName( "deathstate" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Talentresettimes ).HasColumnName( "TalentResetTimes" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.FirstLogin ).HasColumnName( "first_login" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.ForcedRenamePending ).HasColumnName( "forced_rename_pending" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Publicnote ).HasColumnName( "publicNote" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Officernote ).HasColumnName( "officerNote" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Guildid ).HasColumnName( "guildid" );
            modelBuilder.Entity<CharactersInsertQueue>().HasIndex( e => e.Guildid );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Guildrank ).HasColumnName( "guildRank" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Arenapoints ).HasColumnName( "arenaPoints" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Totalstableslots ).HasColumnName( "totalstableslots" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.InstanceId ).HasColumnName( "instance_id" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Entrypointmap ).HasColumnName( "entrypointmap" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Entrypointx ).HasColumnName( "entrypointx" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Entrypointy ).HasColumnName( "entrypointy" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Entrypointz ).HasColumnName( "entrypointz" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Entrypointo ).HasColumnName( "entrypointo" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Entrypointinstance ).HasColumnName( "entrypointinstance" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.TaxiPath ).HasColumnName( "taxi_path" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.TaxiLastnode ).HasColumnName( "taxi_lastnode" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.TaxiMountid ).HasColumnName( "taxi_mountid" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Transporter ).HasColumnName( "transporter" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.TransporterXdiff ).HasColumnName( "transporter_xdiff" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.TransporterYdiff ).HasColumnName( "transporter_ydiff" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.TransporterZdiff ).HasColumnName( "transporter_zdiff" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Spells ).HasColumnName( "spells" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.DeletedSpells ).HasColumnName( "deleted_spells" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Reputation ).HasColumnName( "reputation" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Actions ).HasColumnName( "actions" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Auras ).HasColumnName( "auras" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.FinishedQuests ).HasColumnName( "finished_quests" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Honorpointstoadd ).HasColumnName( "honorPointsToAdd" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Killstoday ).HasColumnName( "killsToday" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Killsyesterday ).HasColumnName( "killsYesterday" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Killslifetime ).HasColumnName( "killsLifeTime" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Honortoday ).HasColumnName( "honorToday" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Honoryesterday ).HasColumnName( "honorYesterday" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Honorpoints ).HasColumnName( "honorPoints" );
            modelBuilder.Entity<CharactersInsertQueue>().Property( p => p.Difficulty ).HasColumnName( "difficulty" );

            modelBuilder.Entity<Charters>().ToTable( "charters" );
            modelBuilder.Entity<Charters>().HasKey( e => new { e.Charterid } );
            modelBuilder.Entity<Charters>().Property( p => p.Charterid ).HasColumnName( "charterId" );
            modelBuilder.Entity<Charters>().Property( p => p.Chartertype ).HasColumnName( "charterType" );
            modelBuilder.Entity<Charters>().HasIndex( e => e.Chartertype );
            modelBuilder.Entity<Charters>().Property( p => p.Leaderguid ).HasColumnName( "leaderGuid" );
            modelBuilder.Entity<Charters>().Property( p => p.Guildname ).HasColumnName( "guildName" );
            modelBuilder.Entity<Charters>().Property( p => p.Itemguid ).HasColumnName( "itemGuid" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer1 ).HasColumnName( "signer1" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer2 ).HasColumnName( "signer2" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer3 ).HasColumnName( "signer3" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer4 ).HasColumnName( "signer4" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer5 ).HasColumnName( "signer5" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer6 ).HasColumnName( "signer6" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer7 ).HasColumnName( "signer7" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer8 ).HasColumnName( "signer8" );
            modelBuilder.Entity<Charters>().Property( p => p.Signer9 ).HasColumnName( "signer9" );

            modelBuilder.Entity<ClientAddons>().ToTable( "clientaddons" );
            modelBuilder.Entity<ClientAddons>().HasKey( e => new { e.Id } );
            modelBuilder.Entity<ClientAddons>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<ClientAddons>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<ClientAddons>().HasIndex( e => e.Name );
            modelBuilder.Entity<ClientAddons>().Property( p => p.Crc ).HasColumnName( "crc" );
            modelBuilder.Entity<ClientAddons>().Property( p => p.Banned ).HasColumnName( "banned" );
            modelBuilder.Entity<ClientAddons>().Property( p => p.Showinlist ).HasColumnName( "showinlist" );

            modelBuilder.Entity<CommandOverrides>().ToTable( "command_overrides" );
            modelBuilder.Entity<CommandOverrides>().Property( p => p.CommandName ).HasColumnName( "command_name" );
            modelBuilder.Entity<CommandOverrides>().Property( p => p.AccessLevel ).HasColumnName( "access_level" );

            modelBuilder.Entity<Corpses>().ToTable( "corpses" );
            modelBuilder.Entity<Corpses>().HasKey( e => new { e.Guid } );
            modelBuilder.Entity<Corpses>().Property( p => p.Guid ).HasColumnName( "guid" );
            modelBuilder.Entity<Corpses>().Property( p => p.Positionx ).HasColumnName( "positionX" );
            modelBuilder.Entity<Corpses>().Property( p => p.Positiony ).HasColumnName( "positionY" );
            modelBuilder.Entity<Corpses>().Property( p => p.Positionz ).HasColumnName( "positionZ" );
            modelBuilder.Entity<Corpses>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<Corpses>().Property( p => p.Zoneid ).HasColumnName( "zoneId" );
            modelBuilder.Entity<Corpses>().Property( p => p.Mapid ).HasColumnName( "mapId" );
            modelBuilder.Entity<Corpses>().Property( p => p.Instanceid ).HasColumnName( "instanceId" );
            modelBuilder.Entity<Corpses>().HasIndex( e => e.Instanceid );
            modelBuilder.Entity<Corpses>().Property( p => p.Data ).HasColumnName( "data" );

            modelBuilder.Entity<EquipmentSets>().ToTable( "equipmentsets" );
            modelBuilder.Entity<EquipmentSets>().HasKey( e => new { e.Ownerguid, e.Setguid, e.Setid } );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Ownerguid ).HasColumnName( "ownerguid" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Setguid ).HasColumnName( "setGUID" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Setid ).HasColumnName( "setid" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Setname ).HasColumnName( "setname" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Iconname ).HasColumnName( "iconname" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Head ).HasColumnName( "head" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Neck ).HasColumnName( "neck" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Shoulders ).HasColumnName( "shoulders" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Body ).HasColumnName( "body" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Chest ).HasColumnName( "chest" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Waist ).HasColumnName( "waist" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Legs ).HasColumnName( "legs" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Feet ).HasColumnName( "feet" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Wrists ).HasColumnName( "wrists" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Hands ).HasColumnName( "hands" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Finger1 ).HasColumnName( "finger1" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Finger2 ).HasColumnName( "finger2" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Trinket1 ).HasColumnName( "trinket1" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Trinket2 ).HasColumnName( "trinket2" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Back ).HasColumnName( "back" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Mainhand ).HasColumnName( "mainhand" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Offhand ).HasColumnName( "offhand" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Ranged ).HasColumnName( "ranged" );
            modelBuilder.Entity<EquipmentSets>().Property( p => p.Tabard ).HasColumnName( "tabard" );

            modelBuilder.Entity<EventSave>().ToTable( "event_save" );
            modelBuilder.Entity<EventSave>().Property( p => p.EventEntry ).HasColumnName( "event_entry" );
            modelBuilder.Entity<EventSave>().Property( p => p.State ).HasColumnName( "state" );
            modelBuilder.Entity<EventSave>().Property( p => p.NextStart ).HasColumnName( "next_start" );

            modelBuilder.Entity<GmSurvey>().ToTable( "gm_survey" );
            modelBuilder.Entity<GmSurvey>().Property( p => p.SurveyId ).HasColumnName( "survey_id" );
            modelBuilder.Entity<GmSurvey>().Property( p => p.Guid ).HasColumnName( "guid" );
            modelBuilder.Entity<GmSurvey>().Property( p => p.MainSurvey ).HasColumnName( "main_survey" );
            modelBuilder.Entity<GmSurvey>().Property( p => p.Comment ).HasColumnName( "comment" );
            modelBuilder.Entity<GmSurvey>().Property( p => p.CreateTime ).HasColumnName( "create_time" );

            modelBuilder.Entity<GmSurveyAnswers>().ToTable( "gm_survey_answers" );
            modelBuilder.Entity<GmSurveyAnswers>().HasKey( e => new { e.SurveyId, e.QuestionId } );
            modelBuilder.Entity<GmSurveyAnswers>().Property( p => p.SurveyId ).HasColumnName( "survey_id" );
            modelBuilder.Entity<GmSurveyAnswers>().Property( p => p.QuestionId ).HasColumnName( "question_id" );
            modelBuilder.Entity<GmSurveyAnswers>().Property( p => p.AnswerId ).HasColumnName( "answer_id" );

            modelBuilder.Entity<GmTickets>().ToTable( "gm_tickets" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Ticketid ).HasColumnName( "ticketid" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Playerguid ).HasColumnName( "playerGuid" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Level ).HasColumnName( "level" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Map ).HasColumnName( "map" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Posx ).HasColumnName( "posX" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Posy ).HasColumnName( "posY" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Posz ).HasColumnName( "posZ" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Message ).HasColumnName( "message" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Timestamp ).HasColumnName( "timestamp" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Deleted ).HasColumnName( "deleted" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Assignedto ).HasColumnName( "assignedto" );
            modelBuilder.Entity<GmTickets>().Property( p => p.Comment ).HasColumnName( "comment" );

            modelBuilder.Entity<Groups>().ToTable( "groups" );
            modelBuilder.Entity<Groups>().Property( p => p.GroupId ).HasColumnName( "group_id" );
            modelBuilder.Entity<Groups>().Property( p => p.GroupType ).HasColumnName( "group_type" );
            modelBuilder.Entity<Groups>().Property( p => p.SubgroupCount ).HasColumnName( "subgroup_count" );
            modelBuilder.Entity<Groups>().Property( p => p.LootMethod ).HasColumnName( "loot_method" );
            modelBuilder.Entity<Groups>().Property( p => p.LootThreshold ).HasColumnName( "loot_threshold" );
            modelBuilder.Entity<Groups>().Property( p => p.Difficulty ).HasColumnName( "difficulty" );
            modelBuilder.Entity<Groups>().Property( p => p.Raiddifficulty ).HasColumnName( "raiddifficulty" );
            modelBuilder.Entity<Groups>().Property( p => p.AssistantLeader ).HasColumnName( "assistant_leader" );
            modelBuilder.Entity<Groups>().Property( p => p.MainTank ).HasColumnName( "main_tank" );
            modelBuilder.Entity<Groups>().Property( p => p.MainAssist ).HasColumnName( "main_assist" );
            modelBuilder.Entity<Groups>().Property( p => p.Group1member1 ).HasColumnName( "group1member1" );
            modelBuilder.Entity<Groups>().Property( p => p.Group1member2 ).HasColumnName( "group1member2" );
            modelBuilder.Entity<Groups>().Property( p => p.Group1member3 ).HasColumnName( "group1member3" );
            modelBuilder.Entity<Groups>().Property( p => p.Group1member4 ).HasColumnName( "group1member4" );
            modelBuilder.Entity<Groups>().Property( p => p.Group1member5 ).HasColumnName( "group1member5" );
            modelBuilder.Entity<Groups>().Property( p => p.Group2member1 ).HasColumnName( "group2member1" );
            modelBuilder.Entity<Groups>().Property( p => p.Group2member2 ).HasColumnName( "group2member2" );
            modelBuilder.Entity<Groups>().Property( p => p.Group2member3 ).HasColumnName( "group2member3" );
            modelBuilder.Entity<Groups>().Property( p => p.Group2member4 ).HasColumnName( "group2member4" );
            modelBuilder.Entity<Groups>().Property( p => p.Group2member5 ).HasColumnName( "group2member5" );
            modelBuilder.Entity<Groups>().Property( p => p.Group3member1 ).HasColumnName( "group3member1" );
            modelBuilder.Entity<Groups>().Property( p => p.Group3member2 ).HasColumnName( "group3member2" );
            modelBuilder.Entity<Groups>().Property( p => p.Group3member3 ).HasColumnName( "group3member3" );
            modelBuilder.Entity<Groups>().Property( p => p.Group3member4 ).HasColumnName( "group3member4" );
            modelBuilder.Entity<Groups>().Property( p => p.Group3member5 ).HasColumnName( "group3member5" );
            modelBuilder.Entity<Groups>().Property( p => p.Group4member1 ).HasColumnName( "group4member1" );
            modelBuilder.Entity<Groups>().Property( p => p.Group4member2 ).HasColumnName( "group4member2" );
            modelBuilder.Entity<Groups>().Property( p => p.Group4member3 ).HasColumnName( "group4member3" );
            modelBuilder.Entity<Groups>().Property( p => p.Group4member4 ).HasColumnName( "group4member4" );
            modelBuilder.Entity<Groups>().Property( p => p.Group4member5 ).HasColumnName( "group4member5" );
            modelBuilder.Entity<Groups>().Property( p => p.Group5member1 ).HasColumnName( "group5member1" );
            modelBuilder.Entity<Groups>().Property( p => p.Group5member2 ).HasColumnName( "group5member2" );
            modelBuilder.Entity<Groups>().Property( p => p.Group5member3 ).HasColumnName( "group5member3" );
            modelBuilder.Entity<Groups>().Property( p => p.Group5member4 ).HasColumnName( "group5member4" );
            modelBuilder.Entity<Groups>().Property( p => p.Group5member5 ).HasColumnName( "group5member5" );
            modelBuilder.Entity<Groups>().Property( p => p.Group6member1 ).HasColumnName( "group6member1" );
            modelBuilder.Entity<Groups>().Property( p => p.Group6member2 ).HasColumnName( "group6member2" );
            modelBuilder.Entity<Groups>().Property( p => p.Group6member3 ).HasColumnName( "group6member3" );
            modelBuilder.Entity<Groups>().Property( p => p.Group6member4 ).HasColumnName( "group6member4" );
            modelBuilder.Entity<Groups>().Property( p => p.Group6member5 ).HasColumnName( "group6member5" );
            modelBuilder.Entity<Groups>().Property( p => p.Group7member1 ).HasColumnName( "group7member1" );
            modelBuilder.Entity<Groups>().Property( p => p.Group7member2 ).HasColumnName( "group7member2" );
            modelBuilder.Entity<Groups>().Property( p => p.Group7member3 ).HasColumnName( "group7member3" );
            modelBuilder.Entity<Groups>().Property( p => p.Group7member4 ).HasColumnName( "group7member4" );
            modelBuilder.Entity<Groups>().Property( p => p.Group7member5 ).HasColumnName( "group7member5" );
            modelBuilder.Entity<Groups>().Property( p => p.Group8member1 ).HasColumnName( "group8member1" );
            modelBuilder.Entity<Groups>().Property( p => p.Group8member2 ).HasColumnName( "group8member2" );
            modelBuilder.Entity<Groups>().Property( p => p.Group8member3 ).HasColumnName( "group8member3" );
            modelBuilder.Entity<Groups>().Property( p => p.Group8member4 ).HasColumnName( "group8member4" );
            modelBuilder.Entity<Groups>().Property( p => p.Group8member5 ).HasColumnName( "group8member5" );
            modelBuilder.Entity<Groups>().Property( p => p.Timestamp ).HasColumnName( "timestamp" );
            modelBuilder.Entity<Groups>().Property( p => p.Instanceids ).HasColumnName( "instanceids" );

            modelBuilder.Entity<GuildBankItems>().ToTable( "guild_bankitems" );
            modelBuilder.Entity<GuildBankItems>().HasKey( e => new { e.Guildid, e.Tabid, e.Slotid } );
            modelBuilder.Entity<GuildBankItems>().Property( p => p.Guildid ).HasColumnName( "guildId" );
            modelBuilder.Entity<GuildBankItems>().Property( p => p.Tabid ).HasColumnName( "tabId" );
            modelBuilder.Entity<GuildBankItems>().Property( p => p.Slotid ).HasColumnName( "slotId" );
            modelBuilder.Entity<GuildBankItems>().Property( p => p.Itemguid ).HasColumnName( "itemGuid" );

            modelBuilder.Entity<GuildBankLogs>().ToTable( "guild_banklogs" );
            modelBuilder.Entity<GuildBankLogs>().HasKey( e => new { e.LogId, e.Guildid } );
            modelBuilder.Entity<GuildBankLogs>().Property( p => p.LogId ).HasColumnName( "log_id" );
            modelBuilder.Entity<GuildBankLogs>().Property( p => p.Guildid ).HasColumnName( "guildid" );
            modelBuilder.Entity<GuildBankLogs>().Property( p => p.Tabid ).HasColumnName( "tabid" );
            modelBuilder.Entity<GuildBankLogs>().HasIndex( e => e.Tabid );
            modelBuilder.Entity<GuildBankLogs>().Property( p => p.Action ).HasColumnName( "action" );
            modelBuilder.Entity<GuildBankLogs>().Property( p => p.PlayerGuid ).HasColumnName( "player_guid" );
            modelBuilder.Entity<GuildBankLogs>().Property( p => p.ItemEntry ).HasColumnName( "item_entry" );
            modelBuilder.Entity<GuildBankLogs>().Property( p => p.StackCount ).HasColumnName( "stack_count" );
            modelBuilder.Entity<GuildBankLogs>().Property( p => p.Timestamp ).HasColumnName( "timestamp" );

            modelBuilder.Entity<GuildBankTabs>().ToTable( "guild_banktabs" );
            modelBuilder.Entity<GuildBankTabs>().HasKey( e => new { e.Guildid, e.Tabid } );
            modelBuilder.Entity<GuildBankTabs>().Property( p => p.Guildid ).HasColumnName( "guildId" );
            modelBuilder.Entity<GuildBankTabs>().Property( p => p.Tabid ).HasColumnName( "tabId" );
            modelBuilder.Entity<GuildBankTabs>().Property( p => p.Tabname ).HasColumnName( "tabName" );
            modelBuilder.Entity<GuildBankTabs>().Property( p => p.Tabicon ).HasColumnName( "tabIcon" );
            modelBuilder.Entity<GuildBankTabs>().Property( p => p.Tabinfo ).HasColumnName( "tabInfo" );

            modelBuilder.Entity<GuildData>().ToTable( "guild_data" );
            modelBuilder.Entity<GuildData>().HasKey( e => new {  } );
            modelBuilder.Entity<GuildData>().Property( p => p.Guildid ).HasColumnName( "guildid" );
            modelBuilder.Entity<GuildData>().HasIndex( e => e.Guildid );
            modelBuilder.Entity<GuildData>().Property( p => p.Playerid ).HasColumnName( "playerid" );
            modelBuilder.Entity<GuildData>().HasIndex( e => e.Playerid );
            modelBuilder.Entity<GuildData>().Property( p => p.Guildrank ).HasColumnName( "guildRank" );
            modelBuilder.Entity<GuildData>().Property( p => p.Publicnote ).HasColumnName( "publicNote" );
            modelBuilder.Entity<GuildData>().Property( p => p.Officernote ).HasColumnName( "officerNote" );
            modelBuilder.Entity<GuildData>().Property( p => p.Lastwithdrawreset ).HasColumnName( "lastWithdrawReset" );
            modelBuilder.Entity<GuildData>().Property( p => p.Withdrawlssincelastreset ).HasColumnName( "withdrawlsSinceLastReset" );
            modelBuilder.Entity<GuildData>().Property( p => p.Lastitemwithdrawreset0 ).HasColumnName( "lastItemWithdrawReset0" );
            modelBuilder.Entity<GuildData>().Property( p => p.Itemwithdrawlssincelastreset0 ).HasColumnName( "itemWithdrawlsSinceLastReset0" );
            modelBuilder.Entity<GuildData>().Property( p => p.Lastitemwithdrawreset1 ).HasColumnName( "lastItemWithdrawReset1" );
            modelBuilder.Entity<GuildData>().Property( p => p.Itemwithdrawlssincelastreset1 ).HasColumnName( "itemWithdrawlsSinceLastReset1" );
            modelBuilder.Entity<GuildData>().Property( p => p.Lastitemwithdrawreset2 ).HasColumnName( "lastItemWithdrawReset2" );
            modelBuilder.Entity<GuildData>().Property( p => p.Itemwithdrawlssincelastreset2 ).HasColumnName( "itemWithdrawlsSinceLastReset2" );
            modelBuilder.Entity<GuildData>().Property( p => p.Lastitemwithdrawreset3 ).HasColumnName( "lastItemWithdrawReset3" );
            modelBuilder.Entity<GuildData>().Property( p => p.Itemwithdrawlssincelastreset3 ).HasColumnName( "itemWithdrawlsSinceLastReset3" );
            modelBuilder.Entity<GuildData>().Property( p => p.Lastitemwithdrawreset4 ).HasColumnName( "lastItemWithdrawReset4" );
            modelBuilder.Entity<GuildData>().Property( p => p.Itemwithdrawlssincelastreset4 ).HasColumnName( "itemWithdrawlsSinceLastReset4" );
            modelBuilder.Entity<GuildData>().Property( p => p.Lastitemwithdrawreset5 ).HasColumnName( "lastItemWithdrawReset5" );
            modelBuilder.Entity<GuildData>().Property( p => p.Itemwithdrawlssincelastreset5 ).HasColumnName( "itemWithdrawlsSinceLastReset5" );

            modelBuilder.Entity<GuildLogs>().ToTable( "guild_logs" );
            modelBuilder.Entity<GuildLogs>().HasKey( e => new { e.LogId, e.Guildid } );
            modelBuilder.Entity<GuildLogs>().Property( p => p.LogId ).HasColumnName( "log_id" );
            modelBuilder.Entity<GuildLogs>().Property( p => p.Guildid ).HasColumnName( "guildid" );
            modelBuilder.Entity<GuildLogs>().Property( p => p.Timestamp ).HasColumnName( "timestamp" );
            modelBuilder.Entity<GuildLogs>().Property( p => p.EventType ).HasColumnName( "event_type" );
            modelBuilder.Entity<GuildLogs>().Property( p => p.Misc1 ).HasColumnName( "misc1" );
            modelBuilder.Entity<GuildLogs>().Property( p => p.Misc2 ).HasColumnName( "misc2" );
            modelBuilder.Entity<GuildLogs>().Property( p => p.Misc3 ).HasColumnName( "misc3" );

            modelBuilder.Entity<GuildRanks>().ToTable( "guild_ranks" );
            modelBuilder.Entity<GuildRanks>().HasKey( e => new { e.Guildid, e.Rankid } );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Guildid ).HasColumnName( "guildId" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Rankid ).HasColumnName( "rankId" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Rankname ).HasColumnName( "rankName" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Rankrights ).HasColumnName( "rankRights" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Goldlimitperday ).HasColumnName( "goldLimitPerDay" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Banktabflags0 ).HasColumnName( "bankTabFlags0" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Itemstacksperday0 ).HasColumnName( "itemStacksPerDay0" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Banktabflags1 ).HasColumnName( "bankTabFlags1" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Itemstacksperday1 ).HasColumnName( "itemStacksPerDay1" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Banktabflags2 ).HasColumnName( "bankTabFlags2" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Itemstacksperday2 ).HasColumnName( "itemStacksPerDay2" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Banktabflags3 ).HasColumnName( "bankTabFlags3" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Itemstacksperday3 ).HasColumnName( "itemStacksPerDay3" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Banktabflags4 ).HasColumnName( "bankTabFlags4" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Itemstacksperday4 ).HasColumnName( "itemStacksPerDay4" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Banktabflags5 ).HasColumnName( "bankTabFlags5" );
            modelBuilder.Entity<GuildRanks>().Property( p => p.Itemstacksperday5 ).HasColumnName( "itemStacksPerDay5" );

            modelBuilder.Entity<Guilds>().ToTable( "guilds" );
            modelBuilder.Entity<Guilds>().Property( p => p.Guildid ).HasColumnName( "guildId" );
            modelBuilder.Entity<Guilds>().Property( p => p.Guildname ).HasColumnName( "guildName" );
            modelBuilder.Entity<Guilds>().Property( p => p.Leaderguid ).HasColumnName( "leaderGuid" );
            modelBuilder.Entity<Guilds>().Property( p => p.Emblemstyle ).HasColumnName( "emblemStyle" );
            modelBuilder.Entity<Guilds>().Property( p => p.Emblemcolor ).HasColumnName( "emblemColor" );
            modelBuilder.Entity<Guilds>().Property( p => p.Borderstyle ).HasColumnName( "borderStyle" );
            modelBuilder.Entity<Guilds>().Property( p => p.Bordercolor ).HasColumnName( "borderColor" );
            modelBuilder.Entity<Guilds>().Property( p => p.Backgroundcolor ).HasColumnName( "backgroundColor" );
            modelBuilder.Entity<Guilds>().Property( p => p.Guildinfo ).HasColumnName( "guildInfo" );
            modelBuilder.Entity<Guilds>().Property( p => p.Motd ).HasColumnName( "motd" );
            modelBuilder.Entity<Guilds>().Property( p => p.Createdate ).HasColumnName( "createdate" );
            modelBuilder.Entity<Guilds>().Property( p => p.Bankbalance ).HasColumnName( "bankBalance" );

            modelBuilder.Entity<InstanceIds>().ToTable( "instanceids" );
            modelBuilder.Entity<InstanceIds>().HasKey( e => new { e.Playerguid, e.Mapid, e.Mode } );
            modelBuilder.Entity<InstanceIds>().Property( p => p.Playerguid ).HasColumnName( "playerguid" );
            modelBuilder.Entity<InstanceIds>().Property( p => p.Mapid ).HasColumnName( "mapid" );
            modelBuilder.Entity<InstanceIds>().Property( p => p.Mode ).HasColumnName( "mode" );
            modelBuilder.Entity<InstanceIds>().Property( p => p.Instanceid ).HasColumnName( "instanceid" );

            modelBuilder.Entity<Instances>().ToTable( "instances" );
            modelBuilder.Entity<Instances>().HasKey( e => new { e.Id } );
            modelBuilder.Entity<Instances>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<Instances>().Property( p => p.Mapid ).HasColumnName( "mapid" );
            modelBuilder.Entity<Instances>().HasIndex( e => e.Mapid );
            modelBuilder.Entity<Instances>().Property( p => p.Creation ).HasColumnName( "creation" );
            modelBuilder.Entity<Instances>().Property( p => p.Expiration ).HasColumnName( "expiration" );
            modelBuilder.Entity<Instances>().Property( p => p.KilledNpcGuids ).HasColumnName( "killed_npc_guids" );
            modelBuilder.Entity<Instances>().Property( p => p.Difficulty ).HasColumnName( "difficulty" );
            modelBuilder.Entity<Instances>().Property( p => p.CreatorGroup ).HasColumnName( "creator_group" );
            modelBuilder.Entity<Instances>().Property( p => p.CreatorGuid ).HasColumnName( "creator_guid" );
            modelBuilder.Entity<Instances>().Property( p => p.Persistent ).HasColumnName( "persistent" );

            modelBuilder.Entity<LagReports>().ToTable( "lag_reports" );
            modelBuilder.Entity<LagReports>().Property( p => p.LagId ).HasColumnName( "lag_id" );
            modelBuilder.Entity<LagReports>().Property( p => p.Player ).HasColumnName( "player" );
            modelBuilder.Entity<LagReports>().Property( p => p.Account ).HasColumnName( "account" );
            modelBuilder.Entity<LagReports>().Property( p => p.LagType ).HasColumnName( "lag_type" );
            modelBuilder.Entity<LagReports>().Property( p => p.MapId ).HasColumnName( "map_id" );
            modelBuilder.Entity<LagReports>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<LagReports>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<LagReports>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<LagReports>().Property( p => p.Timestamp ).HasColumnName( "timestamp" );

            modelBuilder.Entity<LfgData>().ToTable( "lfg_data" );
            modelBuilder.Entity<LfgData>().Property( p => p.Guid ).HasColumnName( "guid" );
            modelBuilder.Entity<LfgData>().Property( p => p.Dungeon ).HasColumnName( "dungeon" );
            modelBuilder.Entity<LfgData>().Property( p => p.State ).HasColumnName( "state" );

            modelBuilder.Entity<Mailbox>().ToTable( "mailbox" );
            modelBuilder.Entity<Mailbox>().HasKey( e => new { e.MessageId } );
            modelBuilder.Entity<Mailbox>().Property( p => p.MessageId ).HasColumnName( "message_id" );
            modelBuilder.Entity<Mailbox>().Property( p => p.MessageType ).HasColumnName( "message_type" );
            modelBuilder.Entity<Mailbox>().Property( p => p.PlayerGuid ).HasColumnName( "player_guid" );
            modelBuilder.Entity<Mailbox>().HasIndex( e => e.PlayerGuid );
            modelBuilder.Entity<Mailbox>().Property( p => p.SenderGuid ).HasColumnName( "sender_guid" );
            modelBuilder.Entity<Mailbox>().Property( p => p.Subject ).HasColumnName( "subject" );
            modelBuilder.Entity<Mailbox>().Property( p => p.Body ).HasColumnName( "body" );
            modelBuilder.Entity<Mailbox>().Property( p => p.Money ).HasColumnName( "money" );
            modelBuilder.Entity<Mailbox>().Property( p => p.AttachedItemGuids ).HasColumnName( "attached_item_guids" );
            modelBuilder.Entity<Mailbox>().Property( p => p.Cod ).HasColumnName( "cod" );
            modelBuilder.Entity<Mailbox>().Property( p => p.Stationary ).HasColumnName( "stationary" );
            modelBuilder.Entity<Mailbox>().Property( p => p.ExpiryTime ).HasColumnName( "expiry_time" );
            modelBuilder.Entity<Mailbox>().Property( p => p.DeliveryTime ).HasColumnName( "delivery_time" );
            modelBuilder.Entity<Mailbox>().Property( p => p.CheckedFlag ).HasColumnName( "checked_flag" );
            modelBuilder.Entity<Mailbox>().Property( p => p.DeletedFlag ).HasColumnName( "deleted_flag" );

            modelBuilder.Entity<MailboxInsertQueue>().ToTable( "mailbox_insert_queue" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.SenderGuid ).HasColumnName( "sender_guid" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ReceiverGuid ).HasColumnName( "receiver_guid" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.Subject ).HasColumnName( "subject" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.Body ).HasColumnName( "body" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.Stationary ).HasColumnName( "stationary" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.Money ).HasColumnName( "money" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId ).HasColumnName( "item_id" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack ).HasColumnName( "item_stack" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId2 ).HasColumnName( "item_id2" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack2 ).HasColumnName( "item_stack2" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId3 ).HasColumnName( "item_id3" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack3 ).HasColumnName( "item_stack3" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId4 ).HasColumnName( "item_id4" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack4 ).HasColumnName( "item_stack4" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId5 ).HasColumnName( "item_id5" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack5 ).HasColumnName( "item_stack5" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId6 ).HasColumnName( "item_id6" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack6 ).HasColumnName( "item_stack6" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId7 ).HasColumnName( "item_id7" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack7 ).HasColumnName( "item_stack7" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId8 ).HasColumnName( "item_id8" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack8 ).HasColumnName( "item_stack8" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId9 ).HasColumnName( "item_id9" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack9 ).HasColumnName( "item_stack9" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId10 ).HasColumnName( "item_id10" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack10 ).HasColumnName( "item_stack10" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId11 ).HasColumnName( "item_id11" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack11 ).HasColumnName( "item_stack11" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemId12 ).HasColumnName( "item_id12" );
            modelBuilder.Entity<MailboxInsertQueue>().Property( p => p.ItemStack12 ).HasColumnName( "item_stack12" );

            modelBuilder.Entity<PlayerBugReports>().ToTable( "playerbugreports" );
            modelBuilder.Entity<PlayerBugReports>().Property( p => p.Uid ).HasColumnName( "UID" );
            modelBuilder.Entity<PlayerBugReports>().Property( p => p.Accountid ).HasColumnName( "AccountID" );
            modelBuilder.Entity<PlayerBugReports>().Property( p => p.Timestamp ).HasColumnName( "TimeStamp" );
            modelBuilder.Entity<PlayerBugReports>().Property( p => p.Suggestion ).HasColumnName( "Suggestion" );
            modelBuilder.Entity<PlayerBugReports>().Property( p => p.Type ).HasColumnName( "Type" );
            modelBuilder.Entity<PlayerBugReports>().Property( p => p.Content ).HasColumnName( "Content" );

            modelBuilder.Entity<PlayerCooldowns>().ToTable( "playercooldowns" );
            modelBuilder.Entity<PlayerCooldowns>().Property( p => p.PlayerGuid ).HasColumnName( "player_guid" );
            modelBuilder.Entity<PlayerCooldowns>().Property( p => p.CooldownType ).HasColumnName( "cooldown_type" );
            modelBuilder.Entity<PlayerCooldowns>().Property( p => p.CooldownMisc ).HasColumnName( "cooldown_misc" );
            modelBuilder.Entity<PlayerCooldowns>().Property( p => p.CooldownExpireTime ).HasColumnName( "cooldown_expire_time" );
            modelBuilder.Entity<PlayerCooldowns>().Property( p => p.CooldownSpellid ).HasColumnName( "cooldown_spellid" );
            modelBuilder.Entity<PlayerCooldowns>().Property( p => p.CooldownItemid ).HasColumnName( "cooldown_itemid" );

            modelBuilder.Entity<PlayerDeletedSpells>().ToTable( "playerdeletedspells" );
            modelBuilder.Entity<PlayerDeletedSpells>().HasKey( e => new { e.Guid, e.Spellid } );
            modelBuilder.Entity<PlayerDeletedSpells>().Property( p => p.Guid ).HasColumnName( "GUID" );
            modelBuilder.Entity<PlayerDeletedSpells>().Property( p => p.Spellid ).HasColumnName( "SpellID" );

            modelBuilder.Entity<PlayerItems>().ToTable( "playeritems" );
            modelBuilder.Entity<PlayerItems>().HasKey( e => new { e.Guid } );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Ownerguid ).HasColumnName( "ownerguid" );
            modelBuilder.Entity<PlayerItems>().HasIndex( e => e.Ownerguid );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Guid ).HasColumnName( "guid" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.WrappedItemId ).HasColumnName( "wrapped_item_id" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.WrappedCreator ).HasColumnName( "wrapped_creator" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Creator ).HasColumnName( "creator" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Count ).HasColumnName( "count" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Charges ).HasColumnName( "charges" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Randomprop ).HasColumnName( "randomprop" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Randomsuffix ).HasColumnName( "randomsuffix" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Itemtext ).HasColumnName( "itemtext" );
            modelBuilder.Entity<PlayerItems>().HasIndex( e => e.Itemtext );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Durability ).HasColumnName( "durability" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Containerslot ).HasColumnName( "containerslot" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Slot ).HasColumnName( "slot" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Enchantments ).HasColumnName( "enchantments" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.DurationExpireson ).HasColumnName( "duration_expireson" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.RefundPurchasedon ).HasColumnName( "refund_purchasedon" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.RefundCostid ).HasColumnName( "refund_costid" );
            modelBuilder.Entity<PlayerItems>().Property( p => p.Text ).HasColumnName( "text" );

            modelBuilder.Entity<PlayerItemsInsertQueue>().ToTable( "playeritems_insert_queue" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Ownerguid ).HasColumnName( "ownerguid" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().HasIndex( e => e.Ownerguid );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.WrappedItemId ).HasColumnName( "wrapped_item_id" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.WrappedCreator ).HasColumnName( "wrapped_creator" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Creator ).HasColumnName( "creator" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Count ).HasColumnName( "count" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Charges ).HasColumnName( "charges" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Randomprop ).HasColumnName( "randomprop" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Randomsuffix ).HasColumnName( "randomsuffix" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Itemtext ).HasColumnName( "itemtext" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Durability ).HasColumnName( "durability" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Containerslot ).HasColumnName( "containerslot" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Slot ).HasColumnName( "slot" );
            modelBuilder.Entity<PlayerItemsInsertQueue>().Property( p => p.Enchantments ).HasColumnName( "enchantments" );

            modelBuilder.Entity<PlayerPets>().ToTable( "playerpets" );
            modelBuilder.Entity<PlayerPets>().HasKey( e => new { e.Ownerguid, e.Petnumber } );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Ownerguid ).HasColumnName( "ownerguid" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Petnumber ).HasColumnName( "petnumber" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Xp ).HasColumnName( "xp" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Active ).HasColumnName( "active" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Level ).HasColumnName( "level" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Actionbar ).HasColumnName( "actionbar" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Happinessupdate ).HasColumnName( "happinessupdate" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.ResetTime ).HasColumnName( "reset_time" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.ResetCost ).HasColumnName( "reset_cost" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Spellid ).HasColumnName( "spellid" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Petstate ).HasColumnName( "petstate" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Alive ).HasColumnName( "alive" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Talentpoints ).HasColumnName( "talentpoints" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.CurrentPower ).HasColumnName( "current_power" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.CurrentHp ).HasColumnName( "current_hp" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.CurrentHappiness ).HasColumnName( "current_happiness" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Renamable ).HasColumnName( "renamable" );
            modelBuilder.Entity<PlayerPets>().Property( p => p.Type ).HasColumnName( "type" );

            modelBuilder.Entity<PlayerPetSpells>().ToTable( "playerpetspells" );
            modelBuilder.Entity<PlayerPetSpells>().HasKey( e => new {  } );
            modelBuilder.Entity<PlayerPetSpells>().Property( p => p.Ownerguid ).HasColumnName( "ownerguid" );
            modelBuilder.Entity<PlayerPetSpells>().HasIndex( e => e.Ownerguid );
            modelBuilder.Entity<PlayerPetSpells>().Property( p => p.Petnumber ).HasColumnName( "petnumber" );
            modelBuilder.Entity<PlayerPetSpells>().HasIndex( e => e.Petnumber );
            modelBuilder.Entity<PlayerPetSpells>().Property( p => p.Spellid ).HasColumnName( "spellid" );
            modelBuilder.Entity<PlayerPetSpells>().Property( p => p.Flags ).HasColumnName( "flags" );

            modelBuilder.Entity<PlayerReputations>().ToTable( "playerreputations" );
            modelBuilder.Entity<PlayerReputations>().HasKey( e => new { e.Guid, e.Faction } );
            modelBuilder.Entity<PlayerReputations>().Property( p => p.Guid ).HasColumnName( "guid" );
            modelBuilder.Entity<PlayerReputations>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<PlayerReputations>().Property( p => p.Flag ).HasColumnName( "flag" );
            modelBuilder.Entity<PlayerReputations>().Property( p => p.Basestanding ).HasColumnName( "basestanding" );
            modelBuilder.Entity<PlayerReputations>().Property( p => p.Standing ).HasColumnName( "standing" );

            modelBuilder.Entity<PlayerSkills>().ToTable( "playerskills" );
            modelBuilder.Entity<PlayerSkills>().HasKey( e => new { e.Guid, e.Skillid } );
            modelBuilder.Entity<PlayerSkills>().Property( p => p.Guid ).HasColumnName( "GUID" );
            modelBuilder.Entity<PlayerSkills>().Property( p => p.Skillid ).HasColumnName( "SkillID" );
            modelBuilder.Entity<PlayerSkills>().Property( p => p.Currentvalue ).HasColumnName( "CurrentValue" );
            modelBuilder.Entity<PlayerSkills>().Property( p => p.Maximumvalue ).HasColumnName( "MaximumValue" );

            modelBuilder.Entity<PlayerSpells>().ToTable( "playerspells" );
            modelBuilder.Entity<PlayerSpells>().HasKey( e => new { e.Guid, e.Spellid } );
            modelBuilder.Entity<PlayerSpells>().Property( p => p.Guid ).HasColumnName( "GUID" );
            modelBuilder.Entity<PlayerSpells>().Property( p => p.Spellid ).HasColumnName( "SpellID" );

            modelBuilder.Entity<PlayerSummons>().ToTable( "playersummons" );
            modelBuilder.Entity<PlayerSummons>().Property( p => p.Ownerguid ).HasColumnName( "ownerguid" );
            modelBuilder.Entity<PlayerSummons>().HasIndex( e => e.Ownerguid );
            modelBuilder.Entity<PlayerSummons>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<PlayerSummons>().Property( p => p.Name ).HasColumnName( "name" );

            modelBuilder.Entity<PlayerSummonSpells>().ToTable( "playersummonspells" );
            modelBuilder.Entity<PlayerSummonSpells>().Property( p => p.Ownerguid ).HasColumnName( "ownerguid" );
            modelBuilder.Entity<PlayerSummonSpells>().HasIndex( e => e.Ownerguid );
            modelBuilder.Entity<PlayerSummonSpells>().Property( p => p.Entryid ).HasColumnName( "entryid" );
            modelBuilder.Entity<PlayerSummonSpells>().Property( p => p.Spellid ).HasColumnName( "spellid" );

            modelBuilder.Entity<QuestLog>().ToTable( "questlog" );
            modelBuilder.Entity<QuestLog>().HasKey( e => new { e.PlayerGuid, e.QuestId } );
            modelBuilder.Entity<QuestLog>().Property( p => p.PlayerGuid ).HasColumnName( "player_guid" );
            modelBuilder.Entity<QuestLog>().Property( p => p.QuestId ).HasColumnName( "quest_id" );
            modelBuilder.Entity<QuestLog>().Property( p => p.Slot ).HasColumnName( "slot" );
            modelBuilder.Entity<QuestLog>().Property( p => p.Expirytime ).HasColumnName( "expirytime" );
            modelBuilder.Entity<QuestLog>().Property( p => p.ExploredArea1 ).HasColumnName( "explored_area1" );
            modelBuilder.Entity<QuestLog>().Property( p => p.ExploredArea2 ).HasColumnName( "explored_area2" );
            modelBuilder.Entity<QuestLog>().Property( p => p.ExploredArea3 ).HasColumnName( "explored_area3" );
            modelBuilder.Entity<QuestLog>().Property( p => p.ExploredArea4 ).HasColumnName( "explored_area4" );
            modelBuilder.Entity<QuestLog>().Property( p => p.MobKill1 ).HasColumnName( "mob_kill1" );
            modelBuilder.Entity<QuestLog>().Property( p => p.MobKill2 ).HasColumnName( "mob_kill2" );
            modelBuilder.Entity<QuestLog>().Property( p => p.MobKill3 ).HasColumnName( "mob_kill3" );
            modelBuilder.Entity<QuestLog>().Property( p => p.MobKill4 ).HasColumnName( "mob_kill4" );
            modelBuilder.Entity<QuestLog>().Property( p => p.Completed ).HasColumnName( "completed" );

            modelBuilder.Entity<ServerSettings>().ToTable( "server_settings" );
            modelBuilder.Entity<ServerSettings>().Property( p => p.SettingId ).HasColumnName( "setting_id" );
            modelBuilder.Entity<ServerSettings>().Property( p => p.SettingValue ).HasColumnName( "setting_value" );

            modelBuilder.Entity<SocialFriends>().ToTable( "social_friends" );
            modelBuilder.Entity<SocialFriends>().HasKey( e => new { e.CharacterGuid, e.FriendGuid } );
            modelBuilder.Entity<SocialFriends>().Property( p => p.CharacterGuid ).HasColumnName( "character_guid" );
            modelBuilder.Entity<SocialFriends>().Property( p => p.FriendGuid ).HasColumnName( "friend_guid" );
            modelBuilder.Entity<SocialFriends>().Property( p => p.Note ).HasColumnName( "note" );

            modelBuilder.Entity<SocialIgnores>().ToTable( "social_ignores" );
            modelBuilder.Entity<SocialIgnores>().HasKey( e => new { e.CharacterGuid, e.IgnoreGuid } );
            modelBuilder.Entity<SocialIgnores>().Property( p => p.CharacterGuid ).HasColumnName( "character_guid" );
            modelBuilder.Entity<SocialIgnores>().Property( p => p.IgnoreGuid ).HasColumnName( "ignore_guid" );

            modelBuilder.Entity<Tutorials>().ToTable( "tutorials" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Playerid ).HasColumnName( "playerId" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Tut0 ).HasColumnName( "tut0" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Tut1 ).HasColumnName( "tut1" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Tut2 ).HasColumnName( "tut2" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Tut3 ).HasColumnName( "tut3" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Tut4 ).HasColumnName( "tut4" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Tut5 ).HasColumnName( "tut5" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Tut6 ).HasColumnName( "tut6" );
            modelBuilder.Entity<Tutorials>().Property( p => p.Tut7 ).HasColumnName( "tut7" );

        }
    }
}