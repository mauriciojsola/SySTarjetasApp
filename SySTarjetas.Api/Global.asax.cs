﻿using System.Web;

namespace SySTarjetas.Api
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            //var builder = new ContainerBuilder();

            //// Get your HttpConfiguration.
            //var config = GlobalConfiguration.Configuration;

            //// Register your Web API controllers.
            //builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            //// OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            //// Set the dependency resolver to be Autofac.
            //var container = builder.Build();
            //config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
