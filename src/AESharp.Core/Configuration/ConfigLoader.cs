using System.IO;
using System.Text;

namespace AESharp.Core.Configuration
{
    public abstract class ConfigLoader
    {
        public string RootDirectory { get; }

        protected ConfigLoader( string rootDirectory = "configs" )
        {
            string current = Directory.GetCurrentDirectory();
            this.RootDirectory = Path.Combine( current, rootDirectory );
        }

        public abstract T Load<T>( string fileName, Encoding encoding = null );
    }
}