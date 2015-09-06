namespace SySTarjetas.Api.Models
{
    public class TarjetaViewModel
    {
        public int Id { get; set; }
        public string Banco { get; set; }
        public string TipoTarjeta { get; set; }
        public string NumeroTarjeta { get; set; }

        public string FullDescription
        {
            get { return Banco + " - " + TipoTarjeta + " -   [" + NumeroTarjeta + "]"; }
        }
    }
}