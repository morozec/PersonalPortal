using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortal.ViewModels
{
    public class AddPostRequest
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public IEnumerable<string> Tags { get; set; }
    }
}
