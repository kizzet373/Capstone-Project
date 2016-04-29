using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Models;
using Dapper;

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
            using (var _cn = new SqlConnection(conn))
            {
                //var categoryList = new List<Category>();
                //return categoryList;

                var categoryList = _cn.Query<Category>("SELECT * FROM Category ").ToList();
                return categoryList;
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                var category = _cn.Query<Category>("Select * From Category " +
                                                   "Where Category.CategoryId = @ID", parameters)
                                                   .FirstOrDefault();
                return category;
            }
        }

        public void AddCategory(Category category)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("CategoryId", category.CategoryId);
                parameters.Add("CategoryName", category.CategoryName);
                parameters.Add("IsActive", category.IsActive);

                string query = "INSERT INTO Category (CategoryId, CategoryName, IsActive " +
                               "VALUES (@CategoryId, @CategoryName, @IsActive) ";

                _cn.Execute(query, parameters);
            }
        }

        public void DeleteCategoryById(int categoryId)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("CategoryId", categoryId);

                _cn.Execute("DeleteCategory", parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
