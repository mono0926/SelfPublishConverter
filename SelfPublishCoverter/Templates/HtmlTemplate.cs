using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Templates
{
    class HtmlTemplate : ITemplate
    {
        public string Book { get { return _resourceManager.GetString("HtmlBook"); } }
        public string Chapter { get { return _resourceManager.GetString("HtmlChapter"); } }
        public string Section { get { return _resourceManager.GetString("HtmlSection"); } }
    }
}
