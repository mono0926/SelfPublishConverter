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
            get { return Properties.Resources.MarkdownBook; }
        }

        public string Chapter
        {
            get { return Properties.Resources.MarkdownChapter; }
        }

        public string Section
        {
            get { return Properties.Resources.MarkdownSection; }
        }
    }
}
