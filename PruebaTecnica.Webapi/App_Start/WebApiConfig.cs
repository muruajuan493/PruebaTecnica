using PruebaTecnica.Webapi.Authorization;
using Swashbuckle.Application;
using System.Web.Http;
using System.Web.Http.Cors;

namespace PruebaTecnica.Webapi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            var cors = new EnableCorsAttribute("*", "*", "GET,POST,DELETE, *", "Content-Disposition, Authorization, From, *");
            config.EnableCors(cors);

            // Web API routes
            config.MapHttpAttributeRoutes();

            if (!config.Routes.ContainsKey("swagger_root"))
            {
                config.Routes.MapHttpRoute(
                    name: "swagger_root",
                    routeTemplate: "",
                    defaults: null,
                    constraints: null,
                    handler: new RedirectHandler((message => message.RequestUri.ToString()), "swagger")
                );
            }

            if (!config.Routes.ContainsKey("DefaultApi"))
            {
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
            }

            config.MessageHandlers.Add(new TokenValidationHandler());
        }
    }
}
