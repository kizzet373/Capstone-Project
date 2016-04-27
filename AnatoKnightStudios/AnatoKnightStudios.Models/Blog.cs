using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnatoknightStudios.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public List<Post> Posts { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
        public string BlogTitle { get; set; }
    }
}