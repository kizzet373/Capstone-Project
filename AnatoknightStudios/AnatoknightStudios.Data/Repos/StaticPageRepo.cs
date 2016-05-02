using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Models;
using Dapper;

namespace AnatoknightStudios.Data.Repos
{
    public class StaticPageRepo
    {
        private string conn;

        public StaticPageRepo()
        {
            conn = ConfigurationManager.ConnectionStrings["AnatoknightStudios"].ConnectionString;
        }


        public List<StaticPage> GetAllPages()
        {
            using (var _cn = new SqlConnection(conn))
            {
                var pages = _cn.Query<StaticPage>("SELECT * FROM StaticPage ").ToList();
                return pages;
            }
        }

        public StaticPage GetPageById(int id)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                var page = _cn.Query<StaticPage>(@"SELECT * From StaticPage Where PostId = @ID", parameters).FirstOrDefault();
                return page;
            }
        }

        public void AddPage(StaticPage page, int pageId)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("Title", page.Title);
                parameters.Add("PageContent", page.Content);
                parameters.Add("IsActive", page.IsActive);

                string query = "INSERT INTO StaticPage (Title, PageContent, IsActive) " +
                               "VALUES (@Title, @PageContent, @IsActive) ";

                _cn.Execute(query, parameters);
            }
        }
    }
}
