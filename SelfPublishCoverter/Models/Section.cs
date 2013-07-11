using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Models
{
    [DataContract]
    public class Section
    {
        [DataMember(Name = "caption")]
        public string Caption { get; set; }
        [DataMember(Name = "body")]
        public string Body { get; set; }
    }
}
