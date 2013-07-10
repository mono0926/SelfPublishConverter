using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Model
{
    [DataContract]
    public class Chapter
    {
        [DataMember(Name = "caption")]
        public string Caption { get; set; }
        [DataMember(Name = "body")]
        public string Body { get; set; }
        [DataMember(Name = "sections")]
        public IEnumerable<Section> Sections { get; set; }
    }
}
