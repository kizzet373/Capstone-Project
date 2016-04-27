using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AnatoknightStudios.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool IsActive { get; set; }
    }
}