using System.ComponentModel.DataAnnotations; // Importa atributos de validación
using System.ComponentModel.DataAnnotations.Schema; // Importa atributos de esquema

namespace Exercicio3.Models
{
    public class Caja
    {
        [Key]
        [StringLength(5)]
        public required string NumReferencia { get; set; } // Clave primaria de 5 caracteres

        [StringLength(100)]
        public string? Contenido { get; set; } // Contenido de la caja, longitud máxima de 100 caracteres

        [Required]
        public int Valor { get; set; } // Valor de la caja, requerido

        [ForeignKey("Almacen")]
        public int AlmacenCodigo { get; set; } // Clave foránea hacia el Almacen

        public Almacen? Almacen { get; set; } // Relación con la entidad Almacen (puede ser nulo)
    }
}
