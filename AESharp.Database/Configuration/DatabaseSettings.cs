using Newtonsoft.Json;

namespace AESharp.Database.Configuration
{
    [JsonObject(MemberSerialization.OptIn)]
    internal sealed class DatabaseSettings
    {
        [JsonProperty("filename", Required = Required.Always)]
        public string FileName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}