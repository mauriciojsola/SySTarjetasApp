using Autofac;
using Autofac.Integration.Mvc;
using SySTarjetas.Core.Repository;
using SySTarjetas.Core.Service;

namespace SySTarjetas.Web
{
    public class MvcIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule(new RepositoryIoCModule { IsWebContext = true, ConnectionStringName = "SySTarjetasEntities" });
            builder.RegisterModule<ServiceIoCModule>();

            builder.RegisterControllers(ThisAssembly)
                .PropertiesAutowired();
        }
    }
}
