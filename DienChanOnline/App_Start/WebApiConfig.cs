using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DienChanOnline.App_Start
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;

            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();

            settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{lang}/{id}",
                defaults: new { lang = RouteParameter.Optional, id = RouteParameter.Optional }
            );

            //config.Routes.MapHttpRoute(
            //    name: "2ParamsApi",
            //    routeTemplate: "api/{controller}/{lang}/{id}",
            //    defaults: new { lang = RouteParameter.Optional, id = RouteParameter.Optional }
            //);
        }
    }
}