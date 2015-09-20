using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using Newtonsoft.Json.Serialization;
using SySTarjetas.Api.Models;
using SySTarjetas.Core;

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

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaccion, CuponViewModel>()
                    .ForMember(dest => dest.Cuotas, opt => opt.MapFrom(x => x.CantidadCuotas))
                    .ForMember(dest => dest.RazonSocial, opt => opt.MapFrom(x => x.Comercio.RazonSocial));
            });
        }
    }
}