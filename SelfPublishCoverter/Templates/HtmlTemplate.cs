using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Templates
{
    class HtmlTemplate : ITemplate
    {
        public string Book { get { return TemplateManager.Instance.getResource("HtmlBook"); } }
        public string Chapter { get { return TemplateManager.Instance.getResource("HtmlChapter"); } }
        public string Section { get { return TemplateManager.Instance.getResource("HtmlSection"); } }
    }
}
