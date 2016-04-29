using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AnatoknightStudios.BLL.Ops;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.UI.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            var op = new CategoryOperations();
            var categories = op.GetAllActiveCategories();
            return View(categories);
        }


        public ActionResult GetCategorybyId(int id)
        {
            var op = new CategoryOperations();
            var category = op.GetCategoryById(id);
            return View(category);
        }

        public ActionResult AddCategory()
        {
            return View("AddCategory", new Category());
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            var op = new CategoryOperations();
            var cat = op.AddCategory(category);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var op = new CategoryOperations();
            var category = op.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult DeleteCategory(Category category)
        {
            var op = new CategoryOperations();
            op.Delete(category.CategoryId);

            return RedirectToAction("Index"); 
        }

    }
}