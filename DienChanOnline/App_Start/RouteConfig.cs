using System.Web.Mvc;
using System.Web.Routing;
using LowercaseRoutesMVC4;

namespace DienChanOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapMvcAttributeRoutes();

            routes.MapRouteLowercase(
                name: "HomePage",
                url: "index",
                defaults: new { controller = "Home", action = "Index" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
