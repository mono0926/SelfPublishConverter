using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mono.App.SelfPublishConverter.Templates
{
    interface ITemplate
    {
        string Book { get; }
        string Chapter { get; }
        string Section { get; }
    }
}
