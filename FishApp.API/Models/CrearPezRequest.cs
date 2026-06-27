namespace FishApp.API.Models
{
    public class CrearPezRequest
    {
        public string Codigo { get; set; } = string.Empty;
        public bool Sexo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int IdEstanque { get; set; }
        public DateTime FechaEntrada { get; set; }
        public int EspecieId { get; set; }
    }
}

