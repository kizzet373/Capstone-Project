using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AnatoknightStudios.BLL.Ops;
using AnatoknightStudios.Models;
using Microsoft.AspNet.Identity;

namespace AnatoknightStudios.UI.Controllers
{
    public class StaticPageController : Controller
    {
        public ActionResult ViewStaticPage(int pageId)
        {
            var pageOps = new StaticPageOperations();
            var page = new StaticPage();
            //pageId = 1;
            page = pageOps.GetPageById(pageId);

            return View(page);
        }

        public ActionResult CreateStaticPage()
        {
            return View(new StaticPage());
        }

        [HttpPost]
        public ActionResult CreateStaticPage(StaticPage page)
        {
            page.IsActive = true;
            //page.PageId = 1;

            var ops = new StaticPageOperations();
            ops.Add(page);
            return RedirectToAction("ViewStaticPage");
        }
    }
}
