using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AESharp.Core.Configuration
{
    public sealed class JsonConfigLoader : ConfigLoader
    {
        public override T Load<T>( string fileName, Encoding encoding = null )
        {
            var name = fileName.EndsWith( ".json", StringComparison.OrdinalIgnoreCase ) ? "" : $"{fileName}.json";
            var path = Path.Combine( this.RootDirectory, name );
            var json = File.ReadAllText( path, encoding ?? Encoding.UTF8 );

            return JsonConvert.DeserializeObject<T>( json );
        }
    }
}
