using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishApp.API.Models
{
    // Tabla dbo.ConfiguracionReproduccion: parámetros de ciclo reproductivo por especie y sexo
    // Máximo un registro por combinación (EspecieId + Sexo)
    public class ConfiguracionReproduccion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int EspecieId { get; set; }

        // false = Macho, true = Hembra
        public bool Sexo { get; set; }

        // Días que dura el ciclo reproductivo completo
        public int DiasCiclo { get; set; }

        // Días que dura la etapa receptiva dentro del ciclo
        public int DuracionEtapa { get; set; }

        [ForeignKey(nameof(EspecieId))]
        public Especie Especie { get; set; } = null!;
    }
}
