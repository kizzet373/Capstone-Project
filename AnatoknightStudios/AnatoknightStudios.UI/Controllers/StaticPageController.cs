using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using AnatoknightStudios.BLL.Ops;
using AnatoknightStudios.Models;
using Microsoft.AspNet.Identity;
using System.Web.Security;

namespace AnatoknightStudios.UI.Controllers
{
    public class StaticPageController : Controller
    {
        public ActionResult ViewStaticPage(int pageId)
        {
            var pageOps = new StaticPageOperations();
            var page = new StaticPage();
            pageId = 1;
            page.Title = pageOps.GetPageById(pageId).ToString();
            page.Content = pageOps.GetPageById(pageId).ToString();
            page.PageId = pageOps.GetPageById(pageId).PageId;

            return View(page);
        }

        public ActionResult CreateStaticPage(int pageId)
        {
            return View();
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult CreateStaticPage(StaticPage page, int pageId)
        {
            var Page = new StaticPage();
            Page.IsActive = true;
            Page.PageId = 1;

            var ops = new StaticPageOperations();
            ops.Add(page, pageId);
            return RedirectToAction("ViewStaticPage");
        }
    }
}
