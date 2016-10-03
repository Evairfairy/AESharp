using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AESharp.Core.Configuration
{
    [JsonObject( MemberSerialization.OptIn )]
    public sealed class LogonSettings
    {
        [JsonProperty( "database", Required = Required.Always )]
        public DatabaseSettings Database { get; private set; }
    }
}
