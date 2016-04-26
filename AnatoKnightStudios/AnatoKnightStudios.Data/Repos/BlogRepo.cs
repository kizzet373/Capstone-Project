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
                var post = _cn.Query<Post>(@"Select Post.*,AspNetUsers.FirstName,AspNetUsers.LastName From Post
inner join AspNetUsers on AspNetUsers.Id = Post.AspNetUserId Where Post.PostId = @ID", parameters).FirstOrDefault();
                return post;
            }
        }

        public Post GetPostByCategory(int id)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);
                
                var post = _cn.Query<Post>(@"Select Post.*,AspNetUsers.FirstName,AspNetUsers.LastName From Post
inner join AspNetUsers on AspNetUsers.Id = Post.AspNetUserId Where CategoryId = @ID ", parameters).FirstOrDefault();
                return post;
            }
        }

        public Post GetPostByTag(int id)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("ID", id);

                var post = _cn.Query<Post>(@"Select Post.*,AspNetUsers.FirstName,AspNetUsers.LastName From Post
inner join AspNetUsers on AspNetUsers.Id = Post.AspNetUserId Where TagId = @ID ", parameters).FirstOrDefault();
                return post;
            }
        }

        public void Add(Post post, string userId)
        {
            using (var _cn = new SqlConnection(conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("ID", userId);
               


                parameters.Add("CategoryId", post.CategoryId);
                parameters.Add("BlogId", post.BlogId);
                
                parameters.Add("PostDate", post.PostDate);
                parameters.Add("PostTitle", post.PostTitle);
                parameters.Add("PostContent", post.PostContent);
                parameters.Add("IsActive", post.IsActive);
                parameters.Add("Votes", post.Votes);
                parameters.Add("AspNetUserId", userId);

                string query = "INSERT INTO Post (CategoryId,  BlogId, PostDate, PostTitle, " +
                               "PostContent, IsActive, Votes, AspNetUserId) " +
                               "VALUES (@CategoryId, @BlogId, @PostDate, @PostTitle, @PostContent, " +
                               "@IsActive, @Votes, @AspNetUserId) ";

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
                parameters.Add("PostDate", post.PostDate);
                parameters.Add("PostTitle", post.PostTitle);
                parameters.Add("PostContent", post.PostContent);
                parameters.Add("Votes", post.Votes);

                string query = "UPDATE Post SET CategoryId=@CategoryId, BlogId=@BlogId, " +
                               "PostDate=@PostDate, PostTitle=@PostTitle, PostContent=@PostContent, " +
                               "Votes=@Votes WHERE PostId = @ID";
                _cn.Execute(query, parameters);
            }
        }
    }
}