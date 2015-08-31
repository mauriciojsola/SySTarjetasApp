using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using SySTarjetas.Api;
using SySTarjetas.Web.App_Start;

namespace SySTarjetas.Web
{
    public class MvcApplication : HttpApplication//, IContainerProviderAccessor
    {
        protected void Application_Start()
        {
            // IoC setup
            var builder = new ContainerBuilder();

            builder.RegisterModule<WebApiIoCModule>();
            builder.RegisterModule<MvcIoCModule>();

            builder.RegisterFilterProvider();

            //Build container
            var container = builder.Build();

            // Setup WebAPI DependencyResolver
            WebApiIoCModule.InitWebApi(container);

            //Setup MVC Dependency Resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            //Register bundles
            BundleConfig.Register(BundleTable.Bundles);
        }
    }
}
