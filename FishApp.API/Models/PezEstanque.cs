using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishApp.API.Models
{
    public class PezEstanque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int IdPez { get; set; }

        [Required]
        public int IdEstanque { get; set; }

        [Required]
        public DateTime FechaEntrada { get; set; }

        public DateTime? FechaSalida { get; set; }

        [MaxLength(500)]
        public string? MotivoMovimento { get; set; }

        [ForeignKey(nameof(IdPez))]
        public Pez Pez { get; set; } = null!;

        [ForeignKey(nameof(IdEstanque))]
        public Estanque Estanque { get; set; } = null!;
    }
}