using System.Linq;
using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Core.Repository
{
    public class ComercioRepository : BaseRepository<Comercio>, IComercioRepository
    {
        public ComercioRepository(IObjectContextProvider objectContextProvider)
            : base(objectContextProvider)
        {
        }

        public Comercio PorCuit(string cuit)
        {
            return Query().FirstOrDefault(x => x.CUIT == cuit);
        }

        public Comercio PorRazonSocial(string razonSocial)
        {
            return Query().FirstOrDefault(x => x.RazonSocial == razonSocial);
        }
    }

    public interface IComercioRepository : IRepository<Comercio>
    {
        Comercio PorCuit(string cuit);
        Comercio PorRazonSocial(string razonSocial);
    }
}
