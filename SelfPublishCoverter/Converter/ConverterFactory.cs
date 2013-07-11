using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mono.App.SelfPublishConverter.Templates;

namespace Mono.App.SelfPublishConverter.Converter
{
    static class ConverterFactory
    {
        private static IConverter _kindleConverter;
        private static IConverter _markdownConverter;

        public static IConverter KindleConverter
        {
            get
            {
                if (_kindleConverter == null)
                {
                    _kindleConverter = new KindleConverter(new HtmlTemplate());
                }
                return _kindleConverter;
            }
        }

        public static IConverter MarkdownConverter
        {
            get
            {
                if (_markdownConverter == null)
                {
                    _markdownConverter = new EpubConverter(new MarkdownTemplate());
                }
                return _markdownConverter;
            }
        }
    }
}
