using System;
using System.Collections.Generic;
using System.Linq;
using SySTarjetas.Core.Common;
using SySTarjetas.Core.Common.Extensions;
using SySTarjetas.Core.Repository;

namespace SySTarjetas.Core.Service
{
    public interface ISySTarjetasService : IService
    {
        void GrabarCupon(int tarjetaId, DateTime fechaCupon,
            int comercioId, int nroCupon, double importe,
            int cantidadCuotas, string observaciones);

        void ActualizarCupon(int cuponId, int tarjetaId, DateTime fechaCupon,
            int comercioId, int nroCupon, double importe,
            int cantidadCuotas, string observaciones);

        void EliminarCupon(int transaccionId);
        bool ExisteCupon(int tarjetaId, DateTime fechaCupon, int comercioId, int nroCupon);
        DateTime? TraerFechaDeCierre(int tarjetaId, int anio, int mes);
        void GrabarFechaDeCierre(int tarjetaId, int anio, int mes, DateTime fechaCierre);
        void ActualizarFechaDeCierre(int tarjetaId, int anio, int mes, DateTime fechaCierre);
        IList<TransaccionCuota> TraerResumenPorTarjetaAnioYMes(int tarjetaId, int anio, int mes);
        IList<Transaccion> TraerCuponesPorTarjetaAnioYMes(int tarjetaId, int anio, int mes);
        IList<Transaccion> TraerCuponesPorTarjeta(int tarjetaId);
        Transaccion TraerCuponPorId(int cuponId);
        void MarcarVerificacionCuota(int cuotaId, bool verificado);
    }

    public class SySTarjetasService : ISySTarjetasService
    {
        //public IUnitOfWorkProvider UnitOfWorkProvider { get; set; }
        public IComercioRepository ComercioRepository { get; set; }
        public ITarjetaRepository TarjetaRepository { get; set; }
        public ITransaccionCuotaRepository TransaccionCuotaRepository { get; set; }
        public ITransaccionRepository TransaccionRepository { get; set; }
        public ITarjetaFechaCierreRepository TarjetaFechaCierreRepository { get; set; }

        public void GrabarCupon(int tarjetaId, DateTime fechaCupon,
            int comercioId, int nroCupon, double importe,
            int cantidadCuotas, string observaciones)
        {
           
            if (ExisteCupon(tarjetaId, fechaCupon, comercioId, nroCupon))
                throw new Exception("El cupón ya existe");

            var tarjeta = TarjetaRepository.GetById(tarjetaId);
            if (tarjeta == null) throw new Exception("La Tarjeta es requerida");

            var comercio = ComercioRepository.GetById(comercioId);
            if (comercio == null) throw new Exception("El Comercio es requerido");

            var fechaCierreTarjeta = TarjetaFechaCierreRepository.GetFechaDeCierrePorMesYAnio(tarjeta, fechaCupon.Month, fechaCupon.Year);
            if (fechaCierreTarjeta == null) throw new Exception("La fecha de cierre de la Tarjeta es requerida");

            var cuotas = CalcularCuotas(fechaCupon, importe, cantidadCuotas, tarjeta);

            // Creo la cabecera de la transaccion, o sea el cupon por el total del importe
            var transaccion = new Transaccion
            {
                Tarjeta = tarjeta,
                Comercio = comercio,
                FechaCompra = fechaCupon,
                NumeroCupon = nroCupon,
                Importe = importe,
                CantidadCuotas = cantidadCuotas,
                Observaciones = observaciones,
                TarjetaFechaCierre = fechaCierreTarjeta
            };

            foreach (var cuota in cuotas)
            {
                var transaccionCuota = new TransaccionCuota
                {
                    Transaccion = transaccion,
                    NumeroCuota = cuota.NroCuota,
                    Fecha = cuota.Fecha,
                    Importe = cuota.Importe
                };
                TransaccionCuotaRepository.Add(transaccionCuota);
            }

        }

        public void ActualizarCupon(int cuponId, int tarjetaId, DateTime fechaCupon,
            int comercioId, int nroCupon, double importe,
            int cantidadCuotas, string observaciones)
        {
          
            var cupon = TraerCuponPorId(cuponId);
            if (cupon == null) throw new Exception("Cupón inexistente");

            var fechaAnterior = cupon.FechaCompra;
            var importeAnterior = cupon.Importe;
            var cantidadCuotasAnterior = cupon.CantidadCuotas;

            var comercio = ComercioRepository.GetById(comercioId);
            if (comercio == null) throw new Exception("El Comercio es requerido");
            cupon.Comercio = comercio;

            cupon.FechaCompra = fechaCupon;
            cupon.NumeroCupon = nroCupon;
            cupon.Importe = importe;
            cupon.CantidadCuotas = cantidadCuotas;
            cupon.Observaciones = observaciones;

            if (fechaAnterior != fechaCupon || importeAnterior != importe ||
                cantidadCuotasAnterior != cantidadCuotas)
            {
                // Acá tengo que actualizar las cuotas
                EliminarCuotasDeCupon(cupon);
                var tarjeta = TarjetaRepository.GetById(tarjetaId);
                if (tarjeta == null) throw new Exception("La Tarjeta es requerida");
                var cuotas = CalcularCuotas(fechaCupon, importe, cantidadCuotas, tarjeta);

                foreach (var cuota in cuotas)
                {
                    var transaccionCuota = new TransaccionCuota
                    {
                        Transaccion = cupon,
                        NumeroCuota = cuota.NroCuota,
                        Fecha = cuota.Fecha,
                        Importe = cuota.Importe
                    };
                    TransaccionCuotaRepository.Add(transaccionCuota);
                }
            }

        }

