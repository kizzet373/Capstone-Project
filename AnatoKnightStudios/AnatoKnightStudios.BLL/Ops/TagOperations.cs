using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Data.Repos;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.BLL.Ops
{
    public class TagOperations
    {
        public List<Tag>GetAllTags()
        {
            var tagRepo = new TagRepo();
            var tags = tagRepo.GetAllTags();
            return tags;
        }

        public Tag GetTagByName(string tagName)
        {
            var tag = new Tag();
            var tagRepo = new TagRepo();
            return tagRepo.GetTagByName(tagName);
        }

        public int AddTag(Tag tag)
        {
            var tagRepo = new TagRepo();
            Tag checkedTag = GetTagByName(tag.TagName);
            if (checkedTag == null)
            {                
                return tagRepo.AddTag(tag);
            }
            else
            {
                tagRepo.IncrementTagPopularity(checkedTag);
                return checkedTag.TagId;
            }
        }
    }
}
