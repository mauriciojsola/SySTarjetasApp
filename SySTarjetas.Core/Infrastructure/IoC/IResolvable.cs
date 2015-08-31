using Autofac;

namespace SySTarjetas.Core.Infrastructure.IoC
{
    public interface IResolvable
    {
        IContainer IoCContainer { get; set; }
    }
}
