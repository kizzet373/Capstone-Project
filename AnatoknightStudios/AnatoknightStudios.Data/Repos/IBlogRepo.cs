using System.Collections.Generic;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.Data.Repos
{
    public interface IBlogRepo
    {
        void Add(Post post, string userId);
        void Delete(int postId);
        void Edit(int postId, Post post);
        List<Post> GetAllPosts();
        Post GetPostById(int id);
        List<Post> GetPostsByBlogId(int id);
        List<Post> GetPostsByCategory(int id);
        List<Post> GetPostsByTag(int id);
    }
}