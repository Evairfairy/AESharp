using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace AESharp.Database.Configuration
{
    [JsonObject( MemberSerialization.OptIn )]
    internal sealed class MigrationSettings : DefaultMigrationSettings
    {
        [JsonProperty("mysql_database", Required = Required.DisallowNull)]
        public string MySqlDatabase { get; private set; }

        [JsonProperty("lite_database", Required = Required.DisallowNull)]
        public string LiteDatabase { get; private set; }

        public MigrationSettings MergeWith( DefaultMigrationSettings settings )
        {
            if( settings == null )
                return null;

            var merged = new MigrationSettings
            {
                Server = this.Server ?? settings.Server,
                Port = this.Port ?? settings.Port,
                Username = this.Username ?? settings.Username,
                MySqlPassword = this.MySqlPassword ?? settings.MySqlPassword,
                LitePassword = this.LitePassword ?? settings.LitePassword,
                MySqlDatabase = this.MySqlDatabase,
                LiteDatabase = this.LiteDatabase
            };

            CheckRequiredField( x => x.Server );
            CheckRequiredField( x => x.Port );
            CheckRequiredField( x => x.Username );
            CheckRequiredField( x => x.MySqlDatabase );
            CheckRequiredField( x => x.LiteDatabase );

            return merged;

            void CheckRequiredField<T>( Expression<Func<MigrationSettings, T>> expr )
            {
                const string ExceptionMessage = "Missing required configuration setting";

                if( !( expr.Body is MemberExpression member ) || !( member.Member is PropertyInfo property ) )
                    throw new Exception( "programmer is a dummy" );

                var jsonName = property.GetCustomAttribute<JsonPropertyAttribute>().PropertyName;
                var lambda = expr.Compile();
                var result = lambda.Invoke( merged );
                if( lambda.Invoke( merged ) == null )
                    throw new ArgumentException( ExceptionMessage, $"{property.Name} ({jsonName})" );
            }
        }
    }
}
