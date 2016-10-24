using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AESharp.Core.Configuration
{
    public sealed class JsonConfigLoader : ConfigLoader
    {
        public override T Load<T>( string fileName, Encoding encoding = null )
        {
            string name = fileName.EndsWith( ".json", StringComparison.OrdinalIgnoreCase ) ? "" : $"{fileName}.json";
            string path = Path.Combine( this.RootDirectory, name );
            string json = File.ReadAllText( path, encoding ?? Encoding.UTF8 );

            return JsonConvert.DeserializeObject<T>( json );
        }
    }
}