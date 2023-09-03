using System.ComponentModel.DataAnnotations; // Importa atributos de validación
using System.ComponentModel.DataAnnotations.Schema; // Importa atributos de esquema

namespace Exercicio2.Models
{
    public class Empleado
    {
        [Key]
        [StringLength(8)]
        public required string Dni { get; set; } // Clave primaria de 8 caracteres

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; } // Nombre del empleado, requerido y longitud máxima de 50 caracteres

        [Required]
        [StringLength(100)]
        public string? Apellidos { get; set; } // Apellidos del empleado, requeridos y longitud máxima de 100 caracteres

        [ForeignKey("Departamento")]
        public int DepartamentoCodigo { get; set; } // Clave foránea hacia el Departamento

        public Departamento? Departamento { get; set; } // Relación con la entidad Departamento (puede ser nulo)
    }
}
