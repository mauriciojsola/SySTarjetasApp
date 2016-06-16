using System;

namespace SySTarjetas.Api.Models
{
    public class CuponViewModel
    {
        public int Id { get; set; }
        public string Comercio { get; set; }
        public string FechaCompra { get; set; }
        public DateTime FechaCompraParaOrdenar { get; set; }
        public int NumeroCupon { get; set; }
        public double Importe { get; set; }
        public string ImporteFormateado { get; set; }
        public int Cuotas { get; set; }

        // Requeridos para grabar
        public int TitularId { get; set; }
        public int TarjetaId { get; set; }
        public int ComercioId { get; set; }


    }
}