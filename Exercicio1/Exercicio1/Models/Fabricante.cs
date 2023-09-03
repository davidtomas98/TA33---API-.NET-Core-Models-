using System.ComponentModel.DataAnnotations; // Importa atributos de validación
using System.ComponentModel.DataAnnotations.Schema; // Importa atributos de esquema

namespace Exercicio1.Models
{
    public class Fabricante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; } // Clave primaria autoincremental

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; } // Nombre del fabricante, requerido y longitud máxima de 50 caracteres

        public ICollection<Articulo> Articulos { get; set; } = new List<Articulo>(); // Relación uno a muchos con la entidad Articulo
    }
}
