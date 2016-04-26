using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JQueryTextComplete.UI.Models;

namespace JQueryTextComplete.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Hashtags()
        {
            return View(new Hashtags());
        }
    }
}
