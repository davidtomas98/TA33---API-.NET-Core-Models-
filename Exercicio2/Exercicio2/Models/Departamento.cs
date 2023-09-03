using System.ComponentModel.DataAnnotations; // Importa atributos de validación

namespace Exercicio2.Models
{
    public class Departamento
    {
        [Key]
        public int Codigo { get; set; } // Clave primaria

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; } // Nombre del departamento, requerido y longitud máxima de 100 caracteres

        [Required]
        public int Presupuesto { get; set; } // Presupuesto del departamento, requerido

        public ICollection<Empleado> Empleados { get; set; } = new List<Empleado>(); // Relación uno a muchos con la entidad Empleado
    }
}
