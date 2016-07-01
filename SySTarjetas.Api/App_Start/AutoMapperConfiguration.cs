using AutoMapper;
using SySTarjetas.Api.Models;
using SySTarjetas.Core;

namespace SySTarjetas.Api
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Transaccion, CuponViewModel>()
                    .ForMember(dest => dest.TitularId, opt => opt.MapFrom(x => x.Tarjeta.Titular.Id))
                    .ForMember(dest => dest.TarjetaId, opt => opt.MapFrom(x => x.Tarjeta.Id))
                    .ForMember(dest => dest.ComercioId, opt => opt.MapFrom(x => x.Comercio.Id))
                    .ForMember(dest => dest.Comercio, opt => opt.MapFrom(x => x.Comercio.RazonSocial))
                    .ForMember(dest => dest.FechaCompra, opt => opt.MapFrom(x => x.FechaCompra.ToShortDateString()))
                    .ForMember(dest => dest.FechaCompraParaOrdenar, opt => opt.MapFrom(x => x.FechaCompra))
                    .ForMember(dest => dest.ImporteFormateado, opt => opt.MapFrom(x => x.Importe.ToString("N")))
                    .ForMember(dest => dest.Cuotas, opt => opt.MapFrom(x => x.CantidadCuotas));

                cfg.CreateMap<Comercio, ComercioViewModel>();

                cfg.CreateMap<Titular, TitularViewModel>();
            });
        }
    }
}