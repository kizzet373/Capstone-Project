using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.Data.Repos
{
    public interface ITagRepo
    {
        List<Tag> GetAllTags();
        Tag GetTagByName(string tagName);
    }
}
