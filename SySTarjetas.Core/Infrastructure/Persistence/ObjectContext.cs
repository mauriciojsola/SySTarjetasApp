using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;

namespace SySTarjetas.Core.Infrastructure.Persistence
{
    public class ObjectContext : IDisposable
    {
        private readonly Dictionary<Type, object> _objectSets = new Dictionary<Type, object>();

        public ObjectContext(System.Data.Objects.ObjectContext objectContext)
        {
            EFContext = objectContext;
        }

        public System.Data.Objects.ObjectContext EFContext { get; private set; }

        public ObjectSet<T> GetObjectSet<T>() where T : class
        {
            object objectSet;
            if (!_objectSets.TryGetValue(typeof(T), out objectSet))
            {
                objectSet = CreateObjectSet<T>();
                _objectSets.Add(typeof(T), objectSet);
            }
            return (ObjectSet<T>)objectSet;
        }

        private ObjectSet<T> CreateObjectSet<T>() where T : class
        {
            var property = EFContext.GetType().GetProperties().Single(x => x.PropertyType == typeof(ObjectSet<T>));
            return (ObjectSet<T>)property.GetGetMethod().Invoke(EFContext, null);
        }

        public void Dispose()
        {
            EFContext.Dispose();
        }

        public void SaveChanges()
        {
            EFContext.SaveChanges();
        }
    }
}
