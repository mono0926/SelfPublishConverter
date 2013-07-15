using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Templates
{
    class HtmlTemplate : ITemplate
    {
        public string Book { get { return Properties.Resources.HtmlBook; } }
        public string Chapter { get { return Properties.Resources.HtmlChapter; } }
        public string Section { get { return Properties.Resources.HtmlSection; } }
    }
}
