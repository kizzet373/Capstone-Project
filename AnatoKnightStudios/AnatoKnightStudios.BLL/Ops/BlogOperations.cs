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
            var posts = _repo.GetAllPosts();
            var tagRepo = new TagRepo();
            foreach (Post post in posts)
            {
                post.PostTags = _repo.GetPostTagsByPostId(post.PostId);
                foreach (Tag tag in post.PostTags)
                {
                    var currentTag = tagRepo.GetTagById(tag.TagId);
                    tag.TagName = currentTag.TagName;
                    tag.TagPopularity = currentTag.TagPopularity;
                }
            }
            return posts;
        }

        public Post GetPostById(int postId)
        {
            var post = _repo.GetPostById(postId);
            var tagRepo = new TagRepo();
            post.PostTags = _repo.GetPostTagsByPostId(post.PostId);
            foreach (Tag tag in post.PostTags)
            {
                var currentTag = tagRepo.GetTagById(tag.TagId);
                tag.TagName = currentTag.TagName;
                tag.TagPopularity = currentTag.TagPopularity;
            }
            return post;
        }

        public List<Post> GetPostsByBlogId(int blogId)
        {
            var posts = _repo.GetPostsByBlogId(blogId);
            var tagRepo = new TagRepo();
            foreach (Post post in posts)
            {
                post.PostTags = _repo.GetPostTagsByPostId(post.PostId);
                foreach (Tag tag in post.PostTags)
                {
                    var currentTag = tagRepo.GetTagById(tag.TagId);
                    tag.TagName = currentTag.TagName;
                    tag.TagPopularity = currentTag.TagPopularity;
                }
            }
            return posts;
        } 

        public List<Post> GetPostByCategory(int categoryId)
        {
            return _repo.GetPostsByCategory(categoryId);
        }

        public List<Post> GetPostByTag(int tagId)
        {
            return _repo.GetPostsByTag(tagId);
        }
        
        public Post Add(Post post, string userId)
        {
            post.PostDate = DateTime.Now;
            post.PostId = _repo.Add(post, userId);
            AddPostTags(post);
            return post;
        }

        public void AddPostTags(Post post)
        {
            foreach (Tag tag in post.PostTags)
            {
                _repo.AddPostTag(post.PostId, tag);
            }            
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
