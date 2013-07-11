using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.App.SelfPublishConverter.Model;
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

        protected abstract void Convert(string formattedString);

        public string Convert(Book book)
        {
            var formattedString = ConvertToFormattedString(book);
            Convert(formattedString);
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
            var pro = new Process
            {
                StartInfo =
                {
                    FileName = filename,
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
