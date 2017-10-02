using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AESharp.Core.Configuration
{
    public sealed class JsonConfigLoader : ConfigLoader
    {
        public override T Load<T>(string fileName, Encoding encoding = null)
        {
            string path = GetFilePath(fileName);
            string json = File.ReadAllText(path, encoding ?? Encoding.UTF8);

            return JsonConvert.DeserializeObject<T>(json);
        }

        public override void CreateDefault<T>(string fileName, T defaultValue, Encoding encoding = null)
        {
            string path = GetFilePath(fileName);
            string json = JsonConvert.SerializeObject(defaultValue, Formatting.Indented);
            File.WriteAllText(path, json, encoding ?? Encoding.UTF8);
        }

        private string GetFilePath(string fileName)
        {
            string name = fileName.EndsWith(".json", StringComparison.OrdinalIgnoreCase) ? "" : $"{fileName}.json";
            return Path.Combine(RootDirectory, name);
        }
    }
}