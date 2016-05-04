using System;
using System.Collections.Generic;
using System.Linq;
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
        private MockRepo _repo = new MockRepo();

        [TestCase(1, 1)]
        public void GetPostById(int postId, int expectedPost)
        {
            Post post = new Post();
            post = _repo.GetPostByIdPost(postId);
            Assert.AreEqual(expectedPost, post.PostId);

        }

        [TestCase(1, 1)]
        public void GetPostByCategory(int categoryId, int expectedId)
        {
            Post post = new Post();
            post = _repo.GetPostByCategoryId(categoryId);
            Assert.AreEqual(expectedId, post.CategoryId);

        }
    }
}
