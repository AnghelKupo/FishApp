namespace FishApp.API.Models
{
    public class PezEstanque
    {
        public int Id { get; set; }

        public int IdPez { get; set; }

        public int IdEstanque { get; set; }

        public required DateTime FechaEntrada { get; set; }

        public DateTime FechaSalida { get; set; }

        public string? MotivoMovimento { get; set; }
    }
}