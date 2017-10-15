using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using LiteDB;
using Microsoft.EntityFrameworkCore;

namespace AESharp.Database.Mapping
{
    internal static class DatabaseHelpers
    {
        private const BindingFlags Flags = BindingFlags.Public | BindingFlags.Instance;

        public static string GetTableName<T>( this DbContext context )
            where T : class
            => context.Set<T>().GetTableName();

        public static string GetTableName<T>( this DbSet<T> set )
            where T : class
            => typeof( T ).GetCustomAttribute<TableAttribute>()?.Name;

        public static IEnumerable<PropertyInfo> GetAllTables<T>( this T context )
            where T : DbContext
            => from property in typeof( T ).GetProperties( DatabaseHelpers.Flags )
               let type = property.PropertyType
               where type.IsGenericType
               where typeof( DbSet<> ).IsAssignableFrom( type.GetGenericTypeDefinition() )
               select property;

        public static IEnumerable<PropertyInfo> GetAllCollections<T>( this T db )
            where T : Entities.LiteDb.Database
            => from property in typeof( T ).GetProperties( DatabaseHelpers.Flags )
               let type = property.PropertyType
               where type.IsGenericType
               where typeof( LiteCollection<> ).IsAssignableFrom( type.GetGenericTypeDefinition() )
               select property;
    }
}
