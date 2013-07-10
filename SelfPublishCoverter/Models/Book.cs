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
            var resourceManager = new ResourceManager("Mono.App.SelfPublishConverter.Properties.Resources", Assembly.GetExecutingAssembly());
            var bookTemplate = resourceManager.GetString("HtmlBook");
            var chapterTemplate = resourceManager.GetString("HtmlChapter");
            var sectionTemplate = resourceManager.GetString("HtmlSection");

            var chapterStrings = this.Chapters.Select(chapter =>
                {
                    return string.Format(chapterTemplate, chapter.Caption, chapter.Body,
                        string.Join("\n", chapter.Sections.Select(section => string.Format(sectionTemplate, section.Caption, section.Body))));
                });

            var bookString = string.Format(bookTemplate, this.Title, string.Join("\n", chapterStrings));
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
