using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AESharp.Database.Configuration
{
    [JsonObject( MemberSerialization.OptIn )]
    public sealed class DatabaseSettings
    {
        [JsonProperty( "driver" )]
        [JsonConverter( typeof( StringEnumConverter ) )]
        public DatabaseDriver Driver { get; private set; }

        [JsonProperty( "hostname" )]
        public string Hostname { get; private set; }

        [JsonProperty( "port" )]
        public ushort Port { get; private set; }

        [JsonProperty( "database" )]
        public string Database { get; private set; }

        [JsonProperty( "username" )]
        public string Username { get; private set; }

        [JsonProperty( "password" )]
        public string Password { get; private set; }
    }
}