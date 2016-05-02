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

        public ActionResult DeleteStaticPage(int pageId)
        {
            var ops = new StaticPageOperations();
            var page = ops.GetPageById(pageId);

            return View(page);
        }

        [HttpPost]

        // Add contributors or users in Roles
        //[Authorize(Roles = "Admin, Contributor")]
        public ActionResult Delete(int pageId)
        {
            var ops = new StaticPageOperations();
            ops.DeleteStaticPage(pageId);

            return RedirectToAction("AdminBlog", "Blog");
        }

        public ActionResult EditStaticPage(int pageId)
        {
            var ops = new StaticPageOperations();
            var page = ops.GetPageById(pageId);
            return View(page);
        }

        [HttpPost]

        // Add contributors or users in Roles
        [Authorize(Roles = "Admin")]
        public ActionResult EditStaticPage(StaticPage page)
        {
            var ops = new StaticPageOperations();
            ops.Edit(page.PageId, page);
            return RedirectToAction("AdminBlog", "Blog");
        }
    }
}
