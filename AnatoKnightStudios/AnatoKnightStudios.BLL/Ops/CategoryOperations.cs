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
        public List<Category> GetAllActiveCategories()
        {
            var catRepo = new CategoryRepo();
            var categoryList = catRepo.GetAllActiveCategories();

            return categoryList;
        }
    }
}
