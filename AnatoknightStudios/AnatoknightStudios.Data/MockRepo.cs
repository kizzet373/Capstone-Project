using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.Data
{
    public class MockRepo
    {
        private static List<Post> _posts = new List<Post>();

        public MockRepo()
        {
            _posts.Add(new Post()
            {
                PostId = 1,
                CategoryId = 1,
                BlogId = 1,
                FirstName = "Kirk",
                LastName = "Brown",
                PostDate = DateTime.Now,
                PostTitle = "Samlple",
                AspNetUserId = "1234567890",
                PostContent = "Hahahahaha",
            });
        }
    }
}
