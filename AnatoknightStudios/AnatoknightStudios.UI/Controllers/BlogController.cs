using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using AnatoknightStudios.BLL.Ops;
using AnatoknightStudios.Models;
using Microsoft.AspNet.Identity;

namespace AnatoknightStudios.UI.Controllers
{
    public class BlogController : Controller
    {

        // GET: Admin Blog
        //[Authorize(Roles = "Admin")]
        public ActionResult AdminBlog()
        {
            var blogOps = new BlogOperations();
            var blog = new Blog();
            blog.Posts = blogOps.GetPostByBlogId(1);
            //var catOps = new CategoryOperations();
            //blog.Categories = catOps.GetAllActiveCategories();

            //var tagOps = new TagOperations();
            //blog.Tags = tagOps.GetAllTags();

            return View(blog);
        }

        // GET: Contributor Blog
        //[Authorize(Roles = "Contributor" || "Admin")]
        public ActionResult ContributorBlog()
        {
            var blogOps = new BlogOperations();
            var blog = new Blog();
            blog.Posts = blogOps.GetPostByBlogId(2);

            //var catOps = new CategoryOperations();
            //blog.Categories = catOps.GetAllActiveCategories();

            //var tagOps = new TagOperations();
            //blog.Tags = tagOps.GetAllTags();

            return View(blog);
        }

        // GET: Create a new post
        [Authorize(Roles = "Admin, Contributor")]
        public ActionResult AddPost()
        {
            return View("AddPost", new Post());
        }

        // POST: Create a new post
        [HttpPost]
        [Authorize(Roles = "Admin, Contributor")]
        public ActionResult AddPost(Post post)
        {
            //hardcoding values
            post.IsActive = true;
            post.CategoryId = 1;
            post.BlogId = 1;
            post.Votes = 40;

            var ops = new BlogOperations();
            ops.Add(post, User.Identity.GetUserId());
            //_repo.Add(post);
            return RedirectToAction("AdminBlog");
        }

        // GET: Details of post
        public ActionResult PostDetails(int id)
        {
            var ops = new BlogOperations();
            Post post = new Post();
            post = ops.GetPostById(id);
            return View(post);
        }

        // GET: Delete a post
        public ActionResult _DeletePostModal(int id)
        {
            var ops = new BlogOperations();
            var post = ops.GetPostById(id);

            return View(post);
        }

        // POST: Delete a post
        [HttpPost]

        // Add contributors or users in Roles
        [Authorize(Roles = "Admin, Contributor")]
        public ActionResult DeletePost(int Id)
        {
            var ops = new BlogOperations();
            ops.Delete(Id);

            return RedirectToAction("AdminBlog");
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
            return RedirectToAction("AdminBlog");
        }
    }
}