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
    class DataTests
    {
        private BlogRepo _repo = new BlogRepo();

        [TestCase(2, 2)]
        public void GetPostById(int postId, int expectedPost)
        {
            Post samplePost = new Post();
            samplePost = _repo.GetPostById(postId);

            Assert.AreEqual(expectedPost, samplePost.PostId);
        }
    }
}
