﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Partners
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Partners",
                url: "{controller}/{action}/{CountryID}/{StateID}/{id}",
                defaults: new { controller = "Partners", action="Index", CountryID = UrlParameter.Optional, StateID = UrlParameter.Optional, AccType = UrlParameter.Optional, id=UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Search",
                url: "{controller}/{action}/{CountryID}/{StateID}/{id}",
                defaults: new { controller = "Partners", action = "Index", CountryID = UrlParameter.Optional, StateID = UrlParameter.Optional, id = UrlParameter.Optional }
            );
        }
    }
}
