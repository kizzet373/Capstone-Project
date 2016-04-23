using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TinyMCE.Models;

namespace TinyMCE.Controllers
{
    public class TinyMCEController : Controller
    {

        private static List<ExampleClass> _repo = new List<ExampleClass>();

        public ActionResult Index()
        {
            return View(_repo);
        }

        // An action to display your TinyMCE editor
        public ActionResult Add()
        {
            return View("Add", new ExampleClass());
        }

        // An action that will accept your Html Content
        [HttpPost]
        public ActionResult Add(ExampleClass model)
        {
            _repo.Add(model);
            return RedirectToAction("Index");
        }
    }
}