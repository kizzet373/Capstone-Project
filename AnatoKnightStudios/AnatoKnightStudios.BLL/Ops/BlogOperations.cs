using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Models;
using AnatoknightStudios.Data.Repos;

namespace AnatoknightStudios.BLL.Ops
{
    public class BlogOperations
    {
        private BlogRepo _repo = new BlogRepo();

        public List<Post> GetAllPosts()
        {
            return _repo.GetAllPosts();
        }

        public Post GetPostById(int postId)
        {
            return _repo.GetPostById(postId);
        }

        public Post GetPostByCategory(int categoryId)
        {
            return _repo.GetPostByCategory(categoryId);
        }

        public Post GetPostByTag(int tagId)
        {
            return _repo.GetPostByTag(tagId);
        }
        
        public Post Add(Post post, string userId)
        {
            post.PostDate = DateTime.Now;
            _repo.Add(post, userId);
            return post;
        }

        public void Delete(int postId)
        {
            _repo.Delete(postId);
        }

        public void Edit(int postId, Post post)
        {
            _repo.Edit(postId, post);
        }
    }
}
