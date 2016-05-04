using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
        private IBlogRepo _repo;

        private string AssemblyLocation()
        {
            //var assembly = Assembly.GetExecutingAssembly();
            var assembly = typeof (DataTests).Assembly; //Gets assembly by class name
            var codebase = new Uri(assembly.CodeBase);
            var path = codebase.LocalPath.Substring(0, codebase.LocalPath.LastIndexOf("\\", StringComparison.Ordinal) + 1);
            return path;
        }

        [OneTimeSetUp]
        public void setup()
        {
            _repo = new BlogRepo(ConfigurationManager.ConnectionStrings["AnatoknightStudiosTests"].ConnectionString);
            using (SqlConnection sqlConn = new SqlConnection())
            {
                string SeedData = File.ReadAllText("\\SeedData.sql");
                
                SqlCommand cmd = new SqlCommand(SeedData,sqlConn);
                cmd.ExecuteNonQuery();
            }
        }

        [OneTimeTearDown]
        public void teardown()
        {
            using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["AnatoknightStudiosTests"].ConnectionString))
            {
                var script = File.ReadAllText(_repo + "teardown.sql");
                SqlCommand cmd = new SqlCommand(script, cn);
                try
                {
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                }
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
    }
}
