using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Models
{
    [DataContract]
    public class Author
    {
        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "accessToken")]
        public string AccessToken { get; set; }
    }
}
