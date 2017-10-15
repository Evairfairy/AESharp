using System;
using System.Linq;
using System.Reflection;
using AutoMapper;
using LiteDB;
using Microsoft.EntityFrameworkCore;

namespace AESharp.Database.Mapping
{
    internal abstract class DatabaseMapper<TSource, TDestination>
        where TSource : DbContext
        where TDestination : Entities.LiteDb.Database
    {
        protected DatabaseMapper( bool configure = true )
        {
            if( configure ) Mapper.Initialize( this.ConfigurMapping );
        }

        public abstract void ConfigurMapping( IMapperConfigurationExpression config );

        public virtual void MigrateDatabase( TSource source, TDestination destination )
        {
            var pairs = source.GetAllTables().Zip( destination.GetAllCollections(), ( s, c ) => ( s, c ) );
            var migrateGeneric = typeof( DatabaseMapper<TSource, TDestination> ).GetMethod(
                "MigrateTable",
                BindingFlags.Instance | BindingFlags.NonPublic
            );

            foreach ( var ( setProperty, collectionProperty ) in pairs )
            {
                var set = setProperty.GetGetMethod().Invoke( source, null );
                var collection = collectionProperty.GetGetMethod().Invoke( destination, null );
                var migrate = migrateGeneric.MakeGenericMethod(
                    setProperty.PropertyType.GetGenericArguments().First(),
                    collectionProperty.PropertyType.GetGenericArguments().First()
                );

                migrate.Invoke( this, new[] { set, collection } );
            }
        }

        protected virtual void MigrateTable<TSourceTable, TDestinationTable>(
            DbSet<TSourceTable> source,
            LiteCollection<TDestinationTable> destination
        )
            where TSourceTable : class
        {
            var total = source.LongCount();
            var name = source.GetTableName();
            var current = 0L;

            foreach( var item in source )
            {
                this.WriteProgress( name, ++current, total );
                var mapped = Mapper.Map<TDestinationTable>( item );

                destination.Insert( mapped );
            }

            Console.WriteLine();
        }

        protected virtual void WriteProgress( string table, long currentRow, long totalRowCount )
            => Console.Write(
                "\r  - Migrating {0} {1:0}% ({2:#,##}/{3:#,##})",
                table,
                currentRow / (double)totalRowCount * 100d,
                currentRow,
                totalRowCount
            );
    }
}
