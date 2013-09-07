using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Converter
{
    public static class SelfPublishUtil
    {
        public static string ConvertToBase64String(string filepath)
        {
            using (var fs = new FileStream(filepath,
                               FileMode.Open,
                               FileAccess.Read))
            {
                var filebytes = new byte[fs.Length];
                fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                return Convert.ToBase64String(filebytes);
            }
        }

        public static void save(string base64String, string outputPath)
        {
            var bs = Convert.FromBase64String(base64String);
            using (var outFile = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
            {
                outFile.Write(bs, 0, bs.Length);
            }
        }
    }
}
