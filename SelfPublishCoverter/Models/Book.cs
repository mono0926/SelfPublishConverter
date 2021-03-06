﻿using System;
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
using Mono.App.SelfPublishConverter.Converter;

namespace Mono.App.SelfPublishConverter.Models
{
    [DataContract]
    public class Book
    {
        [DataMember(Name = "format")]
        public string Format { get; set; }
        [DataMember(Name = "title")]
        public string Title { get; set; }
        [DataMember(Name = "coverImageBase64")]
        public string CoverImageBase64 { get; set; }
        [DataMember(Name = "author")]
        public Author Author { get; set; }
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

        public void Convert(FormatType type, string outputPath)
        {
            switch (type)
            {
                case FormatType.Kindle:
                    ConvertToKindle(outputPath);
                    break;
                    case FormatType.Epub:
                    ConvertToEpub(outputPath);
                    break;
                default:
                    break;
            }
        }

        private void ConvertToEpub(string outputPath)
        {
            var converter = ConverterFactory.MarkdownConverter;
            converter.Convert(this, outputPath);
        }
        private void ConvertToKindle(string outputPath)
        {
            var converter = ConverterFactory.KindleConverter;
            converter.Convert(this, outputPath);
        }

    }

}
