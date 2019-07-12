using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectUniversity.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Professor", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Disciplina",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Disciplina", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