        public void EliminarCupon(int transaccionId)
        {
           
            var cupon = TransaccionRepository.GetById(transaccionId);
            if (cupon == null) return;
            EliminarCuotasDeCupon(cupon);
            TransaccionRepository.Remove(cupon);

        }

        private void EliminarCuotasDeCupon(Transaccion cupon)
        {
            cupon.TransaccionCuota.ToList().ForEach(c => TransaccionCuotaRepository.Remove(c));
        }

        public bool ExisteCupon(int tarjetaId, DateTime fechaCupon, int comercioId, int nroCupon)
        {
           
            var cupon = TransaccionRepository.GetAll().FirstOrDefault(x => x.Tarjeta.Id == tarjetaId
                                                                           && x.FechaCompra == fechaCupon &&
                                                                           x.Comercio.Id == comercioId
                                                                           && x.NumeroCupon == nroCupon);
            return cupon != null;
           
        }

        public DateTime? TraerFechaDeCierre(int tarjetaId, int anio, int mes)
        {
           
            var tarjeta = TarjetaRepository.GetById(tarjetaId);
            if (tarjeta == null) return null;
            var fechaCierre = TarjetaFechaCierreRepository.GetFechaDeCierrePorMesYAnio(tarjeta, mes, anio);
            if (fechaCierre == null) return null;
            return fechaCierre.FechaCierre;
          
        }

        public void GrabarFechaDeCierre(int tarjetaId, int anio, int mes, DateTime fechaCierre)
        {
           
            var fecha = TraerFechaDeCierre(tarjetaId, anio, mes);
            if (fecha != null) throw new Exception("Fecha de cierre existente");
            var tarjeta = TarjetaRepository.GetById(tarjetaId);
            if (tarjeta == null) throw new Exception("Tarjeta inexistente");
            var tarjetaFechaCierre = new TarjetaFechaCierre
            {
                Tarjeta = tarjeta,
                Anio = anio,
                Mes = mes,
                FechaCierre = fechaCierre
            };
            TarjetaFechaCierreRepository.Add(tarjetaFechaCierre);

        }

        public void ActualizarFechaDeCierre(int tarjetaId, int anio, int mes, DateTime fechaCierre)
        {
          
            var tarjeta = TarjetaRepository.GetById(tarjetaId);
            var fechaCierreTarjeta = TarjetaFechaCierreRepository.GetFechaDeCierrePorMesYAnio(tarjeta, mes, anio);
            fechaCierreTarjeta.FechaCierre = fechaCierre;

        }

        private IEnumerable<Cuota> CalcularCuotas(DateTime fechaCupon, double importe, int cantidadCuotas, Tarjeta tarjeta)
        {
            var fechaCierreTarjeta = TarjetaFechaCierreRepository.GetFechaDeCierrePorMesYAnio(tarjeta, fechaCupon.Month, fechaCupon.Year);
            if (fechaCierreTarjeta == null)
            {
                var posicionCierreTarjeta = tarjeta.TarjetaOpcionCierre.FirstOrDefault().Posicion;
                var diaCierreTarjeta = tarjeta.TarjetaOpcionCierre.FirstOrDefault().DiaDeSemana;

                var fechaCierre = TraerFechaCorte(fechaCupon, posicionCierreTarjeta.CastEnumByName<PosicionCierre>(),
                                                                diaCierreTarjeta.CastEnumByName<DiaCierre>());
                // le asigno la fecha calculada
                fechaCierreTarjeta = new TarjetaFechaCierre
                {
                    Tarjeta = tarjeta,
                    FechaCierre = fechaCierre
                };
                tarjeta.TarjetaFechaCierre.Add(fechaCierreTarjeta);
            }

            var cuotas = DistribuirCuotas(fechaCupon, importe, cantidadCuotas, fechaCierreTarjeta.FechaCierre);

            return cuotas;
        }

