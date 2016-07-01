using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SySTarjetas.Api.Models;
using SySTarjetas.Core.Repository;

namespace SySTarjetas.Api.Controllers
{
    [RoutePrefix("api/tarjetas")]
    public class TarjetasController : ApiControllerBase
    {
        public ITarjetaRepository TarjetaRepository { get; set; }

        [HttpGet]
        [Route("list/titular/{titularId}")]
        public IList<TarjetaViewModel> List(int titularId)
        {
            if (titularId > -1)
            {
                var tarjetasTitular = TarjetaRepository.PorTitular(titularId).OrderBy(x => x.Banco.RazonSocial).ThenBy(
                        x => x.TipoTarjeta.Descripcion)
                        .Select(x => new TarjetaViewModel
                        {
                            Id = x.Id,
                            Banco = x.Banco.RazonSocial,
                            TipoTarjeta = x.TipoTarjeta.Descripcion,
                            NumeroTarjeta = x.NumeroTarjeta 
                        });

                return tarjetasTitular.ToList();
            }
            return  new List<TarjetaViewModel>();
        }

        [HttpGet]
        [Route("select/titular/{titularId}")]
        public IEnumerable<KeyValueModel> Select(int titularId)
        {
            return TarjetaRepository.PorTitular(titularId).OrderBy(x => x.Banco.RazonSocial).ThenBy(x => x.TipoTarjeta.Descripcion).ToList()
                .Select(x => new KeyValueModel { Key = x.Id.ToString(), Value = string.Format("{0} - {1} - [{2}]", x.Banco.RazonSocial, x.TipoTarjeta.Descripcion, x.NumeroTarjeta) });

        }
    }

}