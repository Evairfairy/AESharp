using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json;

namespace AESharp.Database.Configuration
{
    [JsonObject( MemberSerialization.OptIn )]
    internal sealed class MigrationConfig
    {
        [JsonProperty( "default", Required = Required.DisallowNull )]
        public DefaultMigrationSettings Default { get; private set; }

        [JsonProperty("logon", Required = Required.DisallowNull)]
        public MigrationSettings Logon { get; private set; }

        [JsonProperty("chars", Required = Required.DisallowNull)]
        public MigrationSettings Chars { get; private set; }

        [JsonProperty("world", Required = Required.DisallowNull)]
        public MigrationSettings World { get; private set; }

        public MigrationConfig MergeAll()
            => new MigrationConfig
            {
                Default = null,
                Logon = this.Logon?.MergeWith( this.Default ),
                Chars = this.Chars?.MergeWith( this.Default ),
                World = this.World?.MergeWith( this.Default ),
            };

        public void Deconstruct( out MigrationSettings logon, out MigrationSettings chars, out MigrationSettings world )
        {
            logon = this.Logon;
            chars = this.Chars;
            world = this.World;
        }
    }
}
