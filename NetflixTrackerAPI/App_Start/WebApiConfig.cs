using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace NetflixTrackerAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();


            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable CORS globally
            config.EnableCors();

            // Register the CorsHandler to add the CORS headers
            config.MessageHandlers.Add(new CorsHandler());
        }
    }
}
