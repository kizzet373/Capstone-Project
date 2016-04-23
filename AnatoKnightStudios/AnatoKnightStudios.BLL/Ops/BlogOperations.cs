using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoKnightStudios.UI.Models;
using AnatoKnightStudios.Data.Repos;

namespace AnatoKnightStudios.BLL.Ops
{
    public class BlogOperations
    {
        private BlogRepo _repo = new BlogRepo();


        public List<Post> GetAllPosts()
        {
            return _repo.GetAllPosts();
        }
    }
}
