using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.App.SelfPublishConverter.Models;
using Mono.App.SelfPublishConverter.Templates;

namespace Mono.App.SelfPublishConverter.Converter
{
    class EpubConverter : ConverterBase
    {
        public EpubConverter(MarkdownTemplate template) : base(template)
        {
        }

        protected override void ConvertImpl(Book book, string outputPath)
        {
            var fileInfo = new FileInfo(outputPath);
            var dir = fileInfo.DirectoryName;
            var markdownPath = Path.Combine(dir, string.Format("{0}.markdown", Path.GetFileNameWithoutExtension(outputPath)));
            var epubPath = Path.Combine(dir, string.Format("{0}.epub", Path.GetFileNameWithoutExtension(outputPath)));
            File.WriteAllText(markdownPath, ConvertToFormattedString(book));
            string coverImageOption = null;
            if (book.CoverImageBase64 == null)
            {
                ExecuteCommand("pandoc", markdownPath, "-s", "-o", epubPath);
            }
            else
            {
                var directory = Path.GetDirectoryName(outputPath);
                var filename = Path.GetFileNameWithoutExtension(outputPath);
                string path = Path.Combine(directory, string.Format("{0}_cover.jpg", filename));
                SelfPublishUtil.save(book.CoverImageBase64, path);
                coverImageOption = string.Format("--epub-cover-image={0}", path);
                ExecuteCommand("pandoc", markdownPath, "-s", "-o", epubPath, coverImageOption);
            }
        }
    }
}
