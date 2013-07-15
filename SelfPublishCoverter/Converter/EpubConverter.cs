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

        protected override void Convert(string formattedString, string outputPath)
        {
            var fileInfo = new FileInfo(outputPath);
            var dir = fileInfo.DirectoryName;
            var markdownPath = Path.Combine(dir, string.Format("{0}.markdown", Path.GetFileNameWithoutExtension(outputPath)));
            var epubPath = Path.Combine(dir, string.Format("{0}.epub", Path.GetFileNameWithoutExtension(outputPath)));
            File.WriteAllText(markdownPath, formattedString);
            ExecuteCommand("pandoc", markdownPath, "-s", "-o", epubPath);
        }
    }
}
