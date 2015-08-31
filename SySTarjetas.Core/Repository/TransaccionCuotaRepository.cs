using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Core.Repository
{
    public class TransaccionCuotaRepository : BaseRepository<TransaccionCuota>, ITransaccionCuotaRepository
    {
        public TransaccionCuotaRepository(IObjectContextProvider objectContextProvider)
            : base(objectContextProvider)
        {
        }

    }

    public interface ITransaccionCuotaRepository : IRepository<TransaccionCuota>
    {
        
    }
}
