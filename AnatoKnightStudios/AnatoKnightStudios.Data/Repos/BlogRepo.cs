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
    public class BlogRepo
    {
        private string conn;

        public BlogRepo()
        {
            conn = ConfigurationManager.ConnectionStrings["AnatoknightStudios"].ConnectionString;
        }

        public List<Post> GetAllPosts()
        {
            using (var _cn = new SqlConnection(conn))
            {
                List<Post> posts = new List<Post>();

                //posts = _cn.Query<Post>("SELECT * FROM Post ").ToList();
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
                
                parameters.Add("CategoryId", post.CategoryId);
                parameters.Add("BlogId", post.BlogId);
                parameters.Add("FirstName", post.FirstName);
                parameters.Add("LastName", post.LastName);
                parameters.Add("PostDate", post.PostDate);
                parameters.Add("PostTitle", post.PostTitle);
                parameters.Add("PostContent", post.PostContent);
                parameters.Add("Votes", post.Votes);

                string query = "INSERT INTO Post (CategoryId, BlogId, FirstName, LastName, PostDate, " +
                               "PostTitle, PostContent, Votes) VALUES (@CategoryId, @BlogId, @FirstName, @LastName, " +
                               "@PostDate, @PostTitle, @PostContent, @Votes) ";

                _cn.Execute(query, parameters);
            }
        }

        public void Delete(int postId)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("PostId", postId);

                _cn.Execute("DeletePost", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void Edit(int postId, Post post)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("ID", postId);
                parameters.Add("CategoryId", post.CategoryId);
                parameters.Add("BlogId", post.BlogId);
                parameters.Add("FirstName", post.FirstName);
                parameters.Add("LastName", post.LastName);
                parameters.Add("PostDate", post.PostDate);
                parameters.Add("PostTitle", post.PostTitle);
                parameters.Add("PostContent", post.PostContent);
                parameters.Add("Votes", post.Votes);

                string query = "UPDATE Post SET CategoryId=@CategoryId, BlogId=@BlogId, FirstName=@FirstName, " +
                               "LastName=@LastName, PostDate=@PostDate, PostTitle=@PostTitle, PostContent=@PostContent, " +
                               "Votes=@Votes WHERE PostId = @ID";
                _cn.Execute(query, parameters);
            }

        }
    }
}
