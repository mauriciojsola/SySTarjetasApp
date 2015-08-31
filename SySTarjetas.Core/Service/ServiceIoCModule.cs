using Autofac;

namespace SySTarjetas.Core.Service
{
    public class ServiceIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            //builder.RegisterAssemblyTypes(ThisAssembly)
            //       .AssignableTo<IService>()
            //       .AsImplementedInterfaces()
            //       .PropertiesAutowired()
            //       .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(ThisAssembly)
                   .AssignableTo<IService>()
                   .AsImplementedInterfaces()
                   .SingleInstance()
                   .PropertiesAutowired();
        }
    }
}
