using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.App.SelfPublishConverter.Templates;
using Mono.App.SelfPublishConverter.Models;

namespace Mono.App.SelfPublishConverter.Converter
{
    class KindleConverter : ConverterBase
    {
        public KindleConverter(HtmlTemplate template) : base(template)
        {
        }

        protected override void Convert(string formattedString, string outputPath)
        {
            var fileInfo = new FileInfo(outputPath);
            var dir = fileInfo.DirectoryName;
            var htmlPath = Path.Combine(dir, string.Format("{0}.html", Path.GetFileNameWithoutExtension(outputPath)));
            File.WriteAllText(htmlPath, formattedString);
            ExecuteCommand("kindlegen", htmlPath);
        }
    }
}
