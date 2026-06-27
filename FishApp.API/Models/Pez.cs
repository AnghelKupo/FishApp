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

        // false = Macho, true = Hembra
        public bool Sexo { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        // Fecha de la última reproducción (null si nunca se ha reproducido)
        public DateTime? FechaUltimaReproduccion { get; set; }

        // FK hacia Especie (un pez pertenece a una sola especie)
        [Required]
        public int EspecieId { get; set; }

        [ForeignKey(nameof(EspecieId))]
        public Especie Especie { get; set; } = null!;

        public ICollection<PezEstanque> PecesEstanques { get; set; } = new List<PezEstanque>();
    }
}
