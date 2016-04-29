using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AnatoknightStudios.Models
{
    public class StaticPage
    {
        public int PageId { get; set; }
        public string Title { get; set; }
        [AllowHtml]
        public string PageContent { get; set; }
        public bool IsActive { get; set; }
    }
}
