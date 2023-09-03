using System.ComponentModel.DataAnnotations; // Importa atributos de validación
using System.ComponentModel.DataAnnotations.Schema; // Importa atributos de esquema

namespace Exercicio3.Models
{
    public class Almacen
    {
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; } // Clave primaria autoincremental

        [StringLength(100)]
        public string? Lugar { get; set; } // Lugar del almacén, longitud máxima de 100 caracteres

        [Required]
        public int Capacidad { get; set; } // Capacidad del almacén, requerida

        public ICollection<Caja> Cajas { get; set; } = new List<Caja>(); // Relación uno a muchos con la entidad Caja
    }
}
