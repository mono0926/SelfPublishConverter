using Mono.App.SelfPublishCoverter.Templates;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Model
{
    [DataContract]
    public class Book
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "author")]
        public string Author { get; set; }
        [DataMember(Name = "chapters")]
        public IEnumerable<Chapter> Chapters { get; set; }

        public static Book CreateFromJson(string jsonString)
        {
            var serializer = new DataContractJsonSerializer(typeof(Book));
            var jsonBytes = Encoding.Unicode.GetBytes(jsonString);
            var sr = new MemoryStream(jsonBytes);
            var book = (Book)serializer.ReadObject(sr);
            Debug.WriteLine(book);
            return book;
        }

        public string ConvertToEpub()
        {
            return null;
        }

        public string ConvertToHtml()
        {
            var chapterStrings = this.Chapters.Select(chapter =>
                {
                    var chapters = chapter.Sections.Select(section => string.Format(TemplateManager.Instance.HtmlSection, section.Caption, section.Body));
                    return string.Format(TemplateManager.Instance.HtmlChapter, chapter.Caption, chapter.Body, string.Join("\n", chapters));
                });

            var bookString = string.Format(TemplateManager.Instance.HtmlBook, this.Title, string.Join("\n", chapterStrings));
            File.WriteAllText("hoge.html", bookString);
            Process.Start("kindlegen", "hoge.html");
            return bookString;
        }

        public string ConvertToMobi()
        {
            return null;
        }

    }

}
