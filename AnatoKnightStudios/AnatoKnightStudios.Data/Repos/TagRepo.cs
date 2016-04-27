using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.Data.Repos
{
    public class TagRepo
    {
        private string _conn;

        public TagRepo()
        {
            _conn = ConfigurationManager.ConnectionStrings["AnatoknightStudios"].ConnectionString;
        }

        public List<Tag> GetAllTags()
        {
            var tags = new List<Tag>();

            return tags;
        }
    }
}
