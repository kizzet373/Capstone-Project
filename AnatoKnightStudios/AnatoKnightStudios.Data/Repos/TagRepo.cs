using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnatoknightStudios.Data.Repos
{
    class TagRepo
    {
        private string conn;

        public TagRepo()
        {
            conn = ConfigurationManager.ConnectionStrings["Anatoknight Studios"].ConnectionString;
        }
    }
}
