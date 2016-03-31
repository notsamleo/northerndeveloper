using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectRamReo
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "EmailSent",
                "sent",
                new { controller = "Contact", action = "EmailSent" }
                );

            routes.MapRoute(
                "Contact",
                "contact",
                new { controller = "Contact", action = "ContactForm" }
                );

            routes.MapRoute(
                "Portfolio",
                "portfolio",
                new { controller = "Portfolio", action = "Portfolio" }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}