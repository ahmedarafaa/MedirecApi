using AutoMapper;
using Medirec.MessageHandler;
using MediRec.App_Start;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Medirec
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Api
            GlobalConfiguration.Configuration.MessageHandlers.Add(new APIKeyMessageHandler());

            //Auto Mapper
            Mapper.Initialize(c => c.AddProfile<MappingProfile>());

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Json

            GlobalConfiguration.Configuration
                .Formatters.JsonFormatter.SerializerSettings
            .ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ;
            GlobalConfiguration.Configuration.Formatters
                .Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }
    }
}
