using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalPortal.ViewModels
{
    public class AddCommentRequest
    {
        public string Author { get; set; }
        public string Comment { get; set; }
        public int PostId { get; set; }
    }
}
