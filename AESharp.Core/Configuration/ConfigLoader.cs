using System.IO;
using System.Text;

namespace AESharp.Core.Configuration
{
    public abstract class ConfigLoader
    {
        public string RootDirectory { get; }

        protected ConfigLoader(string rootDirectory = "configs")
        {
            var current = Directory.GetCurrentDirectory();
            RootDirectory = Path.Combine(current, rootDirectory);
        }

        public abstract T Load<T>(string fileName, Encoding encoding = null);
        public abstract void CreateDefault<T>(string fileName, T defaultValue, Encoding encoding = null);
    }
}