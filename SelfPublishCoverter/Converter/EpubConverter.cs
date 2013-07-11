using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.App.SelfPublishConverter.Templates;

namespace Mono.App.SelfPublishConverter.Converter
{
    class EpubConverter : ConverterBase
    {
        public EpubConverter(MarkdownTemplate template) : base(template)
        {
        }

        protected override void Convert(string formattedString)
        {
            const string markdownPath = "temp.markdown";
            File.WriteAllText(markdownPath, formattedString);
            ExecuteCommand("pandoc", markdownPath, "-s", "-o", "temp.epub");
        }
    }
}
