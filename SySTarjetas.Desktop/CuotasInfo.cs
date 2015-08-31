namespace SySTarjetas
{
    public class CuotasInfo
    {
        public int Id { get; set; }
        public string FechaCompra { get; set; }
        public int NroComprobante { get; set; }
        public string RazonSocial { get; set; }
        public string Cuota { get; set; }
        public double Importe { get; set; }
        public string ImporteFormateado { get; set; }
        public bool Verificado { get; set; }
        public int CuponId { get; set; }
    }
}