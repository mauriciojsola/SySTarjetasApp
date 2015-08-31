using System;
using SySTarjetas.Core.Infrastructure.Persistence;
using ObjectContext = System.Data.Objects.ObjectContext;

namespace SySTarjetas.Core.Infrastructure.App
{
    public class AppConfiguration
    {
        public static IObjectContextFactory ConfigureOrm<T>() where T : ObjectContext, new()
        {
            return new ObjectContextFactory<T>(() => new T());
        }

        public static IObjectContextFactory ConfigureOrm<T>(string connectionString) where T : ObjectContext, new()
        {
            return new ObjectContextFactory<T>(() => (T)Activator.CreateInstance(typeof(T), connectionString));
        }

    }

    public enum Environment
    {
        Web,
        None
    }
}
