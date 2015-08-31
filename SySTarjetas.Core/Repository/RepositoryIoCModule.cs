using Autofac;
using SySTarjetas.Core.Infrastructure.App;
using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Core.Repository
{
    public class RepositoryIoCModule : Module
    {
        public bool IsWebContext { get; set; }
        public string ConnectionStringName { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            if (IsWebContext)
            {
                builder.RegisterType<WebBasedObjectContextProvider>().As<IObjectContextProvider>().SingleInstance().PropertiesAutowired();
                builder.RegisterType<WebBasedUnitOfWorkProvider>().As<IUnitOfWorkProvider>().SingleInstance().PropertiesAutowired();
            }
            else
            {
                builder.RegisterType<ThreadStaticObjectContextProvider>().As<IObjectContextProvider>().SingleInstance().PropertiesAutowired();
                builder.RegisterType<ThreadStaticUnitOfWorkProvider>().As<IUnitOfWorkProvider>().SingleInstance().PropertiesAutowired();
            }

            builder.Register(c => AppConfiguration.ConfigureOrm<SySTarjetasEntities>(string.Format("name={0}", ConnectionStringName)))
            .SingleInstance().PropertiesAutowired()
            .ExternallyOwned();


            builder.RegisterAssemblyTypes(ThisAssembly).AssignableTo<IRepository>().AsClosedTypesOf(typeof(IRepository<>))
                .AsImplementedInterfaces().PropertiesAutowired().InstancePerLifetimeScope();
        }
    }
}
