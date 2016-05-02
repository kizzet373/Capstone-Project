using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AnatoknightStudios.BLL.Ops;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.UI.Controllers
{
    public class StaticPageController : Controller
    {
        public ActionResult StaticPage(int pageId)
        {
            var pageOps = new StaticPageOperations();
            var page = new StaticPage();
            page.Title = pageOps.GetPageById(pageId).ToString();
            page.Content = pageOps.GetPageById(pageId).ToString();
            //page.PageId = 

            return View();
        }
    }
}
