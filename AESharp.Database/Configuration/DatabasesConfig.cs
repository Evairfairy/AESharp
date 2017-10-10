using Newtonsoft.Json;

namespace AESharp.Database.Configuration
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class DatabasesConfig
    {
        [JsonProperty("accounts", Required = Required.Always)]
        public DatabaseSettings Accounts { get; set; }

        [JsonProperty("characters", Required = Required.Always)]
        public DatabaseSettings Characters { get; set; }

        [JsonProperty("world", Required = Required.Always)]
        public DatabaseSettings World { get; set; }
    }
}