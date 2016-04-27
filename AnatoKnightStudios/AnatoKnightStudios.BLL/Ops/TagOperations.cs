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
    }
}
