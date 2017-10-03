using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using LiteDB;
using DbMigration = AESharp.Database.Entities.Models.Migration;

namespace AESharp.Database.Migrations
{
    internal sealed class Migrator<T>
    {
        private readonly LiteCollection<DbMigration> _migrationCollection;
        public IReadOnlyList<Migration<T>> Migrations { get; }

        private long Latest => this._migrationCollection.Max().AsInt64;
        private bool CanMigrate => this.Migrations.Count > 0 && this._migrationCollection != null;

        private Migrator( IReadOnlyList<Migration<T>> migrations, LiteDatabase db )
        {
            this.Migrations = migrations;
            this._migrationCollection = db?.GetCollection<DbMigration>( "__migrations__" );
            this._migrationCollection?.EnsureIndex( x => x.Id, unique: true );
        }

        public static Migrator<T> GetMigrationsFrom( Assembly asm, T instance, LiteDatabase db )
        {
            var migrationType = typeof( Migration<T> );
            var migrations = asm.GetTypes()
                                .Where( migrationType.IsAssignableFrom )
                                .Select( t => Activator.CreateInstance( t, instance ) )
                                .Cast<Migration<T>>()
                                .OrderBy( m => m.Id )
                                .ToArray();
            
            return new Migrator<T>( migrations, migrations.Length == 0 ? null : db );
        }

        /// <summary>
        ///     Run all migrations to upgrade the database.
        /// </summary>
        public void UpgradeAll()
        {
            if( !this.CanMigrate )
                return;

            var latest = this.Latest; // so we dont query multiple times
            var todo = this.Migrations.Where( m => m.Id > latest );

            foreach ( var migration in todo )
            {
                migration.Upgrade();
                var info = new DbMigration
                {
                    Id = migration.Id,
                    Description = migration.Description,
                    UpgradedAt = DateTime.UtcNow
                };

                this._migrationCollection.Insert( info );
            }
        }

        /// <summary>
        ///     Run all migrations up to (and including) the specified ID to perform a partial upgrade.
        /// </summary>
        public void UpgradeTo( long id )
        {
            if( !this.CanMigrate || id <= this.Latest )
                return;

            var latest = this.Latest;
            var todo = this.Migrations.Where( m => m.Id <= id && m.Id > latest );

            foreach( var migration in todo )
            {
                migration.Upgrade();
                var info = new DbMigration
                {
                    Id = migration.Id,
                    Description = migration.Description,
                    UpgradedAt = DateTime.UtcNow
                };

                this._migrationCollection.Insert( info );
            }
        }

        /// <summary>
        ///     Run all migrations to downgrade the database.
        /// </summary>
        public void DowngradeAll()
        {
            if( !this.CanMigrate )
                return;

            var latest = this.Latest;
            var todo = this.Migrations.Where( m => m.Id <= latest ).OrderByDescending( m => m.Id );

            foreach( var migration in todo )
            {
                migration.Downgrade();
                this._migrationCollection.Delete( m => m.Id == migration.Id );
            }
        }

        /// <summary>
        ///     Run all applicable migrations to roll back to the specified ID to performa a partial downgrade.
        /// </summary>
        public void DowngradeTo( long id )
        {
            if( !this.CanMigrate || id >= this.Latest )
                return;

            var latest = this.Latest;
            var todo = this.Migrations.Where( m => m.Id >= id && m.Id < latest );

            foreach( var migration in todo )
            {
                migration.Downgrade();
                this._migrationCollection.Delete( m => m.Id == migration.Id );
            }
        }
    }
}
