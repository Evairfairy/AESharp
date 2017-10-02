// This file was automatically generated

using System;
using AESharp.Database.Configuration;
using AESharp.Database.Entities.Models.World;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using MySQL.Data.EntityFrameworkCore.Extensions;

namespace AESharp.Database.Entities
{
    internal sealed class WorldDatabase : DbContext
    {
        private readonly DatabaseSettings Settings;

        public DbSet<AchievementReward> AchievementReward { get; set; }
        public DbSet<AiAgents> AiAgents { get; set; }
        public DbSet<AiThreatToSpellId> AiThreattospellid { get; set; }
        public DbSet<AreaTriggers> Areatriggers { get; set; }
        public DbSet<AuctionHouse> Auctionhouse { get; set; }
        public DbSet<BannedPhrases> BannedPhrases { get; set; }
        public DbSet<BattleMasters> Battlemasters { get; set; }
        public DbSet<CreatureDifficulty> CreatureDifficulty { get; set; }
        public DbSet<CreatureFormations> CreatureFormations { get; set; }
        public DbSet<CreatureInitialEquip> CreatureInitialEquip { get; set; }
        public DbSet<CreatureProperties> CreatureProperties { get; set; }
        public DbSet<CreatureQuestFinisher> CreatureQuestFinisher { get; set; }
        public DbSet<CreatureQuestStarter> CreatureQuestStarter { get; set; }
        public DbSet<CreatureSpawns> CreatureSpawns { get; set; }
        public DbSet<CreatureStaticspawns> CreatureStaticspawns { get; set; }
        public DbSet<CreatureTimedEmotes> CreatureTimedEmotes { get; set; }
        public DbSet<CreatureWaypoints> CreatureWaypoints { get; set; }
        public DbSet<CreatureWaypointsManual> CreatureWaypointsManual { get; set; }
        public DbSet<DisplayBoundingBoxes> DisplayBoundingBoxes { get; set; }
        public DbSet<EventCreatureSpawns> EventCreatureSpawns { get; set; }
        public DbSet<EventGameobjectSpawns> EventGameobjectSpawns { get; set; }
        public DbSet<EventProperties> EventProperties { get; set; }
        public DbSet<EventScripts> EventScripts { get; set; }
        public DbSet<Fishing> Fishing { get; set; }
        public DbSet<GameobjectProperties> GameobjectProperties { get; set; }
        public DbSet<GameobjectQuestFinisher> GameobjectQuestFinisher { get; set; }
        public DbSet<GameobjectQuestItemBinding> GameobjectQuestItemBinding { get; set; }
        public DbSet<GameobjectQuestPickupBinding> GameobjectQuestPickupBinding { get; set; }
        public DbSet<GameobjectQuestStarter> GameobjectQuestStarter { get; set; }
        public DbSet<GameobjectSpawns> GameobjectSpawns { get; set; }
        public DbSet<GameobjectStaticspawns> GameobjectStaticspawns { get; set; }
        public DbSet<GameobjectTeleports> GameobjectTeleports { get; set; }
        public DbSet<GossipMenuOption> GossipMenuOption { get; set; }
        public DbSet<Graveyards> Graveyards { get; set; }
        public DbSet<InstanceBosses> InstanceBosses { get; set; }
        public DbSet<ItemPages> ItemPages { get; set; }
        public DbSet<ItemProperties> ItemProperties { get; set; }
        public DbSet<ItemQuestAssociation> ItemQuestAssociation { get; set; }
        public DbSet<ItemRandomPropGroups> ItemRandompropGroups { get; set; }
        public DbSet<ItemRandomSuffixGroups> ItemRandomsuffixGroups { get; set; }
        public DbSet<ItemSetLinkedItemSetBonus> ItemsetLinkedItemsetbonus { get; set; }
        public DbSet<LfgDungeonRewards> LfgDungeonRewards { get; set; }
        public DbSet<LocalesCreature> LocalesCreature { get; set; }
        public DbSet<LocalesGameobject> LocalesGameobject { get; set; }
        public DbSet<LocalesGossipMenuOption> LocalesGossipMenuOption { get; set; }
        public DbSet<LocalesItem> LocalesItem { get; set; }
        public DbSet<LocalesItemPages> LocalesItemPages { get; set; }
        public DbSet<LocalesNpcMonstersay> LocalesNpcMonstersay { get; set; }
        public DbSet<LocalesNpcScriptText> LocalesNpcScriptText { get; set; }
        public DbSet<LocalesNpcText> LocalesNpcText { get; set; }
        public DbSet<LocalesQuest> LocalesQuest { get; set; }
        public DbSet<LocalesWorldBroadcast> LocalesWorldbroadcast { get; set; }
        public DbSet<LocalesWorldMapInfo> LocalesWorldmapInfo { get; set; }
        public DbSet<LocalesWorldStringTable> LocalesWorldstringTable { get; set; }
        public DbSet<LootCreatures> LootCreatures { get; set; }
        public DbSet<LootFishing> LootFishing { get; set; }
        public DbSet<LootGameObjects> LootGameobjects { get; set; }
        public DbSet<LootItems> LootItems { get; set; }
        public DbSet<LootPickpocketing> LootPickpocketing { get; set; }
        public DbSet<LootSkinning> LootSkinning { get; set; }
        public DbSet<MapCheckpoint> MapCheckpoint { get; set; }
        public DbSet<NpcGossipTextId> NpcGossipTextid { get; set; }
        public DbSet<NpcMonsterSay> NpcMonstersay { get; set; }
        public DbSet<NpcScriptText> NpcScriptText { get; set; }
        public DbSet<NpcText> NpcText { get; set; }

        public WorldDatabase( DatabaseSettings settings )
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
                        Database = this.Settings.Databases.WorldDatabase,
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
            modelBuilder.Entity<AchievementReward>().ToTable( "achievement_reward" );
            modelBuilder.Entity<AchievementReward>().HasKey( e => new { e.Entry, e.Gender } );
            modelBuilder.Entity<AchievementReward>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<AchievementReward>().Property( p => p.Gender ).HasColumnName( "gender" );
            modelBuilder.Entity<AchievementReward>().Property( p => p.TitleA ).HasColumnName( "title_A" );
            modelBuilder.Entity<AchievementReward>().Property( p => p.TitleH ).HasColumnName( "title_H" );
            modelBuilder.Entity<AchievementReward>().Property( p => p.Item ).HasColumnName( "item" );
            modelBuilder.Entity<AchievementReward>().Property( p => p.Sender ).HasColumnName( "sender" );
            modelBuilder.Entity<AchievementReward>().Property( p => p.Subject ).HasColumnName( "subject" );
            modelBuilder.Entity<AchievementReward>().Property( p => p.Text ).HasColumnName( "text" );

            modelBuilder.Entity<AiAgents>().ToTable( "ai_agents" );
            modelBuilder.Entity<AiAgents>().HasKey( e => new { e.Entry, e.InstanceMode, e.Type, e.Spell } );
            modelBuilder.Entity<AiAgents>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<AiAgents>().Property( p => p.InstanceMode ).HasColumnName( "instance_mode" );
            modelBuilder.Entity<AiAgents>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<AiAgents>().Property( p => p.Event ).HasColumnName( "event" );
            modelBuilder.Entity<AiAgents>().Property( p => p.Chance ).HasColumnName( "chance" );
            modelBuilder.Entity<AiAgents>().Property( p => p.Maxcount ).HasColumnName( "maxcount" );
            modelBuilder.Entity<AiAgents>().Property( p => p.Spell ).HasColumnName( "spell" );
            modelBuilder.Entity<AiAgents>().Property( p => p.Spelltype ).HasColumnName( "spelltype" );
            modelBuilder.Entity<AiAgents>().Property( p => p.TargettypeOverwrite ).HasColumnName( "targettype_overwrite" );
            modelBuilder.Entity<AiAgents>().Property( p => p.CooldownOverwrite ).HasColumnName( "cooldown_overwrite" );
            modelBuilder.Entity<AiAgents>().Property( p => p.Floatmisc1 ).HasColumnName( "floatMisc1" );
            modelBuilder.Entity<AiAgents>().Property( p => p.Misc2 ).HasColumnName( "Misc2" );

            modelBuilder.Entity<AiThreatToSpellId>().ToTable( "ai_threattospellid" );
            modelBuilder.Entity<AiThreatToSpellId>().Property( p => p.Spell ).HasColumnName( "spell" );
            modelBuilder.Entity<AiThreatToSpellId>().Property( p => p.Mod ).HasColumnName( "mod" );
            modelBuilder.Entity<AiThreatToSpellId>().Property( p => p.Modcoef ).HasColumnName( "modcoef" );

