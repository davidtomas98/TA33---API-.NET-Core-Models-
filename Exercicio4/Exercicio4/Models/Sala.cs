using System.ComponentModel.DataAnnotations; // Importa atributos de validación
using System.ComponentModel.DataAnnotations.Schema; // Importa atributos de esquema

namespace Exercicio4.Models
{
    public class Sala
    {
        [Key]
        public int Codigo { get; set; } // Clave primaria

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; } // Nombre de la sala, requerido y longitud máxima de 50 caracteres

        [ForeignKey("Pelicula")]
        public int PeliculaCodigo { get; set; } // Clave foránea hacia la Pelicula

        public Pelicula? Pelicula { get; set; } // Relación con la entidad Pelicula (puede ser nulo)
    }
}
