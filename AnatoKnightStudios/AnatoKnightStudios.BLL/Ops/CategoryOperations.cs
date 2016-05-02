using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Data.Repos;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.BLL.Ops
{
    public class CategoryOperations
    {

        private CategoryRepo _repo = new CategoryRepo();

        public List<Category> GetAllActiveCategories()
        {
            var categoryList = _repo.GetAllActiveCategories();

            return categoryList;
        }

        public Category GetCategoryById(int id)
        {
            return _repo.GetCategoryById(id);
        }

        public Category AddCategory(Category category)
        {
            _repo.AddCategory(category);
            return category;
        }

        public void Delete(int categoryId)
        {
            _repo.DeleteCategoryById(categoryId);
        }
    }
}
