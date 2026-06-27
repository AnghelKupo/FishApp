using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FishApp.API.Models
{
    // Tabla dbo.Especie: catálogo de especies de peces
    public class Especie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Descripcion { get; set; } = string.Empty;

        // Relación 1:N: una especie puede tener muchos peces
        public ICollection<Pez> Peces { get; set; } = new List<Pez>();

        // Relación 1:N: una especie puede tener configuraciones por sexo
        public ICollection<ConfiguracionReproduccion> ConfiguracionesReproduccion { get; set; } = new List<ConfiguracionReproduccion>();
    }
}
