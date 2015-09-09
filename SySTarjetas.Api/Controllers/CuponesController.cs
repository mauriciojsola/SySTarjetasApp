using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using SySTarjetas.Api.Models;
using SySTarjetas.Core.Service;

namespace SySTarjetas.Api.Controllers
{
    [RoutePrefix("api/cupones")]
    public class CuponesController : ApiControllerBase
    {
        public ISySTarjetasService SySTarjetasService { get; set; }

        [HttpGet]
        [Route("list")]
        public PagedResponse<CuponViewModel> List(int tarjetaId, int anio, int mes, bool listarTodos, int pageSize, int pageNumber)
        {
            var listadoCupones = new List<CuponViewModel>();
            var totalCount = 0;

            if (tarjetaId > -1)
            {
                var cupones = listarTodos
                    ? SySTarjetasService.TraerCuponesPorTarjeta(tarjetaId)
                    : SySTarjetasService.TraerCuponesPorTarjetaAnioYMes(tarjetaId, anio, mes);

                totalCount = cupones.Count;

                listadoCupones = cupones.OrderBy(x =>x.FechaCompra).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(
                    x =>
                        new CuponViewModel
                        {
                            Id = x.Id,
                            RazonSocial = x.Comercio.RazonSocial,
                            FechaCompra = x.FechaCompra.ToShortDateString(),
                            FechaCompraParaOrdenar = x.FechaCompra,
                            NumeroCupon = x.NumeroCupon,
                            Importe = x.Importe,
                            ImporteFormateado = x.Importe.ToString("N"),
                            Cuotas = x.CantidadCuotas
                        }).ToList();
            }

            return new PagedResponse<CuponViewModel>(listadoCupones.OrderBy(x => x.FechaCompraParaOrdenar).ToList(), pageNumber, pageSize, totalCount);

        }
    }
}