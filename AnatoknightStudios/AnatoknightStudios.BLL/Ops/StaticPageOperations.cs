using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AnatoknightStudios.Data.Repos;
using AnatoknightStudios.Models;

namespace AnatoknightStudios.BLL.Ops
{
    public class StaticPageOperations
    {
        private StaticPageRepo _repo = new StaticPageRepo();

        public List<StaticPage> GetAllPages()
        {
            return _repo.GetAllPages();
        }

        public StaticPage GetPageById(int pageId)
        {
            return _repo.GetPageById(1);
        }

        public StaticPage Add(StaticPage page, int pageId)
        {
            _repo.AddPage(page, pageId);
            return page;
        }
    }
}
