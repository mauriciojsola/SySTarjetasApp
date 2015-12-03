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
                    .ForMember(dest => dest.Cuotas, opt => opt.MapFrom(x => x.CantidadCuotas))
                    .ForMember(dest => dest.RazonSocial, opt => opt.MapFrom(x => x.Comercio.RazonSocial));
            });
        }
    }
}