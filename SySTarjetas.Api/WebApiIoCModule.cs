using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;

namespace SySTarjetas.Api
{
    public class WebApiIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Setup WebApi controllers & routes
            builder.RegisterApiControllers(ThisAssembly)
                .PropertiesAutowired();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterWebApiFilterProvider(config);
        }

        public static void InitWebApi(ILifetimeScope container)
        {
            // Setup WebAPI DependencyResolver
            GlobalConfiguration.Configure(x =>
            {
                x.DependencyResolver = new AutofacWebApiDependencyResolver(container);
                x.MapHttpAttributeRoutes();

                x.Routes.MapHttpRoute("DefaultApiAction", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional });
                x.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });
                //x.EnableCors();
                var serializerSettings = x.Formatters.JsonFormatter.SerializerSettings;
                var contractResolver = (DefaultContractResolver)serializerSettings.ContractResolver;
                contractResolver.IgnoreSerializableAttribute = true;
            });

            AutoMapperConfiguration.Configure();
        }
    }
}