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
using Mono.App.SelfPublishConverter.Templates;

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
            var result = Convert(new MarkdownTemplate());
            File.WriteAllText("hoge.markdown", result);


            var pro = new Process();

            pro.StartInfo.FileName = "pandoc";            // コマンド名
            pro.StartInfo.Arguments = string.Format("{0} -s -o {1}", "hoge.markdown", "hoge.epub");              // 引数
            pro.StartInfo.CreateNoWindow = true;            // DOSプロンプトの黒い画面を非表示
            pro.StartInfo.UseShellExecute = false;          // プロセスを新しいウィンドウで起動するか否か
            pro.StartInfo.RedirectStandardOutput = true;    // 標準出力をリダイレクトして取得したい

            pro.Start();

            string output = pro.StandardOutput.ReadToEnd();
            output.Replace("\r\r\n", "\n"); // 改行コード変換

            //出力された結果を表示
            Debug.WriteLine(output);

            return result;
        }

        public string ConvertToHtml()
        {
            var result = Convert(new HtmlTemplate());

            File.WriteAllText("hoge.html", result);
            Process.Start("kindlegen", "hoge.html");

            return result;
        }

        private string Convert(ITemplate template)
        {
            var chapterStrings = this.Chapters.Select(chapter =>
            {
                var chapters = chapter.Sections.Select(section => string.Format(template.Section, section.Caption, section.Body));
                return string.Format(template.Chapter, chapter.Caption, chapter.Body, string.Join("\n", chapters));
            });

            var bookString = string.Format(template.Book, this.Title, string.Join("\n", chapterStrings));
            return bookString;
        }

        public string ConvertToMobi()
        {
            return null;
        }

    }

}
