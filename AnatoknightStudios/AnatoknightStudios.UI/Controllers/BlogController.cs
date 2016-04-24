using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnatoKnightStudios.BLL.Ops;
using AnatoKnightStudios.UI.Models;

namespace AnatoknightStudios.UI.Controllers
{
    public class BlogController : Controller
    {

        //private static List<Post> _repo = new List<Post>();

        // GET: Contributor
        public ActionResult Index()
        {
            var ops = new BlogOperations();
            var posts = ops.GetAllPosts();

            return View(posts);
            //return View(_repo);
        }

        // GET: Create a new post
        public ActionResult Add()
        {
            return View("Add", new Post());
        }

        // POST: Create a new post
        [HttpPost]
        public ActionResult Add(Post post)
        {
            var ops = new BlogOperations();
            ops.Add(post);
            //_repo.Add(post);
            return RedirectToAction("Index");
        }

        // GET: Details of post
        public ActionResult Details(int id)
        {
            var ops = new BlogOperations();
            Post post = new Post();
            post = ops.GetPostById(id);
            return View(post);
        }

        // GET: Delete a post
        public ActionResult Delete(int id)
        {
            var ops = new BlogOperations();
            var post = ops.GetPostById(id);

            return View(post);
        }

        // POST: Delete a post
        [HttpPost]

        // Add contributors or users in Roles
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(Post id)
        {
            var ops = new BlogOperations();
            ops.Delete(id.PostId);

            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var ops = new BlogOperations();
            var post = ops.GetPostById(id);
            return View(post);
        }

        [HttpPost]

        // Add contributors or users in Roles
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Post post)
        {
            var ops = new BlogOperations();
            ops.Edit(post.PostId, post);
            return RedirectToAction("Index");
        }
    }
}