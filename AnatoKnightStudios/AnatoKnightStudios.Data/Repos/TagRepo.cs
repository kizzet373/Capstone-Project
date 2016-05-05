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

        public Tag GetTagByName(string tagName)
        {
            using (var _cn = new SqlConnection(_conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("TagName", tagName);
                var tag = _cn.Query<Tag>(@"SELECT * FROM Tag WHERE Tag.TagName = @TagName", parameters).FirstOrDefault();
                return tag;
            }
        }

        public Tag GetTagById(int id)
        {
            using (var _cn = new SqlConnection(_conn))
            {
                var parameters = new DynamicParameters();
                parameters.Add("id", id);
                var tag = _cn.Query<Tag>(@"SELECT * FROM Tag WHERE Tag.TagId = @id", parameters).FirstOrDefault();
                return tag;
            }
        }


        public int AddTag(Tag tag)
        {
            using (var _cn = new SqlConnection(_conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("TagName", tag.TagName);                

                string query = "INSERT INTO Tag (TagName, TagPopularity) " +
                               "VALUES (@TagName, 0) " +
                               "SELECT CAST(SCOPE_IDENTITY() as int)";
                var id = _cn.Query<int>(query, parameters).Single();               

                return id;
            }
        }

        public void IncrementTagPopularity(Tag tag)
        {
            using (var _cn = new SqlConnection(_conn))
            {
                var parameters = new DynamicParameters();

                parameters.Add("TagId", tag.TagId);

                string query = "UPDATE Tag " +
                               "SET TagPopularity = TagPopularity + 1 " +
                               "WHERE TagId=@TagId";                

                _cn.Execute(query, parameters);
            }
        }
    }
}
