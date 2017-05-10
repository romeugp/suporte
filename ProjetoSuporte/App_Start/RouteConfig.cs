using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjetoSuporte
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                          "StatesList",
                          "AbreChamado/States/List{CountryCode}",
                          new { Controller = "AbreChamado", Action = "StateList", CountryCode = "" }
                          );

            routes.MapRoute(
              "CountriesList",
              "AbreChamado/Countries/List",
              new { Controller = "AbreChamado", Action = "CountryList", CountryCode = "" }
              );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Default", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
