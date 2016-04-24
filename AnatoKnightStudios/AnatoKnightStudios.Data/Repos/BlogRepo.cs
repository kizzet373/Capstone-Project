using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoKnightStudios.UI.Models;
using Dapper;

namespace AnatoKnightStudios.Data.Repos
{
    public class BlogRepo
    {
        private string conn;

        public BlogRepo()
        {
            conn = ConfigurationManager.ConnectionStrings["AnatoKnightStudios"].ConnectionString;
        }

        public List<Post> GetAllPosts()
        {
            using (var _cn = new SqlConnection(conn))
            {
                List<Post> posts = new List<Post>();

                posts = _cn.Query<Post>("SELECT * FROM Post ").ToList();
                return posts;
            }
        }

        public Post GetPostById(int id)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                var post = _cn.Query<Post>("SELECT * " +
                                           "FROM Post " +
                                           "WHERE PostId = @ID ", parameters).FirstOrDefault();
                return post;
            }
        }

        public Post GetPostByCategory(int id)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                
                // Need to check SQL Database: table relationship for query below.
                var post = _cn.Query<Post>("SELECT * " +
                                           "FROM Post " +
                                           "WHERE CategoryId = @ID ", parameters).FirstOrDefault();
                return post;
            }
        }

        public Post GetPostByTag(int id)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);

                // Need to check SQL Database: table relationship for query below.
                var post = _cn.Query<Post>("SELECT * " +
                                           "FROM Post " +
                                           "WHERE TagId = @ID ", parameters).FirstOrDefault();
                return post;
            }
        }

        public void Add(Post post)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();

                // add more parameters here
                parameters.Add("BlogId", post.BlogId);
                parameters.Add("PostContent", post.PostContent);

                string query = "INSERT INTO Post (BlogId, PostContent) " +
                               "VALUES (@BlogId, @PostContent) ";

                _cn.Execute(query, parameters);
            }
        }

        public void Delete(int postId)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var param = new DynamicParameters();
                param.Add("PostId", postId);

                // Need to write a Stored Procedure
                _cn.Execute("DeletePost", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void Edit(int postId, Post post)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();


                // add more parameters here
                parameters.Add("ID", postId);
                parameters.Add("PostTitle", post.PostTitle);
                parameters.Add("PostDate", DateTime.Today);

                string query = "UPDATE Post SET PostTitle=@PostTitle, PostDate=@PostDate" +
                               "WHERE RequestFormId = @ID";
                _cn.Execute(query, parameters);
            }
        }
    }
}
