using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnatoKnightStudios.UI.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public List<Post> AdminPosts { get; set; }
        public List<Tag> Tags { get; set; }
        public List<Category> Categories { get; set; }
    }
}