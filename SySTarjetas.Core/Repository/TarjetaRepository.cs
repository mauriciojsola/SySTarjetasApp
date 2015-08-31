using System.Linq;
using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Core.Repository
{
    public class TarjetaRepository : BaseRepository<Tarjeta>, ITarjetaRepository
    {
        public TarjetaRepository(IObjectContextProvider objectContextProvider)
            : base(objectContextProvider)
        {
        }

        public IQueryable<Tarjeta> PorTitular(int titularId, bool? activa = true)
        {
            return activa.HasValue 
                ? Query().Where(x => x.Titular.Id == titularId && x.Active == activa)
                : Query().Where(x => x.Titular.Id == titularId);
        }
    }

    public interface ITarjetaRepository : IRepository<Tarjeta>
    {
        IQueryable<Tarjeta> PorTitular(int titularId, bool? activa = true);
    }

}
