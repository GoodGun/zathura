using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Zathura.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Football",
                url: "futbol",
                defaults: new { controller = "Home", action = "Filter" , page = "Futbol"}
            );

            routes.MapRoute(
                name: "Basketball",
                url: "basketbol",
                defaults: new { controller = "Home", action = "Filter", page = "Basketbol" }
            );

            routes.MapRoute(
                name: "Volleyball",
                url: "voleybol",
                defaults: new { controller = "Home", action = "Filter", page = "Voleybol" }
            );

            routes.MapRoute(
                name: "Tennis",
                url: "tenis",
                defaults: new { controller = "Home", action = "Filter", page = "Tenis" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

        }
    }
}
