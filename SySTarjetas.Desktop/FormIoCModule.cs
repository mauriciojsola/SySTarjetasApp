using System.Windows.Forms;
using Autofac;
using SySTarjetas.Core.Repository;
using SySTarjetas.Core.Service;

namespace SySTarjetas.Desktop
{
    public class FormIoCModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterModule(new RepositoryIoCModule { IsWebContext = false, ConnectionStringName = "SySTarjetasEntities" });
            builder.RegisterModule<ServiceIoCModule>();

            builder.RegisterAssemblyTypes(ThisAssembly).AssignableTo<Form>().PropertiesAutowired().ExternallyOwned();

        }
    }
}
