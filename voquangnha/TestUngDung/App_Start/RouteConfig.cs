using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TestUngDung
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            
            routes.MapRoute(
                name: "CategoryProduct",
                url: "danh-muc-san-pham/{id}",
                defaults: new { controller = "Category", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "TestUngDung.Controllers" }
            );
            routes.MapRoute(
              name: "ProductDetail",
              url: "chi-tiet/{id}",
              defaults: new { controller = "Product", action = "Detail", id = UrlParameter.Optional },
              namespaces: new[] { "TestUngDung.Controllers" });

            routes.MapRoute(
              name: "ProductAll",
              url: "tat-ca-san-pham",
              defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "TestUngDung.Controllers" });

            


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TestUngDung.Controllers" }
                
            );
        }

    }
}
