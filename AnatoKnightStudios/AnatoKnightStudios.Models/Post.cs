using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnatoknightStudios.Models
{
    public class Post
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }
        public int BlogId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime PostDate { get; set; }
        public string PostTitle { get; set; }

        [AllowHtml]
        public string PostContent { get; set; }
        public List<string> PostImageUrls { get; set; }
        public List<Tag> PostTags { get; set; }
        public int Votes { get; set; }
        public Enum PostStatus { get; set; }
        //public List<Comment> Comments { get; set; }
        public bool IsActive { get; set; }
    }
}