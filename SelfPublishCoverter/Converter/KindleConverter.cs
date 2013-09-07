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
    class KindleConverter : EpubConverter
    {
        public KindleConverter(MarkdownTemplate template)
            : base(template)
        {
        }

        protected override void ConvertImpl(Book book, string outputPath)
        {
            base.ConvertImpl(book, outputPath);
            var epubPath = Path.Combine(Path.GetDirectoryName(outputPath), string.Format("{0}.epub", Path.GetFileNameWithoutExtension(outputPath)));
            ExecuteCommand("kindlegen", epubPath);
        }
    }
}
