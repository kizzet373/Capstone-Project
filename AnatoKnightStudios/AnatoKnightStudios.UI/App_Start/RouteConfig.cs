using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AnatoknightStudios.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //map route for static pages, passes controller action to index
            //dont know if need yet
            routes.MapRoute(
                    name: "StaticPage",
                    url: "StaticPage/{action}/{pageId}",
                    defaults: new { controller = "StaticPage", action = "StaticPage", id = UrlParameter.Optional }
                    );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Blog", action = "AdminBlog", id = UrlParameter.Optional }
            );
        }
    }
}