            modelBuilder.Entity<AreaTriggers>().ToTable( "areatriggers" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.Map ).HasColumnName( "map" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.Screen ).HasColumnName( "screen" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.RequiredHonorRank ).HasColumnName( "required_honor_rank" );
            modelBuilder.Entity<AreaTriggers>().Property( p => p.RequiredLevel ).HasColumnName( "required_level" );

            modelBuilder.Entity<AuctionHouse>().ToTable( "auctionhouse" );
            modelBuilder.Entity<AuctionHouse>().Property( p => p.CreatureEntry ).HasColumnName( "creature_entry" );
            modelBuilder.Entity<AuctionHouse>().Property( p => p.Ahgroup ).HasColumnName( "ahgroup" );

            modelBuilder.Entity<BannedPhrases>().ToTable( "banned_phrases" );
            modelBuilder.Entity<BannedPhrases>().Property( p => p.Phrase ).HasColumnName( "phrase" );

            modelBuilder.Entity<BattleMasters>().ToTable( "battlemasters" );
            modelBuilder.Entity<BattleMasters>().Property( p => p.CreatureEntry ).HasColumnName( "creature_entry" );
            modelBuilder.Entity<BattleMasters>().Property( p => p.BattlegroundId ).HasColumnName( "battleground_id" );

            modelBuilder.Entity<CreatureDifficulty>().ToTable( "creature_difficulty" );
            modelBuilder.Entity<CreatureDifficulty>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<CreatureDifficulty>().Property( p => p.Difficulty1 ).HasColumnName( "difficulty_1" );
            modelBuilder.Entity<CreatureDifficulty>().Property( p => p.Difficulty2 ).HasColumnName( "difficulty_2" );
            modelBuilder.Entity<CreatureDifficulty>().Property( p => p.Difficulty3 ).HasColumnName( "difficulty_3" );

            modelBuilder.Entity<CreatureFormations>().ToTable( "creature_formations" );
            modelBuilder.Entity<CreatureFormations>().Property( p => p.SpawnId ).HasColumnName( "spawn_id" );
            modelBuilder.Entity<CreatureFormations>().Property( p => p.TargetSpawnId ).HasColumnName( "target_spawn_id" );
            modelBuilder.Entity<CreatureFormations>().Property( p => p.FollowAngle ).HasColumnName( "follow_angle" );
            modelBuilder.Entity<CreatureFormations>().Property( p => p.FollowDist ).HasColumnName( "follow_dist" );

            modelBuilder.Entity<CreatureInitialEquip>().ToTable( "creature_initial_equip" );
            modelBuilder.Entity<CreatureInitialEquip>().Property( p => p.CreatureEntry ).HasColumnName( "creature_entry" );
            modelBuilder.Entity<CreatureInitialEquip>().Property( p => p.Itemslot1 ).HasColumnName( "itemslot_1" );
            modelBuilder.Entity<CreatureInitialEquip>().Property( p => p.Itemslot2 ).HasColumnName( "itemslot_2" );
            modelBuilder.Entity<CreatureInitialEquip>().Property( p => p.Itemslot3 ).HasColumnName( "itemslot_3" );

            modelBuilder.Entity<CreatureProperties>().ToTable( "creature_properties" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Killcredit1 ).HasColumnName( "killcredit1" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Killcredit2 ).HasColumnName( "killcredit2" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.MaleDisplayid ).HasColumnName( "male_displayid" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.FemaleDisplayid ).HasColumnName( "female_displayid" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.MaleDisplayid2 ).HasColumnName( "male_displayid2" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.FemaleDisplayid2 ).HasColumnName( "female_displayid2" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Subname ).HasColumnName( "subname" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.InfoStr ).HasColumnName( "info_str" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Flags1 ).HasColumnName( "flags1" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Family ).HasColumnName( "family" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Rank ).HasColumnName( "rank" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Encounter ).HasColumnName( "encounter" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.UnknownFloat1 ).HasColumnName( "unknown_float1" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.UnknownFloat2 ).HasColumnName( "unknown_float2" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Leader ).HasColumnName( "leader" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Minlevel ).HasColumnName( "minlevel" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Maxlevel ).HasColumnName( "maxlevel" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Minhealth ).HasColumnName( "minhealth" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Maxhealth ).HasColumnName( "maxhealth" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Mana ).HasColumnName( "mana" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Scale ).HasColumnName( "scale" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Npcflags ).HasColumnName( "npcflags" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Attacktime ).HasColumnName( "attacktime" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Attacktype ).HasColumnName( "attacktype" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Mindamage ).HasColumnName( "mindamage" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Maxdamage ).HasColumnName( "maxdamage" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.CanRanged ).HasColumnName( "can_ranged" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Rangedattacktime ).HasColumnName( "rangedattacktime" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Rangedmindamage ).HasColumnName( "rangedmindamage" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Rangedmaxdamage ).HasColumnName( "rangedmaxdamage" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Respawntime ).HasColumnName( "respawntime" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Armor ).HasColumnName( "armor" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Resistance1 ).HasColumnName( "resistance1" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Resistance2 ).HasColumnName( "resistance2" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Resistance3 ).HasColumnName( "resistance3" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Resistance4 ).HasColumnName( "resistance4" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Resistance5 ).HasColumnName( "resistance5" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Resistance6 ).HasColumnName( "resistance6" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.CombatReach ).HasColumnName( "combat_reach" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.BoundingRadius ).HasColumnName( "bounding_radius" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Auras ).HasColumnName( "auras" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Boss ).HasColumnName( "boss" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Money ).HasColumnName( "money" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.InvisibilityType ).HasColumnName( "invisibility_type" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.WalkSpeed ).HasColumnName( "walk_speed" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.RunSpeed ).HasColumnName( "run_speed" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.FlySpeed ).HasColumnName( "fly_speed" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.ExtraA9Flags ).HasColumnName( "extra_a9_flags" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spell1 ).HasColumnName( "spell1" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spell2 ).HasColumnName( "spell2" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spell3 ).HasColumnName( "spell3" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spell4 ).HasColumnName( "spell4" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spell5 ).HasColumnName( "spell5" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spell6 ).HasColumnName( "spell6" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spell7 ).HasColumnName( "spell7" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spell8 ).HasColumnName( "spell8" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.SpellFlags ).HasColumnName( "spell_flags" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Modimmunities ).HasColumnName( "modImmunities" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Istrainingdummy ).HasColumnName( "isTrainingDummy" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Guardtype ).HasColumnName( "guardtype" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Summonguard ).HasColumnName( "summonguard" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Spelldataid ).HasColumnName( "spelldataid" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Vehicleid ).HasColumnName( "vehicleid" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Rooted ).HasColumnName( "rooted" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Questitem1 ).HasColumnName( "questitem1" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Questitem2 ).HasColumnName( "questitem2" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Questitem3 ).HasColumnName( "questitem3" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Questitem4 ).HasColumnName( "questitem4" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Questitem5 ).HasColumnName( "questitem5" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Questitem6 ).HasColumnName( "questitem6" );
            modelBuilder.Entity<CreatureProperties>().Property( p => p.Waypointid ).HasColumnName( "waypointid" );

            modelBuilder.Entity<CreatureQuestFinisher>().ToTable( "creature_quest_finisher" );
            modelBuilder.Entity<CreatureQuestFinisher>().HasKey( e => new { e.Id, e.Quest } );
            modelBuilder.Entity<CreatureQuestFinisher>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<CreatureQuestFinisher>().Property( p => p.Quest ).HasColumnName( "quest" );

            modelBuilder.Entity<CreatureQuestStarter>().ToTable( "creature_quest_starter" );
            modelBuilder.Entity<CreatureQuestStarter>().HasKey( e => new { e.Id, e.Quest } );
            modelBuilder.Entity<CreatureQuestStarter>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<CreatureQuestStarter>().Property( p => p.Quest ).HasColumnName( "quest" );

