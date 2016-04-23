using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnatoKnightStudios.BLL.Ops;
using AnatoKnightStudios.UI.Models;

namespace AnatoknightStudios.UI.Controllers
{
    public class ContributorController : Controller
    {

        private static List<Post> _repo = new List<Post>();

        // GET: Contributor
        public ActionResult Index()
        {
            return View(_repo);
        }
        
    
        public ActionResult Add()
        {
            return View("Add", new Post());
        }

        [HttpPost]
        public ActionResult Add(Post model)
        {
            _repo.Add(model);
            return RedirectToAction("Index");
        }
    }
}