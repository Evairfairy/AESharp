using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AESharp.Database.Configuration
{
    [JsonObject( MemberSerialization.OptIn )]
    internal class DefaultMigrationSettings
    {
        [JsonProperty( "server", Required = Required.DisallowNull )]
        public string Server { get; protected set; }

        [JsonProperty("port", Required = Required.DisallowNull)]
        public ushort? Port { get; protected set; }

        [JsonProperty("username", Required = Required.DisallowNull)]
        public string Username { get; protected set; }

        [JsonProperty("mysql_password")]
        public string MySqlPassword { get; protected set; }

        [JsonProperty("lite_password")]
        public string LitePassword { get; protected set; }
    }
}
