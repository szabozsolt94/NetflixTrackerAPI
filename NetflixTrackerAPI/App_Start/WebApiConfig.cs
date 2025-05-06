using System.Web.Http;
using System.Web.Http.Cors;

namespace NetflixTrackerAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Remove XML formatter (keep JSON only)
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();

            // Enable CORS globally (allow all origins, headers, methods)
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            // Default API route (Uncommented this line to restore functionality)
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

