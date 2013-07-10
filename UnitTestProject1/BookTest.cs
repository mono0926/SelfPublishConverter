﻿using System;
using System.Diagnostics;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mono.App.SelfPublishConverter.Model;


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
    }
}