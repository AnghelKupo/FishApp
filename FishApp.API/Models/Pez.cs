namespace FishApp.API.Models

{
    public class Pez
    {
        public required int Id { get; set; }

        public bool Sexo { get; set; }

        public required DateTime FechaRegistro { get; set; }

        public string? PeriodoReproduccion { get; set; }

    }
}

// See https://aka.ms/new-console-template for more information
