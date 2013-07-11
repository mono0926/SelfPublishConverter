using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Templates
{
    class TemplateManager
    {
        private static TemplateManager _templateManager = new TemplateManager();
        private ResourceManager _resourceManager;

        private TemplateManager()
        {
            _resourceManager = new ResourceManager("Mono.App.SelfPublishConverter.Properties.Resources", Assembly.GetExecutingAssembly());
        }

        public string getResource(string name)
        {
            return _resourceManager.GetString(name);
        }

        public static TemplateManager Instance  {get  { return _templateManager; }}

    }
}
