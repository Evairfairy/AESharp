using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AESharp.Database.Configuration
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class DatabaseSettings
    {
        [JsonProperty("driver", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public DatabaseDriver Driver { get; set; }

        [JsonProperty("hostname", Required = Required.Always)]
        public string Hostname { get; set; }

        [JsonProperty("port", Required = Required.Always)]
        public ushort Port { get; set; }

        [JsonProperty("databases", Required = Required.Always)]
        public DatabasesSection Databases { get; set; }

        [JsonProperty("username", Required = Required.Always)]
        public string Username { get; set; }

        [JsonProperty("password", Required = Required.Always)]
        public string Password { get; set; }
    }
}