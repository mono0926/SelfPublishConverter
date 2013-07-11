using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishCoverter.Templates
{
    class TemplateManager
    {
        private static TemplateManager _templateManager = new TemplateManager();
        private ResourceManager _resourceManager;

        private TemplateManager()
        {
            _resourceManager = new ResourceManager("Mono.App.SelfPublishConverter.Properties.Resources", Assembly.GetExecutingAssembly());
        }

        public static TemplateManager Instance  {get  { return _templateManager; }}

        public string HtmlBook { get { return _resourceManager.GetString("HtmlBook"); } }
        public string HtmlChapter { get { return _resourceManager.GetString("HtmlChapter"); } }
        public string HtmlSection { get { return _resourceManager.GetString("HtmlSection"); } }
    }
}
