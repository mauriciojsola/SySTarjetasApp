using System.Linq;
using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Core.Repository
{
    public class TitularRepository : BaseRepository<Titular>, ITitularRepository
    {
        public TitularRepository(IObjectContextProvider objectContextProvider)
            : base(objectContextProvider)
        {
        }

    }

    public interface ITitularRepository : IRepository<Titular>
    {
        
    }

}
