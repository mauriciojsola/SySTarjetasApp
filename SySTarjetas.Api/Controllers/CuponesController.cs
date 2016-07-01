using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using SySTarjetas.Api.Common;
using SySTarjetas.Api.Models;
using SySTarjetas.Core.Repository;
using SySTarjetas.Core.Service;

namespace SySTarjetas.Api.Controllers
{
    [RoutePrefix("api/cupones")]
    public class CuponesController : ApiControllerBase
    {
        public ISySTarjetasService SySTarjetasService { get; set; }
        public ITransaccionRepository TransaccionRepository { get; set; }

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

                listadoCupones = cupones.OrderBy(x => x.FechaCompra).Skip((pageNumber - 1) * pageSize).Take(pageSize).Select(
                    x => Mapper.Map<CuponViewModel>(x)).ToList();
            }

            return new PagedResponse<CuponViewModel>(listadoCupones.OrderBy(x => x.FechaCompraParaOrdenar).ToList(), pageNumber, pageSize, totalCount);
        }

        [HttpGet]
        [Route("{id:int}")]
        public CuponViewModel Get(int id)
        {
            var cuponViewModel = new CuponViewModel();
            var cupon = TransaccionRepository.GetById(id);
            if (cupon != null)
                cuponViewModel = Mapper.Map<CuponViewModel>(cupon);
            return cuponViewModel;
        }

        [HttpPost]
        [Route("save")]
        public HttpResponseMessage SaveCupon(CuponViewModel cupon)
        {
            try
            {
                if (cupon.Id > 0)
                {
                    SySTarjetasService.ActualizarCupon(cupon.Id, cupon.TarjetaId, DateTime.Parse(cupon.FechaCompra), cupon.ComercioId,
                                                          cupon.NumeroCupon, cupon.Importe, cupon.Cuotas, "NADA");
                    return SuccessResponse(new JsonResponse("Cupón actualizado correctamente"));
                }

                SySTarjetasService.GrabarCupon(cupon.TarjetaId, DateTime.Parse(cupon.FechaCompra), cupon.ComercioId,
                    cupon.NumeroCupon, cupon.Importe, cupon.Cuotas, "NADA");
                return SuccessResponse(new JsonResponse("Cupón grabado correctamente"));
            }
            catch (Exception ex)
            {
                return GenericRequestResponse(new JsonResponse("Error al grabar el cupón", new List<string> { ex.Message }));
            }

        }

    }
}