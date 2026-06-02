using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishApp.API.Models
{
    public class Estanque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Nombre { get; set; } = string.Empty;

        public double Tipo { get; set; }

        [Required]
        public DateTime FechaCreacion { get; set; }

        public ICollection<PezEstanque> PecesEstanques { get; set; } = new List<PezEstanque>();
    }
}