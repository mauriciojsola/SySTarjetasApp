using System;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using SySTarjetas.Core.Common.Extensions;
using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Core.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : class, IIdentifiable
    {
        private static readonly Expression<Func<IIdentifiable, int>> ID_PROP = d => d.Id;
        private static readonly string ID_PROP_NAME = ID_PROP.GetPropertyName();

        private IObjectContextProvider _objectContextProvider { get; set; }

        public BaseRepository(IObjectContextProvider objectContextProvider)
        {
            _objectContextProvider = objectContextProvider;
        }

        protected ObjectSet<T> Query()
        {
            return _objectContextProvider.Current.GetObjectSet<T>();
        }

        public T GetById(int id)
        {
            return Query().SingleOrDefault(IdEqualTo(id));
        }

        private static Expression<Func<T, bool>> IdEqualTo(int id)
        {
            var parameter = Expression.Parameter(typeof(T), "x");
            var property = Expression.Property(parameter, ID_PROP_NAME);
            var constant = Expression.Constant(id);
            var equal = Expression.Equal(property, constant);

            return Expression.Lambda<Func<T, bool>>(equal, parameter);
        }

        public void Add(T t)
        {
            Query().AddObject(t);
        }

        public void Remove(T t)
        {
            Query().DeleteObject(t);
        }

        public void Remove(int id)
        {
            Remove(GetById(id));
        }

        /// <summary>
        /// Find for all objects, even the ones that are marked as "deleted"
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> GetAll()
        {
            return Query();
        }
    }
}
