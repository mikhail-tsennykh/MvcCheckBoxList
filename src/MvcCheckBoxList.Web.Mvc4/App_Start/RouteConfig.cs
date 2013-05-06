using System.Web.Mvc;
using System.Web.Routing;

namespace MvcCheckBoxList.Web.Mvc4 {
  public class RouteConfig {
    public static void RegisterRoutes(RouteCollection routes) {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRoute(
        name: "Base", url: "{action}/{id}",
        defaults: new {controller = "Home", action = "Index", id = UrlParameter.Optional}
        );

    }
  }
}