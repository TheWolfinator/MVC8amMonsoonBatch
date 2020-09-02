using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC8amMonsoonBatch
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                name: "MyTestRoute",
                url: "PizzaHouse/Cake",
                defaults: new { controller = "staff", action = "GetData", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Defaultabhissshek",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "staff", action = "Welcome", id = UrlParameter.Optional }
            );
        }
    }
}
