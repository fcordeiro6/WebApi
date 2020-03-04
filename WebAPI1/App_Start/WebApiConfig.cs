using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebAPI1
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            // default
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "{id}",
                defaults: new { controller = "contato", id = RouteParameter.Optional }
            );

            // paginacao
            config.Routes.MapHttpRoute(
                name: "GetAll",
                routeTemplate: "{size}/{page}",
                defaults: new { controller = "contato", size = RouteParameter.Optional, page = RouteParameter.Optional }
            );

        }
    }
}
