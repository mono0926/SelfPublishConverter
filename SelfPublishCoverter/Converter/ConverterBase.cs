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
    abstract class ConverterBase : IConverter
    {
        private readonly ITemplate _template;

        protected ConverterBase(ITemplate template)
        {
            _template = template;
        }

        protected abstract void Convert(string formattedString, string outputPath);

        public string Convert(Book book, string outputPath)
        {
            var formattedString = ConvertToFormattedString(book);
            Convert(formattedString, outputPath);
            return formattedString;
        }

        private string ConvertToFormattedString(Book book)
        {
            var chapterStrings = book.Chapters.Select(chapter =>
            {
                var chapters = chapter.Sections.Select(section => string.Format(_template.Section, section.Caption, section.Body));
                return string.Format(_template.Chapter, chapter.Caption, chapter.Body, string.Join("\n", chapters));
            });

            var bookString = string.Format(_template.Book, book.Title, string.Join("\n", chapterStrings));
            return bookString;
        }

        protected void ExecuteCommand(string filename, params string[] arguments)
        {
            var resourcManager = MyResourceManager.Instance;
            resourcManager.ExractResources();

            var pro = new Process
            {
                StartInfo =
                {
                    FileName = Path.Combine(resourcManager.BinDirectory, filename),
                    Arguments = string.Join(" ", arguments),
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            pro.Start();
            var output = pro.StandardOutput.ReadToEnd();
            Debug.WriteLine(output);
        }
    }
}
