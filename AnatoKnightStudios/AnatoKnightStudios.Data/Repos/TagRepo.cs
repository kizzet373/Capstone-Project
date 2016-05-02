using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Models;
using Dapper;

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
            using (var _cn = new SqlConnection(_conn))
            {
                var tags = _cn.Query<Tag>("SELECT * FROM Tag ").ToList();
                return tags;
            }
        }
    }
}
