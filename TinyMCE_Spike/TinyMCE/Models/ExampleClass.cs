using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TinyMCE.Models
{
    public class ExampleClass
    {
        // This attribute allows your HTML Content to be sent up
        [AllowHtml]
        public string HtmlContent { get; set; }
        

        public ExampleClass()
        {

        }
    }
}