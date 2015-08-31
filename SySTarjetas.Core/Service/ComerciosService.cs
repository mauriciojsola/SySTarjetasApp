using System;
using System.Linq;
using SySTarjetas.Core.Infrastructure.Persistence;
using SySTarjetas.Core.Repository;

namespace SySTarjetas.Core.Service
{
    public interface IComerciosService : IService
    {
        void AgregarComercio(string razonSocial, string cuit, string direccion);
        Comercio TraerComercioPorId(int comercioId);
        void ActualizarComercio(int comercioId, string razonSocial, string direccion);
        void EliminarComercio(int comercioId);
    }

    public class ComerciosService : IComerciosService
    {
        public IComercioRepository ComercioRepository { get; set; }

        public void AgregarComercio(string razonSocial, string cuit, string direccion)
        {
            //if (GenericRepository.Find<Comercio>().PorCuit(cuit) != null)
            //{
            //    throw new Exception("El CUIT está duplicado");
            //}

            if (ComercioRepository.PorRazonSocial(razonSocial) != null)
            {
                throw new Exception("La Razón Social está duplicada");
            }

            var comercio = new Comercio
            {
                RazonSocial = razonSocial,
                CUIT = cuit,
                Direccion = direccion
            };
            ComercioRepository.Add(comercio);
        }

        public Comercio TraerComercioPorId(int comercioId)
        {
            return ComercioRepository.GetById(comercioId);
        }

        public void ActualizarComercio(int comercioId, string razonSocial, string direccion)
        {
            //using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
            //{
            var comercio = ComercioRepository.GetById(comercioId);
            if (comercio != null)
            {
                comercio.Direccion = direccion;
                comercio.RazonSocial = razonSocial;

                //uow.Commit();
            }
            //}
        }

        public void EliminarComercio(int comercioId)
        {
            //using (var uow = UnitOfWorkProvider.BeginUnitOfWork())
            //{
            var comercio = ComercioRepository.GetById(comercioId);
            if (comercio != null)
            {
                ComercioRepository.Remove(comercio);
                //uow.Commit();
            }
            //}
        }
    }
}
