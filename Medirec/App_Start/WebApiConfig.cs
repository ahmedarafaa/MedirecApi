using Medirec.Models;
using Microsoft.OData.Edm;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Web.Http;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using System;

namespace Medirec
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var setting = config.Formatters.JsonFormatter.SerializerSettings;
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            setting.Formatting = Formatting.Indented;

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            config.MapODataServiceRoute("ODataRoute", "odata", GetEdmModel());

            var timeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Egypt Standard Time");
            config.SetTimeZoneInfo(timeZoneInfo);

            config.EnsureInitialized();
        }

        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();
            builder.Namespace = "Medirec";
            builder.ContainerName = "MedirecContainer";

            builder.EntitySet<Doctors>("Doctors");
            builder.EntitySet<DoctorsEntities>("DoctorsEntities");
            builder.EntitySet<CalendersDetails>("CalendersDetails");

            return builder.GetEdmModel();
        }
    }
}
