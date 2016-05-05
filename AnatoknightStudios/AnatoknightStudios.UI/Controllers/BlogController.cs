using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using AnatoknightStudios.BLL.Ops;
using AnatoknightStudios.Models;
using AnatoknightStudios.UI.Models;
using Microsoft.AspNet.Identity;

namespace AnatoknightStudios.UI.Controllers
{
    public class BlogController : Controller
    {

        // GET: Admin Blog

        public ActionResult AdminBlog(int? categoryId)
        {

            var blogOps = new BlogOperations();
            var blogVm = new BlogVm() {Blog = new Blog() {BlogId = 1} };
            blogVm.Blog.Posts = blogOps.GetPostByBlogId(blogVm.Blog.BlogId);

            if (categoryId != null)
            {
                var posts = from post in blogVm.Blog.Posts
                    where post.CategoryId == categoryId
                    select post;

                blogVm.Blog.Posts = posts.ToList();
            }

            var catOps = new CategoryOperations();
            blogVm.Blog.Categories = catOps.GetAllActiveCategories();

            var tagOps = new TagOperations();
            blogVm.Blog.Tags = tagOps.GetAllTags();

            return View(blogVm);
        }

        // GET: Contributor Blog
        //[Authorize(Roles = "Contributor, Admin")]
        public ActionResult ContributorBlog(int? categoryId)
        {
            var blogOps = new BlogOperations();
            var blogVm = new BlogVm() { Blog = new Blog() { BlogId = 2 } };
            blogVm.Blog.Posts = blogOps.GetPostByBlogId(blogVm.Blog.BlogId);

            if (categoryId != null)
            {
                var posts = from post in blogVm.Blog.Posts
                            where post.CategoryId == categoryId
                            select post;

                blogVm.Blog.Posts = posts.ToList();
            }

            var catOps = new CategoryOperations();
            blogVm.Blog.Categories = catOps.GetAllActiveCategories();

            var tagOps = new TagOperations();
            blogVm.Blog.Tags = tagOps.GetAllTags();

            return View(blogVm);
        }

        // POST: Create a new post
        [HttpPost]
        [Authorize(Roles = "Admin, Contributor")]
        public ActionResult AddPost(Post post)
        {
            //hardcoding values
            post.IsActive = true;
            post.Votes = 0;
            post.PostStatus = "Open";
            
            var tagOps = new TagOperations();

            foreach (Tag tag in post.PostTags)
            {
                int tagId = tagOps.AddTag(tag);
                tag.TagId = tagId;
            }

            var ops = new BlogOperations();
            ops.Add(post, User.Identity.GetUserId());
            if (post.BlogId == 1)
            {
                return RedirectToAction("AdminBlog");
            }           
            return RedirectToAction("ContributorBlog");
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
        [Authorize(Roles = "Admin, Contributor")]
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


        public ActionResult EditPost(int id)
        {
            var ops = new BlogOperations();
            var post = ops.GetPostById(id);
            return View(post);
        }

        [HttpPost]
   
        // Add contributors or users in Roles
        [Authorize(Roles = "Admin")]
        public ActionResult EditPost(Post post)
        {
            var ops = new BlogOperations();
            ops.Edit(post.PostId, post);
            return RedirectToAction("AdminBlog");
        }

        public ActionResult AddCategory(Category category)
        {
            var catOps = new CategoryOperations();
            catOps.AddCategory(category);
            return RedirectToAction("AdminBlog");
        }

        //// POST: Create a new post
        //[HttpPost]
        //[Authorize(Roles = "Admin, Contributor")]
        //public ActionResult Add(Post post)
        //{
        //    // hardcoding values
        //    post.IsActive = true;
        //    post.CategoryId = 1;
        //    post.BlogId = 1;
        //    post.Votes = 40;

        //    var ops = new BlogOperations();
        //    ops.Add(post, User.Identity.GetUserId());
        //    //_repo.Add(post);
        //    return RedirectToAction("AdminBlog");
        //}
    }
}