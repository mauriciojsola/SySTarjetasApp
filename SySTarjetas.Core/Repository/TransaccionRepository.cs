using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Core.Repository
{
    public class TransaccionRepository : BaseRepository<Transaccion>, ITransaccionRepository
    {
        public TransaccionRepository(IObjectContextProvider objectContextProvider)
            : base(objectContextProvider)
        {
        }

    }

    public interface ITransaccionRepository : IRepository<Transaccion>
    {

    }
}
