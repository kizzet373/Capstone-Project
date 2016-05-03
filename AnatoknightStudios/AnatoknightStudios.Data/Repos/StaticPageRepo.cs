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

        public StaticPage GetPageById(int pageId)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("PageId", pageId);
                var page = _cn.Query<StaticPage>(@"SELECT * From StaticPage Where PageId = @PageId", parameters).FirstOrDefault();
                return page;
            }
        }

        public void AddPage(StaticPage page)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                
                parameters.Add("Title", page.Title);
                parameters.Add("PageContent", page.PageContent);
                parameters.Add("IsActive", page.IsActive);

                string query = "INSERT INTO StaticPage (Title, PageContent, IsActive) " +
                               "VALUES (@Title, @PageContent, @IsActive) ";

                _cn.Execute(query, parameters);
            }
        }

        public void Delete(int pageId)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("PageId", pageId);

                _cn.Execute("DeletePage", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Edit(int pageId, StaticPage page)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("ID", pageId);
                parameters.Add("Title", page.Title);
                parameters.Add("PageContent", page.PageContent);
                parameters.Add("IsActive", page.IsActive);

                string query = "UPDATE StaticPage SET Title=@Title, PageContent=@PageContent, " +
                               "IsActive=@IsActive WHERE PageId = @ID";
                _cn.Execute(query, parameters);
            }
        }
    }
}
