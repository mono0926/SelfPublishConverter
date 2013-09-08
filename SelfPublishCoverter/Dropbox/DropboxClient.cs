using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DropNet;
using DropNet.Models;

namespace Mono.App.SelfPublishConverter.Dropbox
{
    class DropboxClient
    {
        const string APIKey = "j55215vf75hur2l";
        const string AppSecret = "ukzqht19mebjm8x";

        DropNetClient _client = new DropNetClient(APIKey, AppSecret);

        public DropboxClient(string userToken, string userSecret)
        {
            _client.UserLogin = new UserLogin { Token = userToken, Secret = userSecret };
            _client.UseSandbox = true;
        }

        public void SaveFile(string dropboxPath, string outputPath)
        {
            var bytes = _client.GetFile(dropboxPath);
            File.WriteAllBytes(outputPath, bytes);
        }
    }
}
