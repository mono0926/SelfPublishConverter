using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.App.SelfPublishConverter.Models;


namespace UnitTestProject1
{
    [TestClass]
    public class BookTest
    {
        [TestMethod]
        public void CreateFromJsonTest()
        {
            var json = File.ReadAllText("../../data/sample.json");
            var book = Book.CreateFromJson(json);
            Debug.WriteLine(book);
        }
        [TestMethod]
        public void ConvertToKindleTest()
        {
            var json = File.ReadAllText("../../data/sample.json");
            var book = Book.CreateFromJson(json);
            book.Convert(FormatType.Kindle, @"C:/amazon/temp/hoge.mobi");
            Debug.WriteLine(book);
        }
        [TestMethod]
        public void ConvertToEpubTest()
        {
            var json = File.ReadAllText("../../data/sample.json");
            var book = Book.CreateFromJson(json);
            book.Convert(FormatType.Epub, @"C:/amazon/temp/hoge.epub");
            Debug.WriteLine(book);
        }
    }
}
