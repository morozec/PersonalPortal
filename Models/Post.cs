using System;
using System.Collections;
using System.Collections.Generic;

namespace Models
{
    public class Post
    {
        public string Body { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Header { get; set; }
        public int PostId { get; set; }
        public ICollection<Tag> Tags { get; set; } 
    }
}