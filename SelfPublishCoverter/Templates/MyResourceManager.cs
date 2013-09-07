using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Templates
{
    class MyResourceManager
    {
        public string BinDirectory { get; set; }

        private static MyResourceManager _templateManager = new MyResourceManager();
        private ResourceManager _resourceManager;

        private MyResourceManager()
        {
            _resourceManager = new ResourceManager("Mono.App.SelfPublishConverter", Assembly.GetExecutingAssembly());
            BinDirectory = "C:/amazon/bin";
        }
        
        public static MyResourceManager Instance  {get  { return _templateManager; }}

        public void ExractResources()
        {
            var assName = "Mono.App.SelfPublishConverter";
            var filenames = new[] {"kindlegen.exe", "pandoc.exe" };

            foreach (var f in filenames)
            {
                ExtractResourceIfNoTExist(string.Format("{0}.{1}", assName, f), Path.Combine(BinDirectory, f));
            }
        }

        private void ExtractResourceIfNoTExist(string name, string path)
        {
            if (File.Exists(path))
            {
                return;
            }
            //var stream = _resourceManager.GetStream(name);
            var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(name);
            var bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            File.WriteAllBytes(path, bytes);
        }
    }
}
