using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Templates
{
    class MarkdownTemplate : ITemplate
    {
        public string Book
        {
            get { return TemplateManager.Instance.getResource("MarkdownBook"); }
        }

        public string Chapter
        {
            get { return TemplateManager.Instance.getResource("MarkdownChapter"); }
        }

        public string Section
        {
            get { return TemplateManager.Instance.getResource("MarkdownSection"); }
        }
    }
}
