using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicio1.Models
{
    public class Articulo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public required string Nombre { get; set; }

        [Required]
        public int Precio { get; set; }

        [ForeignKey("Fabricante")]
        public int FabricanteCodigo { get; set; }

        public Fabricante? Fabricante { get; set; }
    }
}