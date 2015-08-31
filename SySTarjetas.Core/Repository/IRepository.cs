using System.Linq;

namespace SySTarjetas.Core.Repository
{
    public interface IRepository { }

    public interface IRepository<T> : IRepository where T : class, IIdentifiable
    {
        T GetById(int id);
        IQueryable<T> GetAll();
        void Add(T t);
        void Remove(T t);
        void Remove(int id);
    }

    public interface IIdentifiable
    {
        int Id { get; }
    }
}
