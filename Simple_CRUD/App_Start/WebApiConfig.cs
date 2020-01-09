using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Simple_CRUD
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ActionOnlyRoute",
                routeTemplate: "",
                defaults: new { controller = "Main"}
            );
            config.Formatters.Remove(config.Formatters.XmlFormatter);

        }
    }
}
