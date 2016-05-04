using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Data.Repos;
using AnatoknightStudios.Models;
using NUnit.Framework;

namespace AnatoknightStudios.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase(2, 2)]
        public void GetPostById(int postId, int expectedPost)
        {
            BlogRepo repo = new BlogRepo();
            Post samplePost = new Post();
            
            samplePost = repo.GetPostById(postId);
            Assert.AreEqual(expectedPost, samplePost.PostId);
        }

        [TestCase(1, 1)]
        public void GetPostByCategory(int categoryId, int expectedId)
        {
            CategoryRepo repo = new CategoryRepo();
            Category cat = new Category();

            cat = repo.GetCategoryById(categoryId);
            Assert.AreEqual(expectedId, cat.CategoryId);
        }
    }
}