            modelBuilder.Entity<CreatureSpawns>().ToTable( "creature_spawns" );
            modelBuilder.Entity<CreatureSpawns>().HasKey( e => new { e.Id } );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<CreatureSpawns>().HasIndex( e => e.Entry );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Map ).HasColumnName( "map" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Movetype ).HasColumnName( "movetype" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Displayid ).HasColumnName( "displayid" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Bytes0 ).HasColumnName( "bytes0" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Bytes1 ).HasColumnName( "bytes1" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Bytes2 ).HasColumnName( "bytes2" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.EmoteState ).HasColumnName( "emote_state" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.NpcRespawnLink ).HasColumnName( "npc_respawn_link" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.ChannelSpell ).HasColumnName( "channel_spell" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.ChannelTargetSqlid ).HasColumnName( "channel_target_sqlid" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.ChannelTargetSqlidCreature ).HasColumnName( "channel_target_sqlid_creature" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Standstate ).HasColumnName( "standstate" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.DeathState ).HasColumnName( "death_state" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Mountdisplayid ).HasColumnName( "mountdisplayid" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Slot1item ).HasColumnName( "slot1item" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Slot2item ).HasColumnName( "slot2item" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Slot3item ).HasColumnName( "slot3item" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Canfly ).HasColumnName( "CanFly" );
            modelBuilder.Entity<CreatureSpawns>().Property( p => p.Phase ).HasColumnName( "phase" );

