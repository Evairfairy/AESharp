using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Newtonsoft.Json;

namespace AESharp.Core.Configuration
{
    public abstract class ConfigLoader
    {
        public string RootDirectory { get; }

        protected ConfigLoader( string rootDirectory = "configs" )
        {
            var current = Directory.GetCurrentDirectory();
            this.RootDirectory = Path.Combine( current, rootDirectory );
        }

        public abstract T Load<T>( string fileName, Encoding encoding = null );
    }
}
