using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.UI.Models
{
    public class BlogVm
    {
        public Blog Blog { get; set; }
        public Category CurrentCategory { get; set; }
        public List<Tag> CurrentTags { get; set; }

        public BlogVm()
        {
            Blog = new Blog();
            CurrentCategory = new Category();
            CurrentTags = new List<Tag>();
        }
    }
}