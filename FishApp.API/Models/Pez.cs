using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishApp.API.Models
{
    public class Pez
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Codigo { get; set; } = string.Empty;

        public bool Sexo { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        public string? PeriodoReproduccion { get; set; }

        public ICollection<PezEstanque> PecesEstanques { get; set; } = new List<PezEstanque>();
    }
}