            modelBuilder.Entity<CreatureStaticspawns>().ToTable( "creature_staticspawns" );
            modelBuilder.Entity<CreatureStaticspawns>().HasKey( e => new { e.Id } );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<CreatureStaticspawns>().HasIndex( e => e.Entry );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Map ).HasColumnName( "map" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Movetype ).HasColumnName( "movetype" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Displayid ).HasColumnName( "displayid" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Bytes0 ).HasColumnName( "bytes0" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Bytes1 ).HasColumnName( "bytes1" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Bytes2 ).HasColumnName( "bytes2" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.EmoteState ).HasColumnName( "emote_state" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.NpcRespawnLink ).HasColumnName( "npc_respawn_link" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.ChannelSpell ).HasColumnName( "channel_spell" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.ChannelTargetSqlid ).HasColumnName( "channel_target_sqlid" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.ChannelTargetSqlidCreature ).HasColumnName( "channel_target_sqlid_creature" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Standstate ).HasColumnName( "standstate" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.DeathState ).HasColumnName( "death_state" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Mountdisplayid ).HasColumnName( "mountdisplayid" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Slot1item ).HasColumnName( "slot1item" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Slot2item ).HasColumnName( "slot2item" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Slot3item ).HasColumnName( "slot3item" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Canfly ).HasColumnName( "CanFly" );
            modelBuilder.Entity<CreatureStaticspawns>().Property( p => p.Phase ).HasColumnName( "phase" );

            modelBuilder.Entity<CreatureTimedEmotes>().ToTable( "creature_timed_emotes" );
            modelBuilder.Entity<CreatureTimedEmotes>().HasKey( e => new { e.Spawnid, e.Rowid } );
            modelBuilder.Entity<CreatureTimedEmotes>().Property( p => p.Spawnid ).HasColumnName( "spawnid" );
            modelBuilder.Entity<CreatureTimedEmotes>().Property( p => p.Rowid ).HasColumnName( "rowid" );
            modelBuilder.Entity<CreatureTimedEmotes>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<CreatureTimedEmotes>().Property( p => p.Value ).HasColumnName( "value" );
            modelBuilder.Entity<CreatureTimedEmotes>().Property( p => p.Msg ).HasColumnName( "msg" );
            modelBuilder.Entity<CreatureTimedEmotes>().Property( p => p.MsgType ).HasColumnName( "msg_type" );
            modelBuilder.Entity<CreatureTimedEmotes>().Property( p => p.MsgLang ).HasColumnName( "msg_lang" );
            modelBuilder.Entity<CreatureTimedEmotes>().Property( p => p.ExpireAfter ).HasColumnName( "expire_after" );

            modelBuilder.Entity<CreatureWaypoints>().ToTable( "creature_waypoints" );
            modelBuilder.Entity<CreatureWaypoints>().HasKey( e => new { e.Spawnid, e.Waypointid } );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Spawnid ).HasColumnName( "spawnid" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Waypointid ).HasColumnName( "waypointid" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Waittime ).HasColumnName( "waittime" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Forwardemoteoneshot ).HasColumnName( "forwardemoteoneshot" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Forwardemoteid ).HasColumnName( "forwardemoteid" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Backwardemoteoneshot ).HasColumnName( "backwardemoteoneshot" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Backwardemoteid ).HasColumnName( "backwardemoteid" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Forwardskinid ).HasColumnName( "forwardskinid" );
            modelBuilder.Entity<CreatureWaypoints>().Property( p => p.Backwardskinid ).HasColumnName( "backwardskinid" );

            modelBuilder.Entity<CreatureWaypointsManual>().ToTable( "creature_waypoints_manual" );
            modelBuilder.Entity<CreatureWaypointsManual>().HasKey( e => new { e.GroupId, e.WaypointId } );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.GroupId ).HasColumnName( "group_id" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.WaypointId ).HasColumnName( "waypoint_id" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.WaitTime ).HasColumnName( "wait_time" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.ForwardEmoteOneshot ).HasColumnName( "forward_emote_oneshot" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.ForwardEmoteId ).HasColumnName( "forward_emote_id" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.BackwardEmoteOneshot ).HasColumnName( "backward_emote_oneshot" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.BackwardEmoteId ).HasColumnName( "backward_emote_id" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.ForwardSkinId ).HasColumnName( "forward_skin_id" );
            modelBuilder.Entity<CreatureWaypointsManual>().Property( p => p.BackwardSkinId ).HasColumnName( "backward_skin_id" );

            modelBuilder.Entity<DisplayBoundingBoxes>().ToTable( "display_bounding_boxes" );
            modelBuilder.Entity<DisplayBoundingBoxes>().Property( p => p.Displayid ).HasColumnName( "displayid" );
            modelBuilder.Entity<DisplayBoundingBoxes>().Property( p => p.Lowx ).HasColumnName( "lowx" );
            modelBuilder.Entity<DisplayBoundingBoxes>().Property( p => p.Lowy ).HasColumnName( "lowy" );
            modelBuilder.Entity<DisplayBoundingBoxes>().Property( p => p.Lowz ).HasColumnName( "lowz" );
            modelBuilder.Entity<DisplayBoundingBoxes>().Property( p => p.Highx ).HasColumnName( "highx" );
            modelBuilder.Entity<DisplayBoundingBoxes>().Property( p => p.Highy ).HasColumnName( "highy" );
            modelBuilder.Entity<DisplayBoundingBoxes>().Property( p => p.Highz ).HasColumnName( "highz" );
            modelBuilder.Entity<DisplayBoundingBoxes>().Property( p => p.Boundradius ).HasColumnName( "boundradius" );

            modelBuilder.Entity<EventCreatureSpawns>().ToTable( "event_creature_spawns" );
            modelBuilder.Entity<EventCreatureSpawns>().HasKey( e => new { e.Id } );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.EventEntry ).HasColumnName( "event_entry" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<EventCreatureSpawns>().HasIndex( e => e.Entry );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Map ).HasColumnName( "map" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Movetype ).HasColumnName( "movetype" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Displayid ).HasColumnName( "displayid" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Bytes0 ).HasColumnName( "bytes0" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Bytes1 ).HasColumnName( "bytes1" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Bytes2 ).HasColumnName( "bytes2" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.EmoteState ).HasColumnName( "emote_state" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.NpcRespawnLink ).HasColumnName( "npc_respawn_link" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.ChannelSpell ).HasColumnName( "channel_spell" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.ChannelTargetSqlid ).HasColumnName( "channel_target_sqlid" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.ChannelTargetSqlidCreature ).HasColumnName( "channel_target_sqlid_creature" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Standstate ).HasColumnName( "standstate" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.DeathState ).HasColumnName( "death_state" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Mountdisplayid ).HasColumnName( "mountdisplayid" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Slot1item ).HasColumnName( "slot1item" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Slot2item ).HasColumnName( "slot2item" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Slot3item ).HasColumnName( "slot3item" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Canfly ).HasColumnName( "CanFly" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.Phase ).HasColumnName( "phase" );
            modelBuilder.Entity<EventCreatureSpawns>().Property( p => p.WaypointGroup ).HasColumnName( "waypoint_group" );

            modelBuilder.Entity<EventGameobjectSpawns>().ToTable( "event_gameobject_spawns" );
            modelBuilder.Entity<EventGameobjectSpawns>().HasKey( e => new { e.EventEntry, e.Id } );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.EventEntry ).HasColumnName( "event_entry" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<EventGameobjectSpawns>().HasIndex( e => e.Entry );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Map ).HasColumnName( "map" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Facing ).HasColumnName( "facing" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Orientation1 ).HasColumnName( "orientation1" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Orientation2 ).HasColumnName( "orientation2" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Orientation3 ).HasColumnName( "orientation3" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Orientation4 ).HasColumnName( "orientation4" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.State ).HasColumnName( "state" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Scale ).HasColumnName( "scale" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Respawnnpclink ).HasColumnName( "respawnNpcLink" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Phase ).HasColumnName( "phase" );
            modelBuilder.Entity<EventGameobjectSpawns>().Property( p => p.Overrides ).HasColumnName( "overrides" );

            modelBuilder.Entity<EventProperties>().ToTable( "event_properties" );
            modelBuilder.Entity<EventProperties>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<EventProperties>().Property( p => p.StartTime ).HasColumnName( "start_time" );
            modelBuilder.Entity<EventProperties>().Property( p => p.EndTime ).HasColumnName( "end_time" );
            modelBuilder.Entity<EventProperties>().Property( p => p.Occurence ).HasColumnName( "occurence" );
            modelBuilder.Entity<EventProperties>().Property( p => p.Length ).HasColumnName( "length" );
            modelBuilder.Entity<EventProperties>().Property( p => p.Holiday ).HasColumnName( "holiday" );
            modelBuilder.Entity<EventProperties>().Property( p => p.Description ).HasColumnName( "description" );
            modelBuilder.Entity<EventProperties>().Property( p => p.WorldEvent ).HasColumnName( "world_event" );
            modelBuilder.Entity<EventProperties>().Property( p => p.Announce ).HasColumnName( "announce" );

            modelBuilder.Entity<EventScripts>().ToTable( "event_scripts" );
            modelBuilder.Entity<EventScripts>().Property( p => p.EventId ).HasColumnName( "event_id" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Function ).HasColumnName( "function" );
            modelBuilder.Entity<EventScripts>().Property( p => p.ScriptType ).HasColumnName( "script_type" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Data1 ).HasColumnName( "data_1" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Data2 ).HasColumnName( "data_2" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Data3 ).HasColumnName( "data_3" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Data4 ).HasColumnName( "data_4" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Data5 ).HasColumnName( "data_5" );
            modelBuilder.Entity<EventScripts>().Property( p => p.X ).HasColumnName( "x" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Y ).HasColumnName( "y" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Z ).HasColumnName( "z" );
            modelBuilder.Entity<EventScripts>().Property( p => p.O ).HasColumnName( "o" );
            modelBuilder.Entity<EventScripts>().Property( p => p.Delay ).HasColumnName( "delay" );
            modelBuilder.Entity<EventScripts>().Property( p => p.NextEvent ).HasColumnName( "next_event" );

            modelBuilder.Entity<Fishing>().ToTable( "fishing" );
            modelBuilder.Entity<Fishing>().Property( p => p.Zone ).HasColumnName( "zone" );
            modelBuilder.Entity<Fishing>().Property( p => p.Minskill ).HasColumnName( "MinSkill" );
            modelBuilder.Entity<Fishing>().Property( p => p.Maxskill ).HasColumnName( "MaxSkill" );

            modelBuilder.Entity<GameobjectProperties>().ToTable( "gameobject_properties" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.DisplayId ).HasColumnName( "display_id" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.CategoryName ).HasColumnName( "category_name" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.CastBarText ).HasColumnName( "cast_bar_text" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Unkstr ).HasColumnName( "UnkStr" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter0 ).HasColumnName( "parameter_0" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter1 ).HasColumnName( "parameter_1" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter2 ).HasColumnName( "parameter_2" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter3 ).HasColumnName( "parameter_3" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter4 ).HasColumnName( "parameter_4" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter5 ).HasColumnName( "parameter_5" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter6 ).HasColumnName( "parameter_6" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter7 ).HasColumnName( "parameter_7" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter8 ).HasColumnName( "parameter_8" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter9 ).HasColumnName( "parameter_9" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter10 ).HasColumnName( "parameter_10" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter11 ).HasColumnName( "parameter_11" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter12 ).HasColumnName( "parameter_12" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter13 ).HasColumnName( "parameter_13" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter14 ).HasColumnName( "parameter_14" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter15 ).HasColumnName( "parameter_15" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter16 ).HasColumnName( "parameter_16" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter17 ).HasColumnName( "parameter_17" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter18 ).HasColumnName( "parameter_18" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter19 ).HasColumnName( "parameter_19" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter20 ).HasColumnName( "parameter_20" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter21 ).HasColumnName( "parameter_21" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter22 ).HasColumnName( "parameter_22" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Parameter23 ).HasColumnName( "parameter_23" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Size ).HasColumnName( "size" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Questitem1 ).HasColumnName( "QuestItem1" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Questitem2 ).HasColumnName( "QuestItem2" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Questitem3 ).HasColumnName( "QuestItem3" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Questitem4 ).HasColumnName( "QuestItem4" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Questitem5 ).HasColumnName( "QuestItem5" );
            modelBuilder.Entity<GameobjectProperties>().Property( p => p.Questitem6 ).HasColumnName( "QuestItem6" );

            modelBuilder.Entity<GameobjectQuestFinisher>().ToTable( "gameobject_quest_finisher" );
            modelBuilder.Entity<GameobjectQuestFinisher>().HasKey( e => new { e.Id, e.Quest } );
            modelBuilder.Entity<GameobjectQuestFinisher>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<GameobjectQuestFinisher>().Property( p => p.Quest ).HasColumnName( "quest" );

            modelBuilder.Entity<GameobjectQuestItemBinding>().ToTable( "gameobject_quest_item_binding" );
            modelBuilder.Entity<GameobjectQuestItemBinding>().HasKey( e => new { e.Entry, e.Quest, e.Item } );
            modelBuilder.Entity<GameobjectQuestItemBinding>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<GameobjectQuestItemBinding>().Property( p => p.Quest ).HasColumnName( "quest" );
            modelBuilder.Entity<GameobjectQuestItemBinding>().Property( p => p.Item ).HasColumnName( "item" );
            modelBuilder.Entity<GameobjectQuestItemBinding>().Property( p => p.ItemCount ).HasColumnName( "item_count" );

            modelBuilder.Entity<GameobjectQuestPickupBinding>().ToTable( "gameobject_quest_pickup_binding" );
            modelBuilder.Entity<GameobjectQuestPickupBinding>().HasKey( e => new { e.Entry, e.Quest } );
            modelBuilder.Entity<GameobjectQuestPickupBinding>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<GameobjectQuestPickupBinding>().Property( p => p.Quest ).HasColumnName( "quest" );
            modelBuilder.Entity<GameobjectQuestPickupBinding>().Property( p => p.RequiredCount ).HasColumnName( "required_count" );

            modelBuilder.Entity<GameobjectQuestStarter>().ToTable( "gameobject_quest_starter" );
            modelBuilder.Entity<GameobjectQuestStarter>().HasKey( e => new { e.Id, e.Quest } );
            modelBuilder.Entity<GameobjectQuestStarter>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<GameobjectQuestStarter>().Property( p => p.Quest ).HasColumnName( "quest" );

            modelBuilder.Entity<GameobjectSpawns>().ToTable( "gameobject_spawns" );
            modelBuilder.Entity<GameobjectSpawns>().HasKey( e => new { e.Id } );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<GameobjectSpawns>().HasIndex( e => e.Entry );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Map ).HasColumnName( "map" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Facing ).HasColumnName( "facing" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Orientation1 ).HasColumnName( "orientation1" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Orientation2 ).HasColumnName( "orientation2" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Orientation3 ).HasColumnName( "orientation3" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Orientation4 ).HasColumnName( "orientation4" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.State ).HasColumnName( "state" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Scale ).HasColumnName( "scale" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Respawnnpclink ).HasColumnName( "respawnNpcLink" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Phase ).HasColumnName( "phase" );
            modelBuilder.Entity<GameobjectSpawns>().Property( p => p.Overrides ).HasColumnName( "overrides" );

            modelBuilder.Entity<GameobjectStaticspawns>().ToTable( "gameobject_staticspawns" );
            modelBuilder.Entity<GameobjectStaticspawns>().HasKey( e => new { e.Id } );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<GameobjectStaticspawns>().HasIndex( e => e.Entry );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Map ).HasColumnName( "map" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Facing ).HasColumnName( "facing" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Orientation1 ).HasColumnName( "orientation1" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Orientation2 ).HasColumnName( "orientation2" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Orientation3 ).HasColumnName( "orientation3" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Orientation4 ).HasColumnName( "orientation4" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.State ).HasColumnName( "state" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Scale ).HasColumnName( "scale" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Respawnnpclink ).HasColumnName( "respawnNpcLink" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Phase ).HasColumnName( "phase" );
            modelBuilder.Entity<GameobjectStaticspawns>().Property( p => p.Overrides ).HasColumnName( "overrides" );

            modelBuilder.Entity<GameobjectTeleports>().ToTable( "gameobject_teleports" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.Mapid ).HasColumnName( "mapid" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.XPos ).HasColumnName( "x_pos" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.YPos ).HasColumnName( "y_pos" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.ZPos ).HasColumnName( "z_pos" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.RequiredLevel ).HasColumnName( "required_level" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.RequiredClass ).HasColumnName( "required_class" );
            modelBuilder.Entity<GameobjectTeleports>().Property( p => p.RequiredAchievement ).HasColumnName( "required_achievement" );

            modelBuilder.Entity<GossipMenuOption>().ToTable( "gossip_menu_option" );
            modelBuilder.Entity<GossipMenuOption>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<GossipMenuOption>().Property( p => p.OptionText ).HasColumnName( "option_text" );

            modelBuilder.Entity<Graveyards>().ToTable( "graveyards" );
            modelBuilder.Entity<Graveyards>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<Graveyards>().Property( p => p.PositionX ).HasColumnName( "position_x" );
            modelBuilder.Entity<Graveyards>().Property( p => p.PositionY ).HasColumnName( "position_y" );
            modelBuilder.Entity<Graveyards>().Property( p => p.PositionZ ).HasColumnName( "position_z" );
            modelBuilder.Entity<Graveyards>().Property( p => p.Orientation ).HasColumnName( "orientation" );
            modelBuilder.Entity<Graveyards>().Property( p => p.Zoneid ).HasColumnName( "zoneid" );
            modelBuilder.Entity<Graveyards>().Property( p => p.Adjacentzoneid ).HasColumnName( "adjacentzoneid" );
            modelBuilder.Entity<Graveyards>().Property( p => p.Mapid ).HasColumnName( "mapid" );
            modelBuilder.Entity<Graveyards>().Property( p => p.Faction ).HasColumnName( "faction" );
            modelBuilder.Entity<Graveyards>().Property( p => p.Name ).HasColumnName( "name" );

            modelBuilder.Entity<InstanceBosses>().ToTable( "instance_bosses" );
            modelBuilder.Entity<InstanceBosses>().HasKey( e => new { e.Mapid, e.Creatureid } );
            modelBuilder.Entity<InstanceBosses>().Property( p => p.Mapid ).HasColumnName( "mapid" );
            modelBuilder.Entity<InstanceBosses>().Property( p => p.Creatureid ).HasColumnName( "creatureid" );
            modelBuilder.Entity<InstanceBosses>().Property( p => p.Trash ).HasColumnName( "trash" );
            modelBuilder.Entity<InstanceBosses>().Property( p => p.TrashRespawnOverride ).HasColumnName( "trash_respawn_override" );

            modelBuilder.Entity<ItemPages>().ToTable( "item_pages" );
            modelBuilder.Entity<ItemPages>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<ItemPages>().Property( p => p.Text ).HasColumnName( "text" );
            modelBuilder.Entity<ItemPages>().Property( p => p.NextPage ).HasColumnName( "next_page" );

            modelBuilder.Entity<ItemProperties>().ToTable( "item_properties" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Class ).HasColumnName( "class" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Subclass ).HasColumnName( "subclass" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Field4 ).HasColumnName( "field4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Name1 ).HasColumnName( "name1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Displayid ).HasColumnName( "displayid" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Quality ).HasColumnName( "quality" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Flags ).HasColumnName( "flags" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Flags2 ).HasColumnName( "flags2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Buyprice ).HasColumnName( "buyprice" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Sellprice ).HasColumnName( "sellprice" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Inventorytype ).HasColumnName( "inventorytype" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Allowableclass ).HasColumnName( "allowableclass" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Allowablerace ).HasColumnName( "allowablerace" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Itemlevel ).HasColumnName( "itemlevel" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Requiredlevel ).HasColumnName( "requiredlevel" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Requiredskill ).HasColumnName( "RequiredSkill" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Requiredskillrank ).HasColumnName( "RequiredSkillRank" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Requiredspell ).HasColumnName( "RequiredSpell" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Requiredplayerrank1 ).HasColumnName( "RequiredPlayerRank1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Requiredplayerrank2 ).HasColumnName( "RequiredPlayerRank2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Requiredfaction ).HasColumnName( "RequiredFaction" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Requiredfactionstanding ).HasColumnName( "RequiredFactionStanding" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Unique ).HasColumnName( "Unique" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Maxcount ).HasColumnName( "maxcount" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Containerslots ).HasColumnName( "ContainerSlots" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Itemstatscount ).HasColumnName( "itemstatscount" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType1 ).HasColumnName( "stat_type1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue1 ).HasColumnName( "stat_value1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType2 ).HasColumnName( "stat_type2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue2 ).HasColumnName( "stat_value2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType3 ).HasColumnName( "stat_type3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue3 ).HasColumnName( "stat_value3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType4 ).HasColumnName( "stat_type4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue4 ).HasColumnName( "stat_value4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType5 ).HasColumnName( "stat_type5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue5 ).HasColumnName( "stat_value5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType6 ).HasColumnName( "stat_type6" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue6 ).HasColumnName( "stat_value6" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType7 ).HasColumnName( "stat_type7" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue7 ).HasColumnName( "stat_value7" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType8 ).HasColumnName( "stat_type8" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue8 ).HasColumnName( "stat_value8" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType9 ).HasColumnName( "stat_type9" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue9 ).HasColumnName( "stat_value9" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatType10 ).HasColumnName( "stat_type10" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.StatValue10 ).HasColumnName( "stat_value10" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Scaledstatsdistributionid ).HasColumnName( "ScaledStatsDistributionId" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Scaledstatsdistributionflags ).HasColumnName( "ScaledStatsDistributionFlags" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.DmgMin1 ).HasColumnName( "dmg_min1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.DmgMax1 ).HasColumnName( "dmg_max1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.DmgType1 ).HasColumnName( "dmg_type1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.DmgMin2 ).HasColumnName( "dmg_min2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.DmgMax2 ).HasColumnName( "dmg_max2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.DmgType2 ).HasColumnName( "dmg_type2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Armor ).HasColumnName( "armor" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.HolyRes ).HasColumnName( "holy_res" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.FireRes ).HasColumnName( "fire_res" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.NatureRes ).HasColumnName( "nature_res" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.FrostRes ).HasColumnName( "frost_res" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.ShadowRes ).HasColumnName( "shadow_res" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.ArcaneRes ).HasColumnName( "arcane_res" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Delay ).HasColumnName( "delay" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.AmmoType ).HasColumnName( "ammo_type" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Range ).HasColumnName( "range" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellid1 ).HasColumnName( "spellid_1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spelltrigger1 ).HasColumnName( "spelltrigger_1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcharges1 ).HasColumnName( "spellcharges_1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcooldown1 ).HasColumnName( "spellcooldown_1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategory1 ).HasColumnName( "spellcategory_1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategorycooldown1 ).HasColumnName( "spellcategorycooldown_1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellid2 ).HasColumnName( "spellid_2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spelltrigger2 ).HasColumnName( "spelltrigger_2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcharges2 ).HasColumnName( "spellcharges_2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcooldown2 ).HasColumnName( "spellcooldown_2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategory2 ).HasColumnName( "spellcategory_2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategorycooldown2 ).HasColumnName( "spellcategorycooldown_2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellid3 ).HasColumnName( "spellid_3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spelltrigger3 ).HasColumnName( "spelltrigger_3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcharges3 ).HasColumnName( "spellcharges_3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcooldown3 ).HasColumnName( "spellcooldown_3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategory3 ).HasColumnName( "spellcategory_3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategorycooldown3 ).HasColumnName( "spellcategorycooldown_3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellid4 ).HasColumnName( "spellid_4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spelltrigger4 ).HasColumnName( "spelltrigger_4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcharges4 ).HasColumnName( "spellcharges_4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcooldown4 ).HasColumnName( "spellcooldown_4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategory4 ).HasColumnName( "spellcategory_4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategorycooldown4 ).HasColumnName( "spellcategorycooldown_4" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellid5 ).HasColumnName( "spellid_5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spelltrigger5 ).HasColumnName( "spelltrigger_5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcharges5 ).HasColumnName( "spellcharges_5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcooldown5 ).HasColumnName( "spellcooldown_5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategory5 ).HasColumnName( "spellcategory_5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Spellcategorycooldown5 ).HasColumnName( "spellcategorycooldown_5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Bonding ).HasColumnName( "bonding" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Description ).HasColumnName( "description" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.PageId ).HasColumnName( "page_id" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.PageLanguage ).HasColumnName( "page_language" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.PageMaterial ).HasColumnName( "page_material" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.QuestId ).HasColumnName( "quest_id" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.LockId ).HasColumnName( "lock_id" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.LockMaterial ).HasColumnName( "lock_material" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Sheathid ).HasColumnName( "sheathID" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Randomprop ).HasColumnName( "randomprop" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Randomsuffix ).HasColumnName( "randomsuffix" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Block ).HasColumnName( "block" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Itemset ).HasColumnName( "itemset" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Maxdurability ).HasColumnName( "MaxDurability" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Zonenameid ).HasColumnName( "ZoneNameID" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Mapid ).HasColumnName( "mapid" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Bagfamily ).HasColumnName( "bagfamily" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Totemcategory ).HasColumnName( "TotemCategory" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.SocketColor1 ).HasColumnName( "socket_color_1" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Unk2013 ).HasColumnName( "unk201_3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.SocketColor2 ).HasColumnName( "socket_color_2" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Unk2015 ).HasColumnName( "unk201_5" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.SocketColor3 ).HasColumnName( "socket_color_3" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Unk2017 ).HasColumnName( "unk201_7" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.SocketBonus ).HasColumnName( "socket_bonus" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Gemproperties ).HasColumnName( "GemProperties" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Reqdisenchantskill ).HasColumnName( "ReqDisenchantSkill" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Armordamagemodifier ).HasColumnName( "ArmorDamageModifier" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Existingduration ).HasColumnName( "existingduration" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Itemlimitcategoryid ).HasColumnName( "ItemLimitCategoryId" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.Holidayid ).HasColumnName( "HolidayId" );
            modelBuilder.Entity<ItemProperties>().Property( p => p.FoodType ).HasColumnName( "food_type" );

            modelBuilder.Entity<ItemQuestAssociation>().ToTable( "item_quest_association" );
            modelBuilder.Entity<ItemQuestAssociation>().HasKey( e => new { e.Item, e.Quest } );
            modelBuilder.Entity<ItemQuestAssociation>().Property( p => p.Item ).HasColumnName( "item" );
            modelBuilder.Entity<ItemQuestAssociation>().Property( p => p.Quest ).HasColumnName( "quest" );
            modelBuilder.Entity<ItemQuestAssociation>().Property( p => p.ItemCount ).HasColumnName( "item_count" );

            modelBuilder.Entity<ItemRandomPropGroups>().ToTable( "item_randomprop_groups" );
            modelBuilder.Entity<ItemRandomPropGroups>().HasKey( e => new { e.EntryId, e.RandompropsEntryid } );
            modelBuilder.Entity<ItemRandomPropGroups>().Property( p => p.EntryId ).HasColumnName( "entry_id" );
            modelBuilder.Entity<ItemRandomPropGroups>().Property( p => p.RandompropsEntryid ).HasColumnName( "randomprops_entryid" );
            modelBuilder.Entity<ItemRandomPropGroups>().Property( p => p.Chance ).HasColumnName( "chance" );

            modelBuilder.Entity<ItemRandomSuffixGroups>().ToTable( "item_randomsuffix_groups" );
            modelBuilder.Entity<ItemRandomSuffixGroups>().HasKey( e => new { e.EntryId, e.RandomsuffixEntryid } );
            modelBuilder.Entity<ItemRandomSuffixGroups>().Property( p => p.EntryId ).HasColumnName( "entry_id" );
            modelBuilder.Entity<ItemRandomSuffixGroups>().Property( p => p.RandomsuffixEntryid ).HasColumnName( "randomsuffix_entryid" );
            modelBuilder.Entity<ItemRandomSuffixGroups>().Property( p => p.Chance ).HasColumnName( "chance" );

            modelBuilder.Entity<ItemSetLinkedItemSetBonus>().ToTable( "itemset_linked_itemsetbonus" );
            modelBuilder.Entity<ItemSetLinkedItemSetBonus>().Property( p => p.Itemset ).HasColumnName( "itemset" );
            modelBuilder.Entity<ItemSetLinkedItemSetBonus>().Property( p => p.ItemsetBonus ).HasColumnName( "itemset_bonus" );

            modelBuilder.Entity<LfgDungeonRewards>().ToTable( "lfg_dungeon_rewards" );
            modelBuilder.Entity<LfgDungeonRewards>().HasKey( e => new { e.DungeonId, e.MaxLevel } );
            modelBuilder.Entity<LfgDungeonRewards>().Property( p => p.DungeonId ).HasColumnName( "dungeon_id" );
            modelBuilder.Entity<LfgDungeonRewards>().Property( p => p.MaxLevel ).HasColumnName( "max_level" );
            modelBuilder.Entity<LfgDungeonRewards>().Property( p => p.QuestId1 ).HasColumnName( "quest_id_1" );
            modelBuilder.Entity<LfgDungeonRewards>().Property( p => p.MoneyVar1 ).HasColumnName( "money_var_1" );
            modelBuilder.Entity<LfgDungeonRewards>().Property( p => p.XpVar1 ).HasColumnName( "xp_var_1" );
            modelBuilder.Entity<LfgDungeonRewards>().Property( p => p.QuestId2 ).HasColumnName( "quest_id_2" );
            modelBuilder.Entity<LfgDungeonRewards>().Property( p => p.MoneyVar2 ).HasColumnName( "money_var_2" );
            modelBuilder.Entity<LfgDungeonRewards>().Property( p => p.XpVar2 ).HasColumnName( "xp_var_2" );

            modelBuilder.Entity<LocalesCreature>().ToTable( "locales_creature" );
            modelBuilder.Entity<LocalesCreature>().HasKey( e => new { e.Id, e.LanguageCode } );
            modelBuilder.Entity<LocalesCreature>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<LocalesCreature>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesCreature>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<LocalesCreature>().Property( p => p.Subname ).HasColumnName( "subname" );

            modelBuilder.Entity<LocalesGameobject>().ToTable( "locales_gameobject" );
            modelBuilder.Entity<LocalesGameobject>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesGameobject>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesGameobject>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesGameobject>().Property( p => p.Name ).HasColumnName( "name" );

            modelBuilder.Entity<LocalesGossipMenuOption>().ToTable( "locales_gossip_menu_option" );
            modelBuilder.Entity<LocalesGossipMenuOption>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesGossipMenuOption>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesGossipMenuOption>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesGossipMenuOption>().Property( p => p.OptionText ).HasColumnName( "option_text" );

            modelBuilder.Entity<LocalesItem>().ToTable( "locales_item" );
            modelBuilder.Entity<LocalesItem>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesItem>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesItem>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesItem>().Property( p => p.Name ).HasColumnName( "name" );
            modelBuilder.Entity<LocalesItem>().Property( p => p.Description ).HasColumnName( "description" );

            modelBuilder.Entity<LocalesItemPages>().ToTable( "locales_item_pages" );
            modelBuilder.Entity<LocalesItemPages>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesItemPages>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesItemPages>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesItemPages>().Property( p => p.Text ).HasColumnName( "text" );

            modelBuilder.Entity<LocalesNpcMonstersay>().ToTable( "locales_npc_monstersay" );
            modelBuilder.Entity<LocalesNpcMonstersay>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesNpcMonstersay>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesNpcMonstersay>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesNpcMonstersay>().Property( p => p.Monstername ).HasColumnName( "monstername" );
            modelBuilder.Entity<LocalesNpcMonstersay>().Property( p => p.Text0 ).HasColumnName( "text0" );
            modelBuilder.Entity<LocalesNpcMonstersay>().Property( p => p.Text1 ).HasColumnName( "text1" );
            modelBuilder.Entity<LocalesNpcMonstersay>().Property( p => p.Text2 ).HasColumnName( "text2" );
            modelBuilder.Entity<LocalesNpcMonstersay>().Property( p => p.Text3 ).HasColumnName( "text3" );
            modelBuilder.Entity<LocalesNpcMonstersay>().Property( p => p.Text4 ).HasColumnName( "text4" );

            modelBuilder.Entity<LocalesNpcScriptText>().ToTable( "locales_npc_script_text" );
            modelBuilder.Entity<LocalesNpcScriptText>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesNpcScriptText>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesNpcScriptText>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesNpcScriptText>().Property( p => p.Text ).HasColumnName( "text" );

            modelBuilder.Entity<LocalesNpcText>().ToTable( "locales_npc_text" );
            modelBuilder.Entity<LocalesNpcText>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text0 ).HasColumnName( "text0" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text01 ).HasColumnName( "text0_1" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text1 ).HasColumnName( "text1" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text11 ).HasColumnName( "text1_1" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text2 ).HasColumnName( "text2" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text21 ).HasColumnName( "text2_1" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text3 ).HasColumnName( "text3" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text31 ).HasColumnName( "text3_1" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text4 ).HasColumnName( "text4" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text41 ).HasColumnName( "text4_1" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text5 ).HasColumnName( "text5" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text51 ).HasColumnName( "text5_1" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text6 ).HasColumnName( "text6" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text61 ).HasColumnName( "text6_1" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text7 ).HasColumnName( "text7" );
            modelBuilder.Entity<LocalesNpcText>().Property( p => p.Text71 ).HasColumnName( "text7_1" );

            modelBuilder.Entity<LocalesQuest>().ToTable( "locales_quest" );
            modelBuilder.Entity<LocalesQuest>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Title ).HasColumnName( "Title" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Details ).HasColumnName( "Details" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Objectives ).HasColumnName( "Objectives" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Completiontext ).HasColumnName( "CompletionText" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Incompletetext ).HasColumnName( "IncompleteText" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Endtext ).HasColumnName( "EndText" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Objectivetext1 ).HasColumnName( "ObjectiveText1" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Objectivetext2 ).HasColumnName( "ObjectiveText2" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Objectivetext3 ).HasColumnName( "ObjectiveText3" );
            modelBuilder.Entity<LocalesQuest>().Property( p => p.Objectivetext4 ).HasColumnName( "ObjectiveText4" );

            modelBuilder.Entity<LocalesWorldBroadcast>().ToTable( "locales_worldbroadcast" );
            modelBuilder.Entity<LocalesWorldBroadcast>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesWorldBroadcast>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesWorldBroadcast>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesWorldBroadcast>().Property( p => p.Text ).HasColumnName( "text" );

            modelBuilder.Entity<LocalesWorldMapInfo>().ToTable( "locales_worldmap_info" );
            modelBuilder.Entity<LocalesWorldMapInfo>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesWorldMapInfo>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesWorldMapInfo>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesWorldMapInfo>().Property( p => p.Text ).HasColumnName( "text" );

            modelBuilder.Entity<LocalesWorldStringTable>().ToTable( "locales_worldstring_table" );
            modelBuilder.Entity<LocalesWorldStringTable>().HasKey( e => new { e.Entry, e.LanguageCode } );
            modelBuilder.Entity<LocalesWorldStringTable>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<LocalesWorldStringTable>().Property( p => p.LanguageCode ).HasColumnName( "language_code" );
            modelBuilder.Entity<LocalesWorldStringTable>().Property( p => p.Text ).HasColumnName( "text" );

            modelBuilder.Entity<LootCreatures>().ToTable( "loot_creatures" );
            modelBuilder.Entity<LootCreatures>().HasKey( e => new { e.Entryid, e.Itemid } );
            modelBuilder.Entity<LootCreatures>().Property( p => p.Entryid ).HasColumnName( "entryid" );
            modelBuilder.Entity<LootCreatures>().Property( p => p.Itemid ).HasColumnName( "itemid" );
            modelBuilder.Entity<LootCreatures>().Property( p => p.Normal10percentchance ).HasColumnName( "normal10percentchance" );
            modelBuilder.Entity<LootCreatures>().Property( p => p.Normal25percentchance ).HasColumnName( "normal25percentchance" );
            modelBuilder.Entity<LootCreatures>().Property( p => p.Heroic10percentchance ).HasColumnName( "heroic10percentchance" );
            modelBuilder.Entity<LootCreatures>().Property( p => p.Heroic25percentchance ).HasColumnName( "heroic25percentchance" );
            modelBuilder.Entity<LootCreatures>().Property( p => p.Mincount ).HasColumnName( "mincount" );
            modelBuilder.Entity<LootCreatures>().Property( p => p.Maxcount ).HasColumnName( "maxcount" );

            modelBuilder.Entity<LootFishing>().ToTable( "loot_fishing" );
            modelBuilder.Entity<LootFishing>().HasKey( e => new { e.Entryid, e.Itemid } );
            modelBuilder.Entity<LootFishing>().Property( p => p.Entryid ).HasColumnName( "entryid" );
            modelBuilder.Entity<LootFishing>().Property( p => p.Itemid ).HasColumnName( "itemid" );
            modelBuilder.Entity<LootFishing>().Property( p => p.Normal10percentchance ).HasColumnName( "normal10percentchance" );
            modelBuilder.Entity<LootFishing>().Property( p => p.Normal25percentchance ).HasColumnName( "normal25percentchance" );
            modelBuilder.Entity<LootFishing>().Property( p => p.Heroic10percentchance ).HasColumnName( "heroic10percentchance" );
            modelBuilder.Entity<LootFishing>().Property( p => p.Heroic25percentchance ).HasColumnName( "heroic25percentchance" );
            modelBuilder.Entity<LootFishing>().Property( p => p.Mincount ).HasColumnName( "mincount" );
            modelBuilder.Entity<LootFishing>().Property( p => p.Maxcount ).HasColumnName( "maxcount" );

            modelBuilder.Entity<LootGameObjects>().ToTable( "loot_gameobjects" );
            modelBuilder.Entity<LootGameObjects>().HasKey( e => new { e.Entryid, e.Itemid } );
            modelBuilder.Entity<LootGameObjects>().Property( p => p.Entryid ).HasColumnName( "entryid" );
            modelBuilder.Entity<LootGameObjects>().Property( p => p.Itemid ).HasColumnName( "itemid" );
            modelBuilder.Entity<LootGameObjects>().Property( p => p.Normal10percentchance ).HasColumnName( "normal10percentchance" );
            modelBuilder.Entity<LootGameObjects>().Property( p => p.Normal25percentchance ).HasColumnName( "normal25percentchance" );
            modelBuilder.Entity<LootGameObjects>().Property( p => p.Heroic10percentchance ).HasColumnName( "heroic10percentchance" );
            modelBuilder.Entity<LootGameObjects>().Property( p => p.Heroic25percentchance ).HasColumnName( "heroic25percentchance" );
            modelBuilder.Entity<LootGameObjects>().Property( p => p.Mincount ).HasColumnName( "mincount" );
            modelBuilder.Entity<LootGameObjects>().Property( p => p.Maxcount ).HasColumnName( "maxcount" );

            modelBuilder.Entity<LootItems>().ToTable( "loot_items" );
            modelBuilder.Entity<LootItems>().HasKey( e => new { e.Entryid, e.Itemid } );
            modelBuilder.Entity<LootItems>().Property( p => p.Entryid ).HasColumnName( "entryid" );
            modelBuilder.Entity<LootItems>().Property( p => p.Itemid ).HasColumnName( "itemid" );
            modelBuilder.Entity<LootItems>().Property( p => p.Normal10percentchance ).HasColumnName( "normal10percentchance" );
            modelBuilder.Entity<LootItems>().Property( p => p.Normal25percentchance ).HasColumnName( "normal25percentchance" );
            modelBuilder.Entity<LootItems>().Property( p => p.Heroic10percentchance ).HasColumnName( "heroic10percentchance" );
            modelBuilder.Entity<LootItems>().Property( p => p.Heroic25percentchance ).HasColumnName( "heroic25percentchance" );
            modelBuilder.Entity<LootItems>().Property( p => p.Mincount ).HasColumnName( "mincount" );
            modelBuilder.Entity<LootItems>().Property( p => p.Maxcount ).HasColumnName( "maxcount" );

            modelBuilder.Entity<LootPickpocketing>().ToTable( "loot_pickpocketing" );
            modelBuilder.Entity<LootPickpocketing>().HasKey( e => new { e.Entryid, e.Itemid } );
            modelBuilder.Entity<LootPickpocketing>().Property( p => p.Entryid ).HasColumnName( "entryid" );
            modelBuilder.Entity<LootPickpocketing>().Property( p => p.Itemid ).HasColumnName( "itemid" );
            modelBuilder.Entity<LootPickpocketing>().Property( p => p.Normal10percentchance ).HasColumnName( "normal10percentchance" );
            modelBuilder.Entity<LootPickpocketing>().Property( p => p.Normal25percentchance ).HasColumnName( "normal25percentchance" );
            modelBuilder.Entity<LootPickpocketing>().Property( p => p.Heroic10percentchance ).HasColumnName( "heroic10percentchance" );
            modelBuilder.Entity<LootPickpocketing>().Property( p => p.Heroic25percentchance ).HasColumnName( "heroic25percentchance" );
            modelBuilder.Entity<LootPickpocketing>().Property( p => p.Mincount ).HasColumnName( "mincount" );
            modelBuilder.Entity<LootPickpocketing>().Property( p => p.Maxcount ).HasColumnName( "maxcount" );

            modelBuilder.Entity<LootSkinning>().ToTable( "loot_skinning" );
            modelBuilder.Entity<LootSkinning>().HasKey( e => new { e.Entryid, e.Itemid } );
            modelBuilder.Entity<LootSkinning>().Property( p => p.Entryid ).HasColumnName( "entryid" );
            modelBuilder.Entity<LootSkinning>().Property( p => p.Itemid ).HasColumnName( "itemid" );
            modelBuilder.Entity<LootSkinning>().Property( p => p.Normal10percentchance ).HasColumnName( "normal10percentchance" );
            modelBuilder.Entity<LootSkinning>().Property( p => p.Normal25percentchance ).HasColumnName( "normal25percentchance" );
            modelBuilder.Entity<LootSkinning>().Property( p => p.Heroic10percentchance ).HasColumnName( "heroic10percentchance" );
            modelBuilder.Entity<LootSkinning>().Property( p => p.Heroic25percentchance ).HasColumnName( "heroic25percentchance" );
            modelBuilder.Entity<LootSkinning>().Property( p => p.Mincount ).HasColumnName( "mincount" );
            modelBuilder.Entity<LootSkinning>().Property( p => p.Maxcount ).HasColumnName( "maxcount" );

            modelBuilder.Entity<MapCheckpoint>().ToTable( "map_checkpoint" );
            modelBuilder.Entity<MapCheckpoint>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<MapCheckpoint>().Property( p => p.PrereqCheckpointId ).HasColumnName( "prereq_checkpoint_id" );
            modelBuilder.Entity<MapCheckpoint>().Property( p => p.CreatureId ).HasColumnName( "creature_id" );
            modelBuilder.Entity<MapCheckpoint>().Property( p => p.Name ).HasColumnName( "name" );

            modelBuilder.Entity<NpcGossipTextId>().ToTable( "npc_gossip_textid" );
            modelBuilder.Entity<NpcGossipTextId>().Property( p => p.Creatureid ).HasColumnName( "creatureid" );
            modelBuilder.Entity<NpcGossipTextId>().Property( p => p.Textid ).HasColumnName( "textid" );

            modelBuilder.Entity<NpcMonsterSay>().ToTable( "npc_monstersay" );
            modelBuilder.Entity<NpcMonsterSay>().HasKey( e => new { e.Entry, e.Event } );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Event ).HasColumnName( "event" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Chance ).HasColumnName( "chance" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Language ).HasColumnName( "language" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Monstername ).HasColumnName( "monstername" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Text0 ).HasColumnName( "text0" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Text1 ).HasColumnName( "text1" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Text2 ).HasColumnName( "text2" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Text3 ).HasColumnName( "text3" );
            modelBuilder.Entity<NpcMonsterSay>().Property( p => p.Text4 ).HasColumnName( "text4" );

            modelBuilder.Entity<NpcScriptText>().ToTable( "npc_script_text" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Text ).HasColumnName( "text" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.CreatureEntry ).HasColumnName( "creature_entry" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Id ).HasColumnName( "id" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Type ).HasColumnName( "type" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Language ).HasColumnName( "language" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Probability ).HasColumnName( "probability" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Emote ).HasColumnName( "emote" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Duration ).HasColumnName( "duration" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.Sound ).HasColumnName( "sound" );
            modelBuilder.Entity<NpcScriptText>().Property( p => p.BroadcastId ).HasColumnName( "broadcast_id" );

            modelBuilder.Entity<NpcText>().ToTable( "npc_text" );
            modelBuilder.Entity<NpcText>().Property( p => p.Entry ).HasColumnName( "entry" );
            modelBuilder.Entity<NpcText>().Property( p => p.Prob0 ).HasColumnName( "prob0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text00 ).HasColumnName( "text0_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text01 ).HasColumnName( "text0_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Lang0 ).HasColumnName( "lang0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay00 ).HasColumnName( "EmoteDelay0_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote00 ).HasColumnName( "Emote0_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay01 ).HasColumnName( "EmoteDelay0_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote01 ).HasColumnName( "Emote0_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay02 ).HasColumnName( "EmoteDelay0_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote02 ).HasColumnName( "Emote0_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Prob1 ).HasColumnName( "prob1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text10 ).HasColumnName( "text1_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text11 ).HasColumnName( "text1_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Lang1 ).HasColumnName( "lang1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay10 ).HasColumnName( "EmoteDelay1_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote10 ).HasColumnName( "Emote1_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay11 ).HasColumnName( "EmoteDelay1_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote11 ).HasColumnName( "Emote1_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay12 ).HasColumnName( "EmoteDelay1_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote12 ).HasColumnName( "Emote1_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Prob2 ).HasColumnName( "prob2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text20 ).HasColumnName( "text2_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text21 ).HasColumnName( "text2_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Lang2 ).HasColumnName( "lang2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay20 ).HasColumnName( "EmoteDelay2_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote20 ).HasColumnName( "Emote2_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay21 ).HasColumnName( "EmoteDelay2_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote21 ).HasColumnName( "Emote2_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay22 ).HasColumnName( "EmoteDelay2_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote22 ).HasColumnName( "Emote2_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Prob3 ).HasColumnName( "prob3" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text30 ).HasColumnName( "text3_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text31 ).HasColumnName( "text3_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Lang3 ).HasColumnName( "lang3" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay30 ).HasColumnName( "EmoteDelay3_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote30 ).HasColumnName( "Emote3_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay31 ).HasColumnName( "EmoteDelay3_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote31 ).HasColumnName( "Emote3_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay32 ).HasColumnName( "EmoteDelay3_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote32 ).HasColumnName( "Emote3_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Prob4 ).HasColumnName( "prob4" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text40 ).HasColumnName( "text4_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text41 ).HasColumnName( "text4_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Lang4 ).HasColumnName( "lang4" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay40 ).HasColumnName( "EmoteDelay4_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote40 ).HasColumnName( "Emote4_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay41 ).HasColumnName( "EmoteDelay4_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote41 ).HasColumnName( "Emote4_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay42 ).HasColumnName( "EmoteDelay4_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote42 ).HasColumnName( "Emote4_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Prob5 ).HasColumnName( "prob5" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text50 ).HasColumnName( "text5_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text51 ).HasColumnName( "text5_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Lang5 ).HasColumnName( "lang5" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay50 ).HasColumnName( "EmoteDelay5_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote50 ).HasColumnName( "Emote5_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay51 ).HasColumnName( "EmoteDelay5_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote51 ).HasColumnName( "Emote5_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay52 ).HasColumnName( "EmoteDelay5_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote52 ).HasColumnName( "Emote5_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Prob6 ).HasColumnName( "prob6" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text60 ).HasColumnName( "text6_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text61 ).HasColumnName( "text6_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Lang6 ).HasColumnName( "lang6" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay60 ).HasColumnName( "EmoteDelay6_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote60 ).HasColumnName( "Emote6_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay61 ).HasColumnName( "EmoteDelay6_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote61 ).HasColumnName( "Emote6_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay62 ).HasColumnName( "EmoteDelay6_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote62 ).HasColumnName( "Emote6_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Prob7 ).HasColumnName( "prob7" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text70 ).HasColumnName( "text7_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Text71 ).HasColumnName( "text7_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Lang7 ).HasColumnName( "lang7" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay70 ).HasColumnName( "EmoteDelay7_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote70 ).HasColumnName( "Emote7_0" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay71 ).HasColumnName( "EmoteDelay7_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote71 ).HasColumnName( "Emote7_1" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emotedelay72 ).HasColumnName( "EmoteDelay7_2" );
            modelBuilder.Entity<NpcText>().Property( p => p.Emote72 ).HasColumnName( "Emote7_2" );

        }
    }
}