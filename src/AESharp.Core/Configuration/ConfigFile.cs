using System;
using System.IO;
using Newtonsoft.Json;

namespace AESharp.Core.Configuration
{
    public static class ConfigFile
    {
        private static readonly string RootDirectory;

        static ConfigFile()
        {
            RootDirectory = Path.Combine( Directory.GetCurrentDirectory(), "configs" );
        }

        public static T Load<T>( string name )
        {
            var path = Path.Combine( RootDirectory,
                                     $"{name}{( name.EndsWith( ".json", StringComparison.OrdinalIgnoreCase ) ? "" : ".json" )}" );
            var json = File.ReadAllText( path );
            return JsonConvert.DeserializeObject<T>( json );
        }
    }
}