        public List<Cuota> DistribuirCuotas(DateTime fechaCupon, double importe, int cantidadCuotas, DateTime fechaCorteCierre)
        {
            var cuotas = new List<Cuota>();
            // asumo que el cupon entra para el mes actual
            var fechaCuota = new DateTime(fechaCupon.Year, fechaCupon.Month, 15);
            if (fechaCupon > fechaCorteCierre)
            {
                // Entra el siguiente mes
                fechaCuota = fechaCuota.AddDays(30);
            }

            if (cantidadCuotas == 1)
            {
                cuotas.Add(new Cuota { Fecha = fechaCuota, NroCuota = 1, Importe = importe });
            }
            else
            {
                var importeCuota = Math.Round(importe / cantidadCuotas, 2);
                // Calculo las n-1 cuotas
                for (var i = 1; i < cantidadCuotas; i++)
                {
                    cuotas.Add(new Cuota { Fecha = fechaCuota, NroCuota = i, Importe = importeCuota });
                    fechaCuota = fechaCuota.AddDays(30);
                }
                // Calculo la ultima cuota como el importe total menos las n-1 cuotas ya calculadas
                var importeUltimaCuota = Math.Round(importe - cuotas.Sum(x => x.Importe), 2);
                cuotas.Add(new Cuota { Fecha = fechaCuota, NroCuota = cantidadCuotas, Importe = importeUltimaCuota });
            }
            return cuotas;
        }

        public DateTime TraerFechaCorte(DateTime fechaActual, PosicionCierre posicionCierre, DiaCierre diaCierre)
        {
            if (diaCierre == DiaCierre.DiaDelMes)
            {
                if (posicionCierre == PosicionCierre.Primer)
                {
                    return fechaActual.FirstMonthDay();
                }
                if (posicionCierre == PosicionCierre.Ultimo)
                {
                    return fechaActual.LastMonthDay();
                }
            }
            else
            {
                return TraerCortePorDiaDeLaSemana(fechaActual, posicionCierre, diaCierre);
            }

            return DateTime.Now;
        }

        public IList<TransaccionCuota> TraerResumenPorTarjetaAnioYMes(int tarjetaId, int anio, int mes)
        {
            var movimientos = TransaccionCuotaRepository.GetAll().Where(x => x.Transaccion.Tarjeta.Id == tarjetaId
                                                                      && x.Fecha.Year == anio && x.Fecha.Month == mes);
            return movimientos.OrderBy(x => x.Fecha).ToList();
        }

        public IList<Transaccion> TraerCuponesPorTarjetaAnioYMes(int tarjetaId, int anio, int mes)
        {
            var cupones = TransaccionRepository.GetAll().Where(x => x.Tarjeta.Id == tarjetaId
                                                                      && x.FechaCompra.Year == anio && x.FechaCompra.Month == mes);
            return cupones.ToList();
        }

        public IList<Transaccion> TraerCuponesPorTarjeta(int tarjetaId)
        {
            var cupones = TransaccionRepository.GetAll().Where(x => x.Tarjeta.Id == tarjetaId);
            return cupones.ToList();
        }

        public Transaccion TraerCuponPorId(int cuponId)
        {
            return TransaccionRepository.GetById(cuponId);
        }

        public void MarcarVerificacionCuota(int cuotaId, bool verificado)
        {
      
            var cuota = TransaccionCuotaRepository.GetById(cuotaId);
            if (cuota == null) return;
            cuota.Verificado = verificado;
        
        }

        private DateTime TraerCortePorDiaDeLaSemana(DateTime fechaActual, PosicionCierre posicionCierre, DiaCierre diaCierre)
        {
            switch (posicionCierre)
            {
                case PosicionCierre.Primer:
                    return fechaActual.FirstMonthDay(TraducirDiaAlIngles(diaCierre));
                case PosicionCierre.Segundo:
                    break;
                case PosicionCierre.Tercer:
                    break;
                case PosicionCierre.Cuarto:
                    break;
                case PosicionCierre.Ultimo:
                    return fechaActual.LastMonthDay(TraducirDiaAlIngles(diaCierre));
                default:
                    throw new ArgumentOutOfRangeException("posicionCierre");
            }
            return DateTime.Now;
        }

        private DayOfWeek TraducirDiaAlIngles(DiaCierre diaCierre)
        {
            switch (diaCierre)
            {
                case DiaCierre.Lunes:
                    return DayOfWeek.Monday;
                case DiaCierre.Martes:
                    return DayOfWeek.Tuesday;
                case DiaCierre.Miercoles:
                    return DayOfWeek.Wednesday;
                case DiaCierre.Jueves:
                    return DayOfWeek.Thursday;
                case DiaCierre.Viernes:
                    return DayOfWeek.Friday;
                case DiaCierre.Sabado:
                    return DayOfWeek.Saturday;
                case DiaCierre.Domingo:
                    return DayOfWeek.Sunday;
                default:
                    throw new ArgumentOutOfRangeException("diaCierre");
            }
        }

        public class Cuota
        {
            public int NroCuota { get; set; }
            public DateTime Fecha { get; set; }
            public double Importe { get; set; }
        }



    }
}
