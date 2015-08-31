using System;

namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public class ObjectContextFactory<T> : IObjectContextFactory where T : System.Data.Objects.ObjectContext
    {
        private readonly Func<T> _factoryMethod;

        public ObjectContextFactory(Func<T> factoryMethod)
        {
            _factoryMethod = factoryMethod;
        }

        public ObjectContext CreateObjectContext()
        {
            return new ObjectContext(_factoryMethod());
        }
    }
}
