using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnatoknightStudios.Models
{
    public class StaticPage
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public bool IsActive { get; set; }
    }
}
