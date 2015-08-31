using System.Linq;
using SySTarjetas.Core.Infrastructure.Persistence;

namespace SySTarjetas.Core.Repository
{
    public class TarjetaFechaCierreRepository : BaseRepository<TarjetaFechaCierre>, ITarjetaFechaCierreRepository
    {
        public TarjetaFechaCierreRepository(IObjectContextProvider objectContextProvider)
            : base(objectContextProvider)
        {
        }

        public TarjetaFechaCierre GetFechaDeCierrePorMesYAnio(Tarjeta tarjeta, int mes, int anio)
        {
            return tarjeta.TarjetaFechaCierre.FirstOrDefault(y => y.Mes == mes && y.Anio == anio);
        }
    }

    public interface ITarjetaFechaCierreRepository : IRepository<TarjetaFechaCierre>
    {
        TarjetaFechaCierre GetFechaDeCierrePorMesYAnio(Tarjeta tarjeta, int mes, int anio);
    }
}
