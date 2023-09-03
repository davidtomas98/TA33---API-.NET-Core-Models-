using System.ComponentModel.DataAnnotations; // Importa atributos de validación
using System.ComponentModel.DataAnnotations.Schema; // Importa atributos de esquema

namespace Exercicio4.Models
{
    public class Pelicula
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; } // Clave primaria autoincremental

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; } // Nombre de la película, requerido y longitud máxima de 50 caracteres

        [Required]
        public int CalificacionEdad { get; set; } // Calificación de edad de la película, requerida

        public List<Sala>? Salas { get; set; } // Relación uno a muchos con la entidad Sala (puede ser nulo)
    }
}
