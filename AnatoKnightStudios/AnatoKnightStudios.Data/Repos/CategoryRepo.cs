using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.Data.Repos
{
    public class CategoryRepo
    {
        private string conn;

        public CategoryRepo()
        {
            conn = ConfigurationManager.ConnectionStrings["AnatoknightStudios"].ConnectionString;
        }

        public List<Category> GetAllActiveCategories()
        {
            var categoryList = new List<Category>();

            return categoryList;
        }
    }
}
