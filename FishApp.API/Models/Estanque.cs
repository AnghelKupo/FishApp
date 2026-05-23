namespace FishApp.API.Models
{
    public class Estanque
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public double Tipo { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}