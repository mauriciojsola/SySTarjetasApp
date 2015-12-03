namespace SySTarjetas.Api.Models
{
    public class TitularViewModel
    {
        public int Id { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }

        public string FullName
        {
            get
            {
                return string.Join(" ", Apellido, Nombre);
            }
        }
    }
    
}