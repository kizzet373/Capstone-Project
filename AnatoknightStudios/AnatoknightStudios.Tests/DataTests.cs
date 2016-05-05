using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AnatoknightStudios.Data;
using AnatoknightStudios.Data.Repos;
using AnatoknightStudios.Models;
using NUnit.Framework;

namespace AnatoknightStudios.Tests
{
    [TestFixture]
    public class DataTests
    {
        // Mock Repo
        //private MockRepo _repo = new MockRepo();

        private readonly string _conn =
            ConfigurationManager.ConnectionStrings["AnatoknightStudiosTests"].ConnectionString;

        private string _script;
        private BlogRepo _repo = new BlogRepo();

        private string AssemblyLocation()
        {
            //var assembly = Assembly.GetExecutingAssembly();
            var assembly = typeof (DataTests).Assembly; //Gets assembly by class name
            var codebase = new Uri(assembly.CodeBase);
            var path = codebase.LocalPath.Substring(0,
                codebase.LocalPath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            return path;
        }

        [SetUp]
        public void setup()
        {
            using (SqlConnection sqlConn = new SqlConnection(_conn))
            {
                _script = File.ReadAllText(AssemblyLocation() + "\\SeedData.sql");

                SqlCommand cmd = new SqlCommand(_script, sqlConn);
                sqlConn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [TearDown]
        public void teardown()
        {
            using (SqlConnection sqlConn = new SqlConnection(_conn))
            {
                _script = File.ReadAllText(AssemblyLocation() + "\\teardown.sql");
                SqlCommand cmd = new SqlCommand(_script, sqlConn);

                sqlConn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void GetAllPosts()
        {
            var target = _repo;
            var expected = 18;
            var actual = target.GetAllPosts().Count;
            Assert.AreEqual(actual, expected);
        }

        [TestCase(2, 2)]
        public void GetPostById(int postId, int expectedPost)
        {
            Post post = new Post();
            post = _repo.GetPostById(postId);
            Assert.AreEqual(expectedPost, post.PostId);
        }

        [TestCase(3, 1)]
        public void GetPostByCategory(int categoryId, int expectedId)
        {
            List<Post> post = new List<Post>();
            post = _repo.GetPostsByCategory(categoryId);
            Assert.AreEqual(expectedId, post.Count);
        }

        [TestCase(2, "An awful Idea")]
        public void GetPostByPostTitle(int postId, string expectedResult)
        {
            var result = _repo.GetPostById(postId).PostTitle;
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(1, 17)]
        public void GetPostCountsByCategory(int categoryId, int expectedResult)
        {
            var result = _repo.GetPostsByCategory(categoryId).Count;
            Assert.AreEqual(expectedResult, result);
        }

        [TestCase(2, 6)]
        public void GetPostCountsByBlogId(int blogId, int expectedResult)
        {
            var result = _repo.GetPostsByBlogId(blogId).Count;
            Assert.AreEqual(expectedResult, result);
        }
    }
}
