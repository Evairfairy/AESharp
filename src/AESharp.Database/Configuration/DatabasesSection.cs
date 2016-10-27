using Newtonsoft.Json;

namespace AESharp.Database.Configuration
{
    [JsonObject( MemberSerialization.OptIn )]
    internal sealed class DatabasesSection
    {
        [JsonProperty( "logon", Required = Required.Always )]
        public string LogonDatabase { get; set; }

        [JsonProperty( "chars", Required = Required.Always )]
        public string CharactersDatabase { get; set; }

        [JsonProperty( "world", Required = Required.Always )]
        public string WorldDatabase { get; set; }
    }
}